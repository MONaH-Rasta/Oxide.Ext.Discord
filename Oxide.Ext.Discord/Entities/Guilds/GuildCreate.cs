using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Channels;
using Oxide.Ext.Discord.Entities.Roles;

namespace Oxide.Ext.Discord.Entities.Guilds
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#create-guild">Create Guild Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildCreate
    {
        /// <summary>
        /// Name of the guild (2-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Voice region id
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
        
        /// <summary>
        /// Base64 128x128 image for the guild icon
        /// </summary>
        [JsonProperty("icon")]        
        public string Icon { get; set; }
             
        /// <summary>
        /// Verification level
        /// </summary>
        [JsonProperty("verification_level")]
        public GuildVerificationLevel? VerificationLevel { get; set; }
                
        /// <summary>
        /// Default message notification level
        /// </summary>
        [JsonProperty("default_message_notifications")]
        public DefaultMessageNotificationLevel? DefaultMessageNotifications { get; set; }
             
        /// <summary>
        /// Explicit content filter level
        /// </summary>
        [JsonProperty("explicit_content_filter")]
        public ExplicitContentFilterLevel? ExplicitContentFilter { get; set; }
             
        /// <summary>
        /// Roles in the guild
        /// </summary>
        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }
             
        /// <summary>
        /// Channels in the guild
        /// </summary>
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
             
        /// <summary>
        /// ID of afk channel
        /// </summary>
        [JsonProperty("afk_channel_id")]
        public string AfkChannelId { get; set; }
              
        /// <summary>
        /// Afk timeout in seconds
        /// </summary>
        [JsonProperty("afk_timeout")]
        public int? AfkTimeout { get; set; }
             
        /// <summary>
        /// The id of the channel where guild notices such as welcome messages and boost events are posted
        /// </summary>
        [JsonProperty("system_channel_id")]
        public string SystemChannelId { get; set; }
    }
}