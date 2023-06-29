using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Entities.Interactions.MessageComponents;
using Oxide.Ext.Discord.Entities.Messages;
using Oxide.Ext.Discord.Entities.Messages.Embeds;
using Oxide.Ext.Discord.Libraries.Templates.Messages;

namespace Oxide.Ext.Discord.Interfaces.Entities.Messages
{
    /// <summary>
    /// Interfaces for <see cref="DiscordMessageTemplates"/> Messages
    /// </summary>
    public interface IDiscordMessageTemplate
    {
        /// <summary>
        /// Content of the message
        /// </summary>
        string Content { get; set; }
        
        /// <summary>
        /// Allowed mentions for a message
        /// Allows for more granular control over mentions without various hacks to the message content. 
        /// </summary>
        AllowedMentions AllowedMentions { get; set; }
        
        /// <summary>
        /// Embeds for the message
        /// </summary>
        List<DiscordEmbed> Embeds { get; set; }
        
        /// <summary>
        /// Components for the message
        /// </summary>
        List<ActionRowComponent> Components { get; set; }
    }
}