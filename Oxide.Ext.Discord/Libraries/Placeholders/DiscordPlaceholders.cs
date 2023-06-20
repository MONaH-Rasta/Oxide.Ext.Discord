using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Libraries.Placeholders.Callbacks;
using Oxide.Ext.Discord.Libraries.Placeholders.Default;
using Oxide.Ext.Discord.Libraries.Pooling;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins.Core;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries.Placeholders
{
    /// <summary>
    /// Discord Placeholders Library
    /// </summary>
    public class DiscordPlaceholders : BaseDiscordLibrary<DiscordPlaceholders>
    {
        private readonly Regex _placeholderRegex = new Regex(@"{([^\d][^:{}""]+)(?::([^{}""]+))*?}", RegexOptions.Compiled);
        private readonly Hash<string, IPlaceholder> _placeholders = new Hash<string, IPlaceholder>();
        private readonly Hash<string, IPlaceholder> _internalPlaceholders = new Hash<string, IPlaceholder>();
        private readonly Covalence _covalence = Interface.Oxide.GetLibrary<Covalence>();
        private readonly ILogger _logger;
        
        internal DiscordPlaceholders(ILogger logger)
        {
            _logger = logger;
        }

        internal void RegisterPlaceholders()
        {
            ChannelPlaceholders.RegisterPlaceholders();
            GuildPlaceholders.RegisterPlaceholders();
            InteractionPlaceholders.RegisterPlaceholders();
            ServerPlaceholders.RegisterPlaceholders();
            MemberPlaceholders.RegisterPlaceholders();
            MessagePlaceholders.RegisterPlaceholders();
            PlayerPlaceholders.RegisterPlaceholders();
            PluginPlaceholders.RegisterPlaceholders();
            RolePlaceholders.RegisterPlaceholders();
            TimestampPlaceholders.RegisterPlaceholders();
            UserPlaceholders.RegisterPlaceholders();
            ApplicationCommandPlaceholders.RegisterPlaceholders();
            RequestErrorPlaceholders.RegisterPlaceholders();
            SnowflakePlaceholders.RegisterPlaceholders();
        }

        internal IEnumerable<KeyValuePair<string, IPlaceholder>> GetPlaceholders()
        {
            foreach (KeyValuePair<string, IPlaceholder> placeholder in _placeholders)
            {
                yield return placeholder;
            }
        }

        /// <summary>
        /// Process placeholders for the given Text
        /// </summary>
        /// <param name="text">Text to process placeholders for</param>
        /// <param name="data">Placeholder Data for the placeholders</param>
        /// <returns>string with placeholders replaced. If no placeholders are found the original string is returned</returns>
        public string ProcessPlaceholders(string text, PlaceholderData data)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            
            if (data == null) throw new ArgumentNullException(nameof(data));
            
            MatchCollection matches = _placeholderRegex.Matches(text);
            if (matches.Count != 0)
            {
                StringBuilder builder = DiscordPool.Internal.GetStringBuilder();
                builder.Append(text);
                PlaceholderState state = PlaceholderState.Create(data);
                bool hasNonMatchingPlaceholder = false;
                for (int index = matches.Count - 1; index >= 0; index--)
                {
                    Match match = matches[index];
                    state.UpdateState(match);
                    IPlaceholder placeholder = _placeholders[state.Name];
                    if (placeholder == null)
                    {
                        hasNonMatchingPlaceholder = true;
                        if (_logger.IsLogging(DiscordLogLevel.Debug))
                        {
                            _logger.Debug("Failed to find placeholder: '{0}' Format: {1}", state.Name, state.Format);
                        }
                        continue;
                    }

                    if (_logger.IsLogging(DiscordLogLevel.Debug))
                    {
                        _logger.Debug("Invoking placeholder: '{0}' Format: {1}", state.Name, state.Format);
                    }
                    
                    placeholder.Invoke(builder, state);
                }

                if (hasNonMatchingPlaceholder)
                {
                    DiscordExtensionCore.Instance.GetReplacer()?.Invoke(data.Get<IPlayer>(), builder, true);
                }

                text = builder.ToString();
                DiscordPool.Internal.FreeStringBuilder(builder);
                state.Dispose();
            }

            if (data.AutoPool)
            {
                data.Dispose();
            }

            return text;
        }

        /// <summary>
        /// Creates Pooled <see cref="PlaceholderData"/>
        /// </summary>
        /// <returns><see cref="PlaceholderData"/></returns>
        public PlaceholderData CreateData(Plugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            
            PlaceholderData data = DiscordPool.Instance.GetOrCreate(plugin).GetPlaceholderData();
            data.AddServer(_covalence.Server);
            data.AddPlugin(plugin);
            return data;
        }

        /// <summary>
        /// Registers a placeholder static value placeholder
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="value">Static string value</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterPlaceholder(Plugin plugin, string placeholder, string value)
        {
            if (string.IsNullOrEmpty(placeholder)) throw new ArgumentNullException(nameof(placeholder));
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (value == null) throw new ArgumentNullException(nameof(value));
            
            StaticPlaceholder holder = new StaticPlaceholder(plugin, value);
            IPlaceholder existing = _placeholders[placeholder];
            if (existing != null && !existing.IsExtensionPlaceholder && !existing.IsForPlugin(plugin))
            {
                _logger.Warning("Plugin {0} has replaced placeholder '{1}' previously registered by plugin {2}", plugin.FullName(), placeholder, existing.PluginName);
            }
            _placeholders[placeholder] = holder;
        }
        
        /// <summary>
        /// Registers a placeholder
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="callback">Callback Method for the placeholder</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterPlaceholder<TResult>(Plugin plugin, string placeholder, Func<TResult> callback)
        {
            if (string.IsNullOrEmpty(placeholder)) throw new ArgumentNullException(nameof(placeholder));
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (callback == null) throw new ArgumentNullException(nameof(callback));
            
            Placeholder<TResult> holder = new Placeholder<TResult>(plugin, callback);
            IPlaceholder existing = _placeholders[placeholder];
            if (existing != null && !existing.IsExtensionPlaceholder && !existing.IsForPlugin(plugin))
            {
                _logger.Warning("Plugin {0} has replaced placeholder '{1}' previously registered by plugin {2}", plugin.FullName(), placeholder, existing.PluginName);
            }
            
            _placeholders[placeholder] = holder;
        }

        
        /// <summary>
        /// Registers a placeholder that uses the dataKey value
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="dataKey"></param>
        /// <typeparam name="TData">Type that is registered in the PlaceholderData</typeparam>
        /// <exception cref="ArgumentNullException">Thrown if placeholder or plugin is null</exception>
        public void RegisterPlaceholder<TData>(Plugin plugin, string placeholder, string dataKey)
        {
            if (string.IsNullOrEmpty(placeholder)) throw new ArgumentNullException(nameof(placeholder));
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));

            Placeholder<TData, TData> holder = new Placeholder<TData, TData>(dataKey, plugin, data => data);
            if (!holder.IsExtensionPlaceholder && !_internalPlaceholders.ContainsKey(placeholder) && !placeholder.StartsWith(plugin.Name, StringComparison.OrdinalIgnoreCase))
            {
                _logger.Error("Plugin placeholder {0} must be prefixed with the plugin name {1} unless overriding a Discord Extension provided placeholder.", placeholder, plugin.Name.ToLower());
                return;
            }

            _placeholders[placeholder] = holder;
            if (holder.IsExtensionPlaceholder)
            {
                _internalPlaceholders[placeholder] = holder;
            }
        }

        /// <summary>
        /// Registers a placeholder of type {T}
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="callback">Callback Method for the placeholder</param>
        /// <typeparam name="TData">Type of the data key</typeparam>
        /// <typeparam name="TResult">The return type of the placeholder callback</typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterPlaceholder<TData, TResult>(Plugin plugin, string placeholder, Func<TData, TResult> callback)
        {
            RegisterPlaceholder(plugin, placeholder, typeof(TData).Name, callback);
        }
        
        /// <summary>
        /// Registers a placeholder of type {T}
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="dataKey">The name of the data key in PlaceholderData</param>
        /// <param name="callback">Callback Method for the placeholder</param>
        /// <typeparam name="TData">Type of the data key</typeparam>
        /// <typeparam name="TResult">The return type of the placeholder callback</typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterPlaceholder<TData, TResult>(Plugin plugin, string placeholder, string dataKey, Func<TData, TResult> callback)
        {
            if (string.IsNullOrEmpty(placeholder)) throw new ArgumentNullException(nameof(placeholder));
            if (string.IsNullOrEmpty(dataKey)) throw new ArgumentNullException(nameof(dataKey));
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (callback == null) throw new ArgumentNullException(nameof(callback));
            
            Placeholder<TData, TResult> holder = new Placeholder<TData, TResult>(dataKey, plugin, callback);
            if (!holder.IsExtensionPlaceholder && !_internalPlaceholders.ContainsKey(placeholder) && !placeholder.StartsWith(plugin.Name, StringComparison.OrdinalIgnoreCase))
            {
                _logger.Error("Plugin placeholder {0} must be prefixed with the plugin name {1} unless overriding a Discord Extension provided placeholder.", placeholder, plugin.Name.ToLower());
                return;
            }

            _placeholders[placeholder] = holder;
            if (holder.IsExtensionPlaceholder)
            {
                _internalPlaceholders[placeholder] = holder;
            }
        }
        
        /// <summary>
        /// Registers a placeholder of type {T}
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="callback">Callback Method for the placeholder</param>
        /// <typeparam name="TData">Type of the data key</typeparam>
        /// <typeparam name="TResult">The return type of the placeholder callback</typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterPlaceholder<TData, TResult>(Plugin plugin, string placeholder, Func<PlaceholderState, TData, TResult> callback)
        {
            RegisterPlaceholder(plugin, placeholder, typeof(TData).Name, callback);
        }
        
        /// <summary>
        /// Registers a placeholder of type {T}
        /// </summary>
        /// <param name="plugin">Plugin this placeholder is for</param>
        /// <param name="placeholder">Placeholder string</param>
        /// <param name="dataKey">The name of the data key in PlaceholderData</param>
        /// <param name="callback">Callback Method for the placeholder</param>
        /// <typeparam name="TData">Type of the data key</typeparam>
        /// <typeparam name="TResult">The return type of the placeholder callback</typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void RegisterPlaceholder<TData, TResult>(Plugin plugin, string placeholder, string dataKey, Func<PlaceholderState, TData, TResult> callback)
        {
            if (string.IsNullOrEmpty(placeholder)) throw new ArgumentNullException(nameof(placeholder));
            if (string.IsNullOrEmpty(dataKey)) throw new ArgumentNullException(nameof(dataKey));
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (callback == null) throw new ArgumentNullException(nameof(callback));
            
            Placeholder<TData, TResult> holder = new Placeholder<TData, TResult>(dataKey, plugin, callback);
            if (!holder.IsExtensionPlaceholder && !_internalPlaceholders.ContainsKey(placeholder) && !placeholder.StartsWith(plugin.Name, StringComparison.OrdinalIgnoreCase))
            {
                _logger.Error("Plugin placeholder {0} must be prefixed with the plugin name {1} unless overriding a Discord Extension provided placeholder.", placeholder, plugin.Name.ToLower());
                return;
            }

            _placeholders[placeholder] = holder;
            if (holder.IsExtensionPlaceholder)
            {
                _internalPlaceholders[placeholder] = holder;
            }
        }

        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            _placeholders.RemoveAll(p => p.IsForPlugin(plugin));
            foreach (KeyValuePair<string, IPlaceholder> placeholder in _internalPlaceholders)
            {
                if (!_placeholders.ContainsKey(placeholder.Key))
                {
                    _placeholders[placeholder.Key] = placeholder.Value;
                }
            }
        }
    }
}