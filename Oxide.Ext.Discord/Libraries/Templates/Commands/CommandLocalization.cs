﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries.Templates.Commands
{
    /// <summary>
    /// Localization for Application Commands
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CommandLocalization
    {
        /// <summary>
        /// Localization for <see cref="CommandCreate.Name"/> or <see cref="CommandOption.Name"/>
        /// </summary>
        [JsonProperty("Command Name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Localization for <see cref="CommandCreate.Description"/> or <see cref="CommandOption.Description"/>
        /// </summary>
        [JsonProperty("Command Description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Localized Options for the Command
        /// </summary>
        [JsonProperty("Command Options")]
        public List<CommandLocalization> Options { get; set; }
        
        /// <summary>
        /// Localized Argument Options
        /// </summary>
        [JsonProperty("Argument Localization")]
        public Hash<string, ArgumentLocalization> Arguments { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public CommandLocalization() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public CommandLocalization(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="create"></param>
        public CommandLocalization(CommandCreate create)
        {
            Name = create.Name;
            Description = create.Description;
            if (create.Options == null)
            {
                return;
            }

            for (int index = 0; index < create.Options.Count; index++)
            {
                ProcessOption(create.Options[index]);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="opt"></param>
        public CommandLocalization(CommandOption opt)
        {
            Name = opt.Name;
            Description = opt.Description;
            if (opt.Options == null)
            {
                return;
            }

            for (int index = 0; index < opt.Options.Count; index++)
            {
                ProcessOption(opt.Options[index]);
            }
        }

        private void ProcessOption(CommandOption option)
        {
            if (option.Type == CommandOptionType.SubCommand || option.Type == CommandOptionType.SubCommandGroup)
            {
                if (Options == null)
                {
                    Options = new List<CommandLocalization>();
                }
                    
                Options.Add(new CommandLocalization(option));
                return;
            }

            if (Arguments == null)
            {
                Arguments = new Hash<string, ArgumentLocalization>();
            }

            Arguments[option.Name] = new ArgumentLocalization(option);
        }
        
        /// <summary>
        /// Apply Command Localizations to the <see cref="CommandCreate"/>
        /// </summary>
        /// <param name="create"></param>
        /// <param name="language"></param>
        public void ApplyCommandLocalization(CommandCreate create, string language)
        {
            create.NameLocalizations[language] = Name;
            create.DescriptionLocalizations[language] = Description;
            if (create.Options == null)
            {
                return;
            }

            for (int index = 0; index < create.Options.Count; index++)
            {
                ApplyOptionLocalization(create.Options[index], language);
            }
        }

        private void ApplyOptionLocalization(CommandOption opt, string language)
        {
            if (opt.NameLocalizations == null)
            {
                opt.NameLocalizations = new Hash<string, string>();
            }

            if (opt.DescriptionLocalizations == null)
            {
                opt.DescriptionLocalizations = new Hash<string, string>();
            }
            
            if (opt.Type == CommandOptionType.SubCommand || opt.Type == CommandOptionType.SubCommandGroup)
            {
                opt.NameLocalizations[language] = Name;
                opt.DescriptionLocalizations[language] = Description;

                if (opt.Options != null)
                {
                    for (int index = 0; index < opt.Options.Count; index++)
                    {
                        ApplyOptionLocalization(opt.Options[index], language);
                    }
                }

                return;
            }

            Arguments?[opt.Name]?.ApplyArgumentLocalization(opt, language);
        }
    }
}