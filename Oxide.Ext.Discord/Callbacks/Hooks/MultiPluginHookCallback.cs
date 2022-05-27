using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Pooling;

namespace Oxide.Ext.Discord.Callbacks.Hooks
{
    internal class MultiPluginHookCallback : BaseHookCallback
    {
        private List<Plugin> _plugins;

        public void Init(List<Plugin> plugins, string hook, object[] args)
        {
            base.Init(hook, args);
            _plugins = plugins;
        }

        protected override void HandleCallback()
        {
            for (int index = 0; index < _plugins.Count; index++)
            {
                Plugin plugin = _plugins[index];
                plugin.CallHook(Hook, Args);
            }
        }
        
        ///<inheritdoc/>
        protected override void DisposeInternal()
        {
            DiscordPool.Free(this);
        }

        protected override void EnterPool()
        {
            base.EnterPool();
            ArrayPool.Free(Args);
            _plugins = null;
        }
    }
}