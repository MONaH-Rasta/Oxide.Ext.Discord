﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Integrations;

namespace Oxide.Ext.Discord.Entities.Users.Connections
{
    /// <summary>
    /// Represents a Discord Users <a href="https://discord.com/developers/docs/resources/user#connection-object">Connection</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Connection
    {
        /// <summary>
        /// ID of the connection account
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The username of the connection account
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The service of the connection (twitch, youtube)
        /// <see cref="ConnectionType"/>
        /// </summary>
        [JsonProperty("type")]
        public ConnectionType Type { get; set; }

        /// <summary>
        /// Whether the connection is revoked
        /// </summary>
        [JsonProperty("revoked")]
        public bool? Revoked { get; set; }

        /// <summary>
        /// An array of partial server integrations
        /// <see cref="Integration"/>
        /// </summary>
        [JsonProperty("integrations")]
        public List<Integration> Integrations { get; set; }
        
        /// <summary>
        /// Whether the connection is verified
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; }      
        
        /// <summary>
        /// Whether friend sync is enabled for this connection
        /// </summary>
        [JsonProperty("friend_sync")]
        public bool FriendSync { get; set; }        
        
        /// <summary>
        /// Whether activities related to this connection will be shown in presence updates
        /// </summary>
        [JsonProperty("show_activity")]
        public bool ShowActivity { get; set; }        
        
        /// <summary>
        /// Visibility of this connection
        /// <see cref="ConnectionVisibilityType"/>
        /// </summary>
        [JsonProperty("visibility")]
        public ConnectionVisibilityType Visibility { get; set; }
    }
}
