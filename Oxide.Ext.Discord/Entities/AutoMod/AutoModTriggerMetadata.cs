using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.AutoMod
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-trigger-metadata">Auto Mod Trigger Metadata</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AutoModTriggerMetadata
    {
        /// <summary>
        /// Associated Trigger Types: <see cref="AutoModTriggerType.Keyword"/>
        /// Substrings which will be searched for in content
        /// </summary>
        [JsonProperty("keyword_filter")]
        public List<string> KeywordFilter { get; set; }
        
        /// <summary>
        /// Associated Trigger Types: <see cref="AutoModTriggerType.Keyword"/>
        /// Regular expression patterns which will be matched against content (Maximum of 10)
        /// * Only Rust flavored regex is currently supported, which can be tested in online editors such as <a href="https://rustexp.lpil.uk/">Rustexp</a>. Each regex pattern must be 75 characters or less.
        /// </summary>
        [JsonProperty("regex_patterns")]
        public List<string> RegexPatterns { get; set; }
        
        /// <summary>
        /// Associated Trigger Types: <see cref="AutoModTriggerType.KeywordPreset"/>
        /// The internally pre-defined wordsets which will be searched for in content
        /// </summary>
        [JsonProperty("presets")]
        public List<AutoModKeywordPresetType> Presets { get; set; }
        
        /// <summary>
        /// Associated Trigger Types: <see cref="AutoModTriggerType.KeywordPreset"/>
        /// Substrings which will be exempt from triggering the preset trigger type
        /// </summary>
        [JsonProperty("allow_list")]
        public List<string> AllowList { get; set; }
        
        /// <summary>
        /// Associated Trigger Types: <see cref="AutoModTriggerType.MentionSpam"/>
        /// Total number of unique role and user mentions allowed per message
        /// Maximum of 50
        /// </summary>
        [JsonProperty("mention_total_limit")]
        public int MentionTotalLimit { get; set; }
    }
}