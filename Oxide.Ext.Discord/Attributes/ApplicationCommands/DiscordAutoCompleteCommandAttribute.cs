using System;
using Oxide.Ext.Discord.Entities.Interactions;

namespace Oxide.Ext.Discord.Attributes.ApplicationCommands
{
    /// <summary>
    /// Discord Auto Complete Command Attribute for <see cref="InteractionType.ApplicationCommandAutoComplete"/>
    /// Callback Hook Format:
    /// <code>
    /// private void Callback(DiscordInteraction interaction, InteractionDataOption focused)
    /// {
    ///     Puts("Callback Works!");
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class DiscordAutoCompleteCommandAttribute : DiscordApplicationCommandAttribute
    {
        internal readonly string ArgumentName;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Command for the Auto Complete</param>
        /// <param name="argumentName">Argument Name for the Auto Complete</param>
        /// <param name="group">Sub Command Group for the Auto Complete</param>
        /// <param name="subCommand">Sub Command for the Auto Complete</param>
        public DiscordAutoCompleteCommandAttribute(string command, string argumentName, string group = null, string subCommand = null) : base(command, group, subCommand) 
        {
            ArgumentName = argumentName;
        }
    }
}