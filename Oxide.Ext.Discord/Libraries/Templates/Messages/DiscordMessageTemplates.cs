using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries.Templates.Messages
{
    /// <summary>
    /// Modal Templates Library
    /// </summary>
    public class DiscordMessageTemplates : BaseMessageTemplatesLibrary<DiscordMessageTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordMessageTemplates(ILogger logger) : base(logger) { }
    }
}