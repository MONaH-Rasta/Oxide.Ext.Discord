using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Entities.Channels;
using Oxide.Ext.Discord.Entities.Gatway;
using Oxide.Ext.Discord.Entities.Gatway.Commands;
using Oxide.Ext.Discord.Entities.Gatway.Events;
using Oxide.Ext.Discord.Entities.Guilds;
using Oxide.Ext.Discord.Entities.Interactions;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.REST;
using Oxide.Ext.Discord.WebSockets;
using Oxide.Plugins;
using Timer = System.Timers.Timer;

namespace Oxide.Ext.Discord
{
    /// <summary>
    /// Represents a bot that is connected to discord
    /// </summary>
    public class BotClient
    {
        /// <summary>
        /// List of active bots by bot API key
        /// </summary>
        public static readonly Hash<string, BotClient> ActiveBots = new Hash<string, BotClient>();
        
        /// <summary>
        /// The current session ID for the connected bot
        /// </summary>
        internal string SessionId;
        
        /// <summary>
        /// The current sequence number for the websocket
        /// </summary>
        internal int Sequence;
        
        /// <summary>
        /// If the connection is initialized and not disconnected
        /// </summary>
        public bool Initialized;
        
        /// <summary>
        /// Discord Acknowledged our heartbeat successfully 
        /// </summary>
        public bool HeartbeatAcknowledged;

        /// <summary>
        /// The settings for this bot of all the combined clients
        /// </summary>
        public readonly DiscordSettings Settings;
        
        /// <summary>
        /// All the servers that this bot is in
        /// </summary>
        public readonly Hash<Snowflake, Guild> Servers = new Hash<Snowflake, Guild>();
        
        /// <summary>
        /// All the direct messages that we have seen by channel Id
        /// </summary>
        public readonly Hash<Snowflake, Channel> DirectMessagesByChannelId = new  Hash<Snowflake, Channel>();
        
        /// <summary>
        /// All the direct messages that we have seen by User ID
        /// </summary>
        public readonly Hash<Snowflake, Channel> DirectMessagesByUserId = new  Hash<Snowflake, Channel>();
        
        /// <summary>
        /// List of all clients that are using this bot client
        /// </summary>
        public readonly List<DiscordClient> Clients = new List<DiscordClient>();
        
        /// <summary>
        /// Application reference for this bot
        /// </summary>
        public Application Application { get; internal set; }
        
        /// <summary>
        /// Rest handler for all discord API calls
        /// </summary>
        public RestHandler Rest { get; private set; }
        
        private Socket _webSocket;
        private Timer _timer;
        private readonly ILogger _logger;
        
        internal Ready ReadyData;
        
        /// <summary>
        /// Creates a new bot client for the given settings
        /// </summary>
        /// <param name="settings"></param>
        public BotClient(DiscordSettings settings)
        {
            Settings = new DiscordSettings
            {
                ApiToken = settings.ApiToken,
                LogLevel = settings.LogLevel,
                Intents = settings.Intents
            };

            _logger = new Logger(Settings.LogLevel);
        }
        
        /// <summary>
        /// Gets or creates a new bot client for the given discord client
        /// </summary>
        /// <param name="client">Client to use for creating / loading the bot client</param>
        /// <returns>Bot client that is created or already exists</returns>
        public static BotClient GetOrCreate(DiscordClient client)
        {
            BotClient bot = ActiveBots[client.Settings.ApiToken];
            if (bot == null)
            {
                DiscordExtension.GlobalLogger.Debug($"{nameof(BotClient)}.{nameof(GetOrCreate)} Creating new BotClient");
                bot = new BotClient(client.Settings);
                ActiveBots[client.Settings.ApiToken] = bot;
            }
            
            bot.AddClient(client);
            return bot;
        }
        
        private void Connect()
        {
            if (Initialized)
            {
                throw new Exception("Bot Client already initialized");
            }

            Initialized = true;
            
            Rest = new RestHandler(this, _logger);
            _webSocket = new Socket(this, _logger);

            ConnectWebSocket();
        }
        
        /// <summary>
        /// Connects the websocket to discord. Should only be called if the websocket is disconnected
        /// </summary>
        public void ConnectWebSocket()
        {
            if (Initialized)
            {
                _logger.Debug($"{nameof(BotClient)}.{nameof(ConnectWebSocket)} Connecting to websocket");
                _webSocket.Connect();
            }
        }
        
        /// <summary>
        /// Close the websocket with discord
        /// </summary>
        /// <param name="attemptReconnect">Should we attempt to reconnect to discord after closing</param>
        /// <param name="attemptResume">Should we attempt to resume the previous session</param>
        public void DisconnectWebsocket(bool attemptReconnect = false, bool attemptResume = false)
        {
            if (Initialized)
            {
                _webSocket.Disconnect(attemptReconnect, attemptResume);
            }
        }

        /// <summary>
        /// Called when bot client is no longer used by any client and can be shutdown.
        /// </summary>
        public void ShutdownBot()
        {
            _logger.Debug($"{nameof(BotClient)}.{nameof(ShutdownBot)} Shutting down the bot");
            ActiveBots.Remove(Settings.ApiToken);
            Initialized = false;
            _webSocket.Shutdown();
            _webSocket = null;
            DestroyHeartbeat();
            Rest?.Shutdown();
            Rest = null;
            ReadyData = null;
        }
        
        /// <summary>
        /// Add a client to this bot client
        /// </summary>
        /// <param name="client">Client to add to the bot</param>
        public void AddClient(DiscordClient client)
        {
            if (Settings.ApiToken != client.Settings.ApiToken)
            {
                throw new Exception("Failed to add client to bot client as ApiTokens do not match");
            }
            
            Clients.RemoveAll(c => c == client);
            Clients.Add(client);
            
            _logger.Debug($"{nameof(BotClient)}.{nameof(AddClient)} Add client for plugin {client.Owner.Title}");
            
            if (Clients.Count == 1)
            {
                _logger.Debug($"{nameof(BotClient)}.{nameof(AddClient)} Clients.Count == 1 connecting bot");
                Connect();
            }
            else
            {
                if (client.Settings.LogLevel < Settings.LogLevel)
                {
                    UpdateLogLevel(client.Settings.LogLevel);
                }

                //Our intents have changed. Disconnect websocket and reconnect with new intents.
                BotIntents intents = Settings.Intents | client.Settings.Intents;
                if (intents != Settings.Intents)
                {
                    Settings.Intents = intents;
                    DisconnectWebsocket(true);
                    return;
                }
            }

            if (ReadyData != null)
            {
                ReadyData.Guilds = Servers.Values.ToList();
                client.CallHook("Discord_Ready", null, ReadyData, true);
            }
        }

        /// <summary>
        /// Remove a client from the bot client
        /// If not clients are left bot will shutdown
        /// </summary>
        /// <param name="client">Client to remove from bot client</param>
        public void RemoveClient(DiscordClient client)
        {
            Clients.Remove(client);
            _logger.Debug($"{nameof(BotClient)}.{nameof(RemoveClient)} Client Removed");
            if (Clients.Count == 0)
            {
                ShutdownBot();
                _logger.Debug($"{nameof(BotClient)}.{nameof(RemoveClient)} Bot count 0 shutting down bot");
                return;
            }

            LogLevel level = Clients.Min(c => c.Settings.LogLevel);
            if (level > Settings.LogLevel)
            {
                UpdateLogLevel(level);
            }

            BotIntents intents = BotIntents.None;
            foreach (DiscordClient exitingClients in Clients)
            {
                intents |= exitingClients.Settings.Intents;
            }

            //Our intents have changed. Disconnect websocket and reconnect with new intents.
            if (intents != Settings.Intents)
            {
                Settings.Intents = intents;
                DisconnectWebsocket(true);
            }
        }
        
        private void UpdateLogLevel(LogLevel level)
        {
            _logger.Debug($"{nameof(BotClient)}.{nameof(UpdateLogLevel)} Updating log level from:{Settings.LogLevel} to: {level}");
            Settings.LogLevel = level;
            _logger.UpdateLogLevel(level);
        }

        /// <summary>
        /// Call a hook on all clients using this bot
        /// </summary>
        /// <param name="hookName">Hook to call</param>
        /// <param name="args">Args for the hook</param>
        public void CallHook(string hookName, params object[] args)
        {
            foreach (DiscordClient client in Clients)
            {
                client.CallHook(hookName, args);
            }
        }
        
        #region Heartbeat
        /// <summary>
        /// Setup a heartbeat for this bot with the given interval
        /// </summary>
        /// <param name="heartbeatInterval"></param>
        internal void SetupHeartbeat(float heartbeatInterval)
        {
            if (_timer != null)
            {
                _logger.Debug($"{nameof(DiscordClient)}.{nameof(SetupHeartbeat)} Previous heartbeat timer exists.");
                DestroyHeartbeat();
            }

            HeartbeatAcknowledged = true;
            _timer = new Timer(heartbeatInterval);
            _timer.Elapsed += HeartbeatElapsed;
            _timer.Start();
            _logger.Debug($"{nameof(DiscordClient)}.{nameof(SetupHeartbeat)} Creating heartbeat with interval {heartbeatInterval}ms.");
        }

        /// <summary>
        /// Destroy the heartbeat on this bot
        /// </summary>
        public void DestroyHeartbeat()
        {
            if(_timer != null)
            {
                _logger.Debug($"{nameof(DiscordClient)}.{nameof(DestroyHeartbeat)} Destroy Heartbeat");
                _timer.Dispose();
                _timer = null;
            }
        }

        private void HeartbeatElapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} heartbeat Elapsed");
            if (!_webSocket.IsAlive() && !_webSocket.IsConnecting())
            {
                if (!_webSocket.IsReconnectTimerActive())
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Websocket is offline and is NOT connecting. Start reconnect timer.");
                    _webSocket.StartReconnectTimer(1f, () => UpdateGatewayUrl(ConnectWebSocket));
                }
                else
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Websocket is offline and is waiting to connect.");
                }

                return;
            }

            SendHeartbeat();
        }
        
        /// <summary>
        /// Sends a heartbeat to discord.
        /// If the previous heartbeat wasn't acknowledged then we will attempt to reconnect
        /// </summary>
        public void SendHeartbeat()
        {
            if(!HeartbeatAcknowledged)
            {
                //Discord did not acknowledge our last sent heartbeat. This is a zombie connection we should reconnect.
                if (_webSocket.IsAlive())
                {
                    _webSocket.Disconnect(true, true, true);
                }
                else if (!_webSocket.IsReconnectTimerActive())
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and bot is not online or connecting.");
                    _webSocket.StartReconnectTimer(1f, ConnectWebSocket);
                }
                else
                {
                    _logger.Debug($"{nameof(DiscordClient)}.{nameof(HeartbeatElapsed)} Heartbeat Elapsed and bot is not online but is waiting to connect.");
                }
                
                return;
            }
            
            HeartbeatAcknowledged = false;
            _webSocket.Send(GatewayCommandCode.Heartbeat, Sequence);
            CallHook("DiscordSocket_HeartbeatSent");
            _logger.Debug($"Heartbeat sent - {_timer.Interval}ms interval.");
        }
        #endregion
        
        internal void UpdateGatewayUrl(Action callback)
        {
            Gateway.GetGateway(this, gateway =>
            {
                // Example: wss://gateway.discord.gg/?v=6&encoding=json
                Gateway.WebsocketUrl = $"{gateway.Url}/?{Entities.Gatway.Connect.Serialize()}";
                _logger.Debug($"Got Gateway url: {gateway.Url}");
                callback.Invoke();
            });
        }
        
        /// <summary>
        /// Used to Identify the bot with discord
        /// </summary>
        internal void Identify()
        {
            // Sent immediately after connecting. Opcode 2: Identify
            // Ref: https://discordapp.com/developers/docs/topics/gateway#identifying

            if (!Initialized)
            {
                return;
            }
            
            Identify identify = new Identify
            {
                Token = Settings.ApiToken,
                Properties = new Properties
                {
                    OS = "Oxide.Ext.Discord",
                    Browser = "Oxide.Ext.Discord",
                    Device = "Oxide.Ext.Discord"
                },
                Intents = Settings.Intents,
                Compress = false,
                LargeThreshold = 50,
                Shard = new List<int> { 0, 1 }
            };
            
            _webSocket.Send(GatewayCommandCode.Identify, identify);
        }
        
        /// <summary>
        /// Used to resume the current session with discord
        /// </summary>
        internal void Resume()
        {
            if (!Initialized)
            {
                return;
            }
            
            Resume resume = new Resume
            {
                Sequence = Sequence,
                SessionId = SessionId,
                Token = Settings.ApiToken
            };

            _webSocket.Send(GatewayCommandCode.Resume, resume);
        }
        
        /// <summary>
        /// Used to request guild members from discord for a specific guild
        /// </summary>
        /// <param name="request">Request for guild members</param>
        public void RequestGuildMembers(GuildMembersRequest request)
        {
            if (!Initialized)
            {
                return;
            }

            _webSocket.Send(GatewayCommandCode.RequestGuildMembers, request);
        }

        /// <summary>
        /// Used to update the voice state for the bot
        /// </summary>
        /// <param name="voiceState"></param>
        public void UpdateVoiceState(VoiceStateUpdate voiceState)
        {
            if (!Initialized)
            {
                return;
            }

            _webSocket.Send(GatewayCommandCode.VoiceStateUpdate, voiceState);
        }

        /// <summary>
        /// Used to update the bots status in discord
        /// </summary>
        /// <param name="statusUpdate"></param>
        public void UpdateStatus(StatusUpdate statusUpdate)
        {
            if (!Initialized)
            {
                return;
            }
            
            _webSocket.Send(GatewayCommandCode.StatusUpdate, statusUpdate);
        }

        /// <summary>
        /// Returns a guild for the specific ID
        /// </summary>
        /// <param name="id">ID of the guild</param>
        /// <returns>Guild with the specified ID</returns>
        public Guild GetGuild(Snowflake id)
        {
            return Servers[id];
        }

        /// <summary>
        /// Adds a guild to the list of servers a bot is in
        /// </summary>
        /// <param name="guild"></param>
        public void AddGuild(Guild guild)
        {
            Servers[guild.Id] = guild;
        }
        
        /// <summary>
        /// Adds a guild if it does not exist or updates the guild with
        /// </summary>
        /// <param name="guild"></param>
        public void AddGuildOrUpdate(Guild guild)
        {
            Guild existing = Servers[guild.Id];
            if (existing != null)
            {
                _logger.Verbose($"{nameof(BotClient)}.{nameof(AddGuildOrUpdate)} Updating Existing Guild {guild.Id}");
                existing.Update(guild);
            }
            else
            {
                _logger.Verbose($"{nameof(BotClient)}.{nameof(AddGuildOrUpdate)} Adding new Guild {guild.Id}");
                Servers[guild.Id] = guild;
            }
        }
        
        /// <summary>
        /// Removes guild from the list of servers a bot is in
        /// </summary>
        /// <param name="guildId">Guild to remove from bot</param>
        internal void RemoveGuild(Snowflake guildId)
        {
            Servers.Remove(guildId);
        }

        internal bool IsPluginRegistered(Plugin plugin)
        {
            return Clients.Any(t => t.Owner == plugin);
        }
    }
}