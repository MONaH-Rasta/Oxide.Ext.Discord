using System.Threading.Tasks;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Libraries.Templates;
using Oxide.Ext.Discord.Libraries.Templates.Messages;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Pooling;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Callbacks.Async.Templates
{
    internal class LoadGlobalMessageTemplate : BaseAsyncPoolableCallback
    {
        private readonly DiscordTemplates _templates = DiscordExtension.DiscordTemplates;
        private Plugin _plugin;
        private string _name;
        private DiscordAsyncCallback<DiscordMessageTemplate> _callback;
        private ILogger _logger;

        public static LoadGlobalMessageTemplate Create(Plugin plugin, string name, DiscordAsyncCallback<DiscordMessageTemplate> callback, ILogger logger)
        {
            LoadGlobalMessageTemplate load = DiscordPool.Get<LoadGlobalMessageTemplate>();
            load.Init(plugin, name, callback, logger);
            return load;
        }

        private void Init(Plugin plugin, string name, DiscordAsyncCallback<DiscordMessageTemplate> callback, ILogger logger)
        {
            _plugin = plugin;
            _name = name;
            _callback = callback;
            _logger = logger;
        }

        protected override async Task HandleCallback()
        {
            Hash<TemplateId, DiscordMessageTemplate> pluginTemplates =  _templates.TemplateCache[_plugin.Name];
            if (pluginTemplates == null)
            {
                pluginTemplates = new Hash<TemplateId, DiscordMessageTemplate>();
                _templates.TemplateCache[_plugin.Name] = pluginTemplates;
            }

            TemplateId templateId = new TemplateId(_name, null);
            if (pluginTemplates.TryGetValue(templateId, out DiscordMessageTemplate template))
            {
                _callback.InvokeSuccess(template);
                return;
            }

            template = await _templates.LoadTemplate(_plugin, _name, null).ConfigureAwait(false);
            
            if (template == null)
            {
                _logger.Warning($"Plugin {{0}} is using the {nameof(DiscordTemplates)}.{nameof(DiscordTemplates.GetGlobalMessageTemplate)} API but message template name '{{1}}' is not registered", _plugin.FullName(), _name);
                _callback.InvokeSuccess(new DiscordMessageTemplate());
                return;
            }
            
            pluginTemplates[templateId] = template;
            _callback.InvokeSuccess(template);
        }

        protected override void EnterPool()
        {
            _plugin = null;
            _name = null;
            _callback = null;
            _logger = null;
        }

        protected override void DisposeInternal()
        {
            _callback?.Dispose();
            DiscordPool.Free(this);
        }
    }
}