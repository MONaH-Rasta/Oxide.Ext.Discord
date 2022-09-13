using System;
using System.IO;
using System.Threading.Tasks;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks.Async;
using Oxide.Ext.Discord.Callbacks.Templates;
using Oxide.Ext.Discord.Callbacks.Templates.Messages;
using Oxide.Ext.Discord.Entities.Interactions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces.Callbacks.Async;
using Oxide.Ext.Discord.Libraries.Langs;
using Oxide.Ext.Discord.Logging;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries.Templates.Messages
{
    /// <summary>
    /// Library for Discord Message templates
    /// </summary>
    public class DiscordMessageTemplates : BaseTemplateLibrary
    {
        private readonly Hash<TemplateId, DiscordMessageTemplate> _templateCache = new Hash<TemplateId, DiscordMessageTemplate>();

        internal DiscordMessageTemplates(ILogger logger) : base(Path.Combine(Interface.Oxide.InstanceDirectory, "discord", "templates"), logger) { }
        
        /// <summary>
        /// Registers a global message template
        /// Global Message templates cannot be localized
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="name">Unique name of the template</param>
        /// <param name="template">Template to register</param>
        /// <param name="minVersion">Min supported version for this template</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IDiscordAsyncCallback RegisterGlobalMessageTemplate(Plugin plugin, string name, DiscordMessageTemplate template, TemplateVersion minVersion)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (template == null) throw new ArgumentNullException(nameof(template));

            IDiscordAsyncCallback callback = PluginAsyncCallback.Create();
            
            TemplateId id = new TemplateId(plugin, name, null);
            RegisterTemplateCallback<DiscordMessageTemplate>.Start(this, id, template, minVersion, callback);
            return callback;
        }
        
        /// <summary>
        /// Registers a message template with the given name and language
        /// </summary>
        /// <param name="plugin">Plugin the <see cref="DiscordMessageTemplate"/> is for</param>
        /// <param name="name">Name of the <see cref="DiscordMessageTemplate"/></param>
        /// <param name="template">Template to be registered</param>
        /// <param name="minVersion">
        /// The minimum supported template version.<br/>
        /// If an existing template exists and it's version is >=  the minimum supported version then we will use that template.<br/>
        /// If an existing template exists and it's version is &lt; the min supported version. The existing version is backed up and a new template is created 
        /// </param>
        /// <param name="language">Language for the template</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IDiscordAsyncCallback RegisterLocalizedMessageTemplate(Plugin plugin, string name, DiscordMessageTemplate template, TemplateVersion minVersion, string language = DiscordLang.DefaultOxideLanguage)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (template == null) throw new ArgumentNullException(nameof(template));
            
            IDiscordAsyncCallback callback = PluginAsyncCallback.Create();

            TemplateId id = new TemplateId(plugin, name, language);
            RegisterTemplateCallback<DiscordMessageTemplate>.Start(this, id, template, minVersion, callback);
            return callback;
        }

        /// <summary>
        /// Returns a message template for a given <see cref="IPlayer"/> player
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="name">Name of the template</param>
        /// <param name="player">IPlayer for the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public IDiscordAsyncCallback<DiscordMessageTemplate> GetMessageTemplateForPlayer(Plugin plugin, string name, IPlayer player)
        {
            string locale = player != null ? DiscordExtension.DiscordLang.GetPlayerLanguage(player) : DiscordExtension.DiscordLang.GameServerLanguage;
            return GetLocalizedMessageTemplate(plugin, name, locale);
        }
        
        /// <summary>
        /// Returns a message template for a given <see cref="IPlayer"/> player ID
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="name">Name of the template</param>
        /// <param name="playerId">PlayerId for the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public IDiscordAsyncCallback<DiscordMessageTemplate> GetMessageTemplateForPlayer(Plugin plugin, string name, string playerId)
        {
            string locale = !string.IsNullOrEmpty(playerId) ? DiscordExtension.DiscordLang.GetPlayerLanguage(playerId) : DiscordExtension.DiscordLang.GameServerLanguage;
            return GetLocalizedMessageTemplate(plugin, name, locale);
        }

        /// <summary>
        /// Returns a global message template for the plugin with the given name
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="name">Name of the template</param>
        /// <returns><see cref="DiscordMessageTemplate"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IDiscordAsyncCallback<DiscordMessageTemplate> GetGlobalMessageTemplate(Plugin plugin, string name)
        {
            return GetGlobalMessageTemplateInternal(plugin, name, PluginAsyncCallback<DiscordMessageTemplate>.Create());
        }

        internal IDiscordAsyncCallback<DiscordMessageTemplate> GetGlobalMessageTemplateInternal(Plugin plugin, string name, IDiscordAsyncCallback<DiscordMessageTemplate> callback = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            
            if (callback == null)
            {
                callback = InternalAsyncCallback<DiscordMessageTemplate>.Create();
            }

            TemplateId id = new TemplateId(plugin, name, null);
            LoadGlobalMessageTemplate.Start(id, callback);
            return callback;
        }
        
        internal async Task HandleGetGlobalMessageTemplate(TemplateId id, IDiscordAsyncCallback<DiscordMessageTemplate> callback)
        {
            DiscordMessageTemplate template = LoadFromCache(id);
            if (template != null)
            {
                callback.InvokeSuccess(template);
                return;
            }
            
            template = await LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id).ConfigureAwait(false);
            
            if (template == null)
            {
                Logger.Warning($"Plugin {{0}} is using the {nameof(DiscordMessageTemplates)}.{nameof(GetGlobalMessageTemplate)} API but message template name '{{1}}' is not registered", id.GetPluginName(), id.TemplateName);
                callback.InvokeSuccess(new DiscordMessageTemplate());
                return;
            }
            
            SetCache(id, template);
            callback.InvokeSuccess(template);
        }
        
        /// <summary>
        /// Returns a message template for a given language
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="name">Name of the template</param>
        /// <param name="language">Oxide language of the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public IDiscordAsyncCallback<DiscordMessageTemplate> GetLocalizedMessageTemplate(Plugin plugin, string name, string language = DiscordLang.DefaultOxideLanguage)
        {
            return GetLocalizedMessageTemplateInternal(plugin, name, language, PluginAsyncCallback<DiscordMessageTemplate>.Create());
        }
        
        internal IDiscordAsyncCallback<DiscordMessageTemplate> GetLocalizedMessageTemplateInternal(Plugin plugin, string name, string language, IDiscordAsyncCallback<DiscordMessageTemplate> callback = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(language)) throw new ArgumentNullException(nameof(language));

            if (callback == null)
            {
                callback = InternalAsyncCallback<DiscordMessageTemplate>.Create();
            }
            
            TemplateId id = new TemplateId(plugin, name, language);
            LoadLocalizedMessageTemplate.Start(id, callback);
            return callback;
        }
        
        internal async Task HandleGetLocalizedMessageTemplate(TemplateId id, IDiscordAsyncCallback<DiscordMessageTemplate> callback)
        {
            DiscordMessageTemplate template = LoadFromCache(id);
            if (template != null)
            {
                callback.InvokeSuccess(template);
                return;
            }
            
            template = await DiscordExtension.DiscordMessageTemplates.LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id).ConfigureAwait(false)
                       ?? await DiscordExtension.DiscordMessageTemplates.LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id, DiscordExtension.DiscordLang.GameServerLanguage).ConfigureAwait(false)
                       ?? await DiscordExtension.DiscordMessageTemplates.LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id, DiscordLang.DefaultOxideLanguage).ConfigureAwait(false);
            
            if (template == null)
            {
                Logger.Warning($"Plugin {{0}} is using the {nameof(DiscordMessageTemplates)}.{nameof(GetLocalizedMessageTemplate)} API but message template name '{{1}}' is not registered", id.GetPluginName(), id.TemplateName);
                callback.InvokeSuccess(new DiscordMessageTemplate());
                return;
            }
            
            SetCache(id, template);
            callback.InvokeSuccess(template);
        }
        
        /// <summary>
        /// Returns a message template for a given language
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="name">Name of the template</param>
        /// <param name="interaction">Interaction to get the template for</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public IDiscordAsyncCallback<DiscordMessageTemplate> GetMessageTemplate(Plugin plugin, string name, DiscordInteraction interaction)
        {
            return GetMessageTemplateInternal(plugin, name, interaction, PluginAsyncCallback<DiscordMessageTemplate>.Create());
        }
        
        internal IDiscordAsyncCallback<DiscordMessageTemplate> GetMessageTemplateInternal(Plugin plugin, string name, DiscordInteraction interaction, IDiscordAsyncCallback<DiscordMessageTemplate> callback = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (callback == null)
            {
                callback = InternalAsyncCallback<DiscordMessageTemplate>.Create();
            }
            
            string language = DiscordExtension.DiscordLang.GetOxideLanguage(interaction.Locale);
            TemplateId id = new TemplateId(plugin, name, language);
            LoadInteractionMessageTemplate.Start(id, interaction, callback);
            return callback;
        }
        
        internal async Task HandleGetMessageTemplate(TemplateId id, DiscordInteraction interaction, IDiscordAsyncCallback<DiscordMessageTemplate> callback)
        {
            DiscordMessageTemplate template = LoadFromCache(id);
            if (template != null)
            {
                callback.InvokeSuccess(template);
                return;
            }
            
            IPlayer player = interaction.User.Player;
            
            template = await LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id).ConfigureAwait(false)
                       ?? (player != null ? await LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id, DiscordExtension.DiscordLang.GetPlayerLanguage(player)).ConfigureAwait(false) : null)
                       ?? await LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id, DiscordExtension.DiscordLang.GetOxideLanguage(interaction.GuildLocale)).ConfigureAwait(false) 
                       ?? await LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id, DiscordExtension.DiscordLang.GameServerLanguage).ConfigureAwait(false)
                       ?? await LoadTemplate<DiscordMessageTemplate>(TemplateType.Message, id, DiscordLang.DefaultOxideLanguage).ConfigureAwait(false);

            
            if (template == null)
            {
                Logger.Warning($"Plugin {{0}} is using the {nameof(DiscordMessageTemplates)}.{nameof(GetMessageTemplate)} API but message template name '{{1}}' is not registered", id.GetPluginName(), id.TemplateName);
                callback.InvokeSuccess(new DiscordMessageTemplate());
                return;
            }
            
            SetCache(id, template);
            callback.InvokeSuccess(template);
        }

        private DiscordMessageTemplate LoadFromCache(TemplateId id) => _templateCache.TryGetValue(id, out DiscordMessageTemplate template) ? template : null;

        private void SetCache(TemplateId id, DiscordMessageTemplate template)
        {
            _templateCache[id] = template;
        }

        internal override void OnPluginUnloaded(Plugin plugin)
        {
            string name = plugin.Name;
            _templateCache.RemoveAll(t => t.PluginName == name);
            RegisteredTemplates.RemoveWhere(rt => rt.PluginName == name);
        }
    }
}