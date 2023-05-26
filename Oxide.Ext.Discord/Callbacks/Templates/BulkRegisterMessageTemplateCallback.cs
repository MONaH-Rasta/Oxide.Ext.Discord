using System.Collections.Generic;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Interfaces.Promises;
using Oxide.Ext.Discord.Libraries.Pooling;
using Oxide.Ext.Discord.Libraries.Templates;

namespace Oxide.Ext.Discord.Callbacks.Templates
{
    internal class BulkRegisterTemplateCallback<TTemplate> : BaseAsyncCallback where TTemplate : class
    {
        private BaseTemplateLibrary<TTemplate> _library;
        private TemplateId _id;
        private List<BulkTemplateRegistration<TTemplate>> _templates;
        private TemplateVersion _minVersion;
        private IPendingPromise _promise;
        
        public static void Start(BaseTemplateLibrary<TTemplate> library, TemplateId id, List<BulkTemplateRegistration<TTemplate>> templates, TemplateVersion minVersion, IPendingPromise promise)
        {
            BulkRegisterTemplateCallback<TTemplate> register = DiscordPool.Internal.Get<BulkRegisterTemplateCallback<TTemplate>>();
            register.Init(library, id, templates, minVersion, promise);
            register.Run();
        }
        
        private void Init(BaseTemplateLibrary<TTemplate> library, TemplateId id, List<BulkTemplateRegistration<TTemplate>> templates, TemplateVersion minVersion, IPendingPromise promise)
        {
            _library = library;
            _id = id;
            _templates = templates;
            _minVersion = minVersion;
            _promise = promise;
        }

        protected override Task HandleCallback()
        {
            _library.HandleBulkRegisterTemplate(_id, _templates, _minVersion, _promise);
            return Task.CompletedTask;
        }
        
        protected override string GetExceptionMessage()
        {
            return $"Template ID: {_id.ToString()}  Type: {_library.GetType().Name}";
        }

        protected override void EnterPool()
        {
            _library = null;
            _id = default(TemplateId);
            _templates = null;
            _minVersion = default(TemplateVersion);
            _promise = null;
        }
    }
}