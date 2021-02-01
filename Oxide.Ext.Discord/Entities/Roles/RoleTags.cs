using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.Roles
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/permissions#role-object-role-tags-structure">Role Tags Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RoleTags
    {
        /// <summary>
        /// The id of the bot this role belongs to
        /// </summary>
        [JsonProperty("bot_id")]
        public string BotId { get; set; }
        
        /// <summary>
        /// The id of the integration this role belongs to
        /// </summary>
        [JsonProperty("integration_id")]
        public string IntegrationId { get; set; }
        
        /// <summary>
        /// Whether this is the guild's premium subscriber role
        /// </summary>
        [JsonProperty("premium_subscriber")]
        public bool PremiumSubscriber { get; set; }
    }
}