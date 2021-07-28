namespace Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/slash-commands#applicationcommandoptiontype">ApplicationCommandOptionType</a>
    /// </summary>
    public enum CommandOptionType
    {
        /// <summary>
        /// The command option is a sub command
        /// </summary>
        SubCommand = 1,
        
        /// <summary>
        /// The command option is a sub command group
        /// </summary>
        SubCommandGroup = 2,
        
        /// <summary>
        /// The sub command option is a string
        /// </summary>
        String = 3,
        
        /// <summary>
        /// The sub command options is an integer
        /// </summary>
        Integer = 4,
        
        /// <summary>
        /// The sub command option is a boolean
        /// </summary>
        Boolean = 5,
        
        /// <summary>
        /// The sub command option is a user
        /// </summary>
        User = 6,
        
        /// <summary>
        /// The sub command option is a channel
        /// </summary>
        Channel = 7,
        
        /// <summary>
        /// The sub command option is a Role
        /// </summary>
        Role = 8,
        
        /// <summary>
        /// The sub command option is a Mentionable
        /// </summary>
        Mentionable = 9
    }
}