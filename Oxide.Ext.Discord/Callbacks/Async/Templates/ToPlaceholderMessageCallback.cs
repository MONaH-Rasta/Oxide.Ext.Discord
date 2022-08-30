using System.Threading.Tasks;
using Oxide.Ext.Discord.Interfaces.Entities.Messages;
using Oxide.Ext.Discord.Libraries.Placeholders;
using Oxide.Ext.Discord.Libraries.Templates.Messages;
using Oxide.Ext.Discord.Pooling;

namespace Oxide.Ext.Discord.Callbacks.Async.Templates
{
    public class ToPlaceholderMessageCallback<T> : BaseAsyncPoolableCallback where T : class, IDiscordTemplateMessage, new()
    {
        private DiscordMessageTemplate _template;
        private PlaceholderData _data;
        private T _message;
        private DiscordAsyncCallback<T> _callback;

        public static ToPlaceholderMessageCallback<T> Create(DiscordMessageTemplate template, PlaceholderData data, T message, DiscordAsyncCallback<T> callback)
        {
            ToPlaceholderMessageCallback<T> handler = DiscordPool.Get<ToPlaceholderMessageCallback<T>>();
            handler.Init(template, data, message, callback);
            return handler;
        }
        
        private void Init(DiscordMessageTemplate template, PlaceholderData data, T message, DiscordAsyncCallback<T> callback)
        {
            _template = template;
            _data = data;
            _message = message;
            _callback = callback;
        }
        
        protected override async Task HandleCallback()
        {
            _message = await _template.ToPlaceholderMessageInternalAsync(_data, _message).ConfigureAwait(false);
            _callback.InvokeSuccess(_message);
        }

        protected override void EnterPool()
        {
            _template = null;
            _data = null;
            _message = null;
            _callback = null;
        }

        protected override void DisposeInternal()
        {
            DiscordPool.Free(this);
        }
    }
}