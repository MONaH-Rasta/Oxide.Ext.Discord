using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/slash-commands#create-global-application-command-json-params">Application Command Create</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ApplicationCommandCreate
    {
        /// <summary>
        /// Command name (3-32 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Description of the command (1-100 characters)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// The parameters for the command
        /// See <see cref="ApplicationCommandOption"/>
        /// </summary>
        [JsonProperty("options")]
        public List<ApplicationCommandOption> Options { get; set; }
    }
}