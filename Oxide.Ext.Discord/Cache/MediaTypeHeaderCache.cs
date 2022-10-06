using System.Net.Http.Headers;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Singleton;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Cache
{
    internal class MediaTypeHeaderCache : Singleton<MediaTypeHeaderCache>
    {
        private static readonly Hash<string, MediaTypeHeaderValue> Cache = new Hash<string, MediaTypeHeaderValue>();
        private const string JsonHeader = "application/json";

        public MediaTypeHeaderCache()
        {
            MediaTypeHeaderValue header = MediaTypeHeaderValue.Parse(JsonHeader);
            header.CharSet = DiscordEncoding.Encoding.WebName;
            Cache[JsonHeader] = header;
        }

        public MediaTypeHeaderValue Get(string value)
        {
            MediaTypeHeaderValue header = Cache[value];
            if (header == null)
            {
                header = MediaTypeHeaderValue.Parse(value);
                Cache[value] = header;
            }

            return header;
        }
    }
}