﻿using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities.Guilds
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#modify-guild-channel-positions">Modify Guild Channel Position</a>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#modify-guild-role-positions">Modify Guild Role Position</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ObjectPosition
    {
        /// <summary>
        /// ID of the channel or role
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }

        /// <summary>
        /// New position for the role / channel
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }
    }
}