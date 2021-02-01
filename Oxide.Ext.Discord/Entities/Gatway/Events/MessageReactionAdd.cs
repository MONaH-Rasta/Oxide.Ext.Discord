﻿using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Emojis;
using Oxide.Ext.Discord.Entities.Guilds;

namespace Oxide.Ext.Discord.Entities.Gatway.Events
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#message-reaction-add">Message Reaction Add</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageReactionAdd
    {
        /// <summary>
        /// The id of the user
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the channel
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// The id of the message
        /// </summary>
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        
        /// <summary>
        /// The id of the guild
        /// </summary>
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
        
        /// <summary>
        /// The member who reacted if this happened in a guild
        /// </summary>
        [JsonProperty("member")]
        public GuildMember Member { get; set; }

        /// <summary>
        /// The emoji used to react
        /// </summary>
        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }
}
