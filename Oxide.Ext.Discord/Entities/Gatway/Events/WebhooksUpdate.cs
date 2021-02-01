﻿using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.Gatway.Events
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#webhooks-update">Webhooks Update</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WebhooksUpdate
    {
        /// <summary>
        /// ID of the guild
        /// </summary>
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        /// <summary>
        /// ID of the channel
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
