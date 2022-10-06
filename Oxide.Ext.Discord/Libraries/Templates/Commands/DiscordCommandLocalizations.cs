using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks.Templates;
using Oxide.Ext.Discord.Callbacks.Templates.Commands;
using Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands;
using Oxide.Ext.Discord.Exceptions.Libraries;
using Oxide.Ext.Discord.Libraries.Langs;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Pooling;
using Oxide.Ext.Discord.Promise;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries.Templates.Commands
{
    /// <summary>
    /// Library for localizing <see cref="DiscordApplicationCommand"/>s
    /// </summary>
    public class DiscordCommandLocalizations : BaseTemplateLibrary
    {
        internal DiscordCommandLocalizations(ILogger logger) : base(Path.Combine(Interface.Oxide.InstanceDirectory, "discord", "commands"), TemplateType.Command, logger) { }
        
        /// <summary>
        /// Registers Application Command Localization for a given language
        /// </summary>
        /// <param name="plugin">Plugin the for the command localization</param>
        /// <param name="fileNameSuffix">Suffix to be applied to the localization. IE DiscordExtension.{suffix}.json (optional)</param>
        /// <param name="localization">Localization to register</param>
        /// <param name="minVersion">Min supported registered version</param>
        /// <param name="language">Language to register</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IDiscordPromise RegisterCommandLocalizationAsync(Plugin plugin, string fileNameSuffix, DiscordCommandLocalization localization, TemplateVersion minVersion, string language = DiscordLang.DefaultOxideLanguage)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (localization == null) throw new ArgumentNullException(nameof(localization));

            IDiscordPromise promise = DiscordPromise.Create();
            
            TemplateId id = new TemplateId(plugin, fileNameSuffix, language);
            RegisterTemplateCallback<DiscordCommandLocalization>.Start(this, id, localization, minVersion, promise);
            return promise;
        }
        
        /// <summary>
        /// Registers multiple command localizations
        /// </summary>
        /// <param name="plugin">Plugin the for the command localization</param>
        /// <param name="fileNameSuffix">Suffix to be applied to the localization. IE DiscordExtension.{suffix}.json (optional)</param>
        /// <param name="commands">List of <see cref="DiscordCommandLocalization"/> to bulk register</param>
        /// <param name="minVersion">Min supported registered version</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IDiscordPromise BulkRegisterCommandLocalizationsAsync(Plugin plugin, string fileNameSuffix, List<BulkTemplateRegistration<DiscordCommandLocalization>> commands, TemplateVersion minVersion)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (commands == null) throw new ArgumentNullException(nameof(commands));

            IDiscordPromise promise = DiscordPromise.Create();
            
            TemplateId id = new TemplateId(plugin, fileNameSuffix, null);
            BulkRegisterTemplateCallback<DiscordCommandLocalization>.Start(this, id, commands, minVersion, promise);
            return promise;
        }

        /// <summary>
        /// Applies Command Localizations Async
        /// </summary>
        /// <param name="plugin">Plugin the localizations are for</param>
        /// <param name="create">The command to apply the localizations to</param>
        /// <param name="fileNameSuffix">fileName suffix used when registering</param>
        /// <returns></returns>
        public IDiscordPromise ApplyCommandLocalizationsAsync(Plugin plugin, CommandCreate create, string fileNameSuffix)
        {
            return HandleApplyCommandLocalizationsAsync(plugin, fileNameSuffix, create, DiscordPromise.Create());
        }
        
        private IDiscordPromise HandleApplyCommandLocalizationsAsync(Plugin plugin, string fileNameSuffix, CommandCreate create, IDiscordPromise promise = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));

            if (promise == null)
            {
                promise = DiscordPromise.Create(true);
            }
            
            TemplateId id = new TemplateId(plugin, fileNameSuffix, null);
            ApplyCommandLocalizationsCallback.Start(id, create, promise);
            return promise;
        }

        internal async Task HandleApplyCommandLocalizationsAsync(TemplateId id, CommandCreate create, IDiscordPromise promise)
        {
            await HandleApplyCommandLocalizationsAsync(id, create).ConfigureAwait(false);
            promise.Resolve();
        }

        internal async Task HandleApplyCommandLocalizationsAsync(TemplateId id, CommandCreate create)
        {
            await HandlePrepareCommandLocalizationsAsync(create).ConfigureAwait(false);

            List<Task> tasks = DiscordPool.GetList<Task>();
            foreach (string dir in Directory.EnumerateDirectories(GetTemplateFolder(id.PluginName)))
            {
                string lang = Path.GetFileName(dir);
                tasks.Add(HandleLoadAndApplyCommandLocalizationsAsync(id, create, lang));
            }

            await Task.WhenAll(tasks).ConfigureAwait(false);
            DiscordPool.FreeList(tasks);
        }
        
        private void PrepareCommandLocalizations(CommandCreate create)
        {
            if (create.NameLocalizations == null)
            {
                create.NameLocalizations = new Hash<string, string>();
            }

            if (create.DescriptionLocalizations == null)
            {
                create.DescriptionLocalizations = new Hash<string, string>();
            }

            if (create.Options == null)
            {
                return;
            }

            for (int index = 0; index < create.Options.Count; index++)
            {
                PrepareOptionLocalizations(create.Options[index]);
            }
        }
        private void PrepareOptionLocalizations(CommandOption opt)
        {
            if (opt.NameLocalizations == null)
            {
                opt.NameLocalizations = new Hash<string, string>();
            }

            if (opt.DescriptionLocalizations == null)
            {
                opt.DescriptionLocalizations = new Hash<string, string>();
            }

            if (opt.Options != null)
            {
                for (int index = 0; index < opt.Options.Count; index++)
                {
                    PrepareOptionLocalizations(opt.Options[index]);
                }
            }

            if (opt.Choices != null)
            {
                for (int i = 0; i < opt.Choices.Count; i++)
                {
                    CommandOptionChoice choice = opt.Choices[i];
                    if (choice.NameLocalizations == null)
                    {
                        choice.NameLocalizations = new Hash<string, string>();
                    }
                }
            }
        }
        private Task HandlePrepareCommandLocalizationsAsync(CommandCreate create)
        {
            PrepareCommandLocalizations(create);
            return Task.CompletedTask;
        }

        private async Task HandleLoadAndApplyCommandLocalizationsAsync(TemplateId id, CommandCreate create, string lang)
        {
            DiscordCommandLocalization localization = await LoadTemplate<DiscordCommandLocalization>(id.WithLanguage(lang)).ConfigureAwait(false);
            if (localization != null)
            {
                await localization.HandleApplyCommandLocalizationAsync(create, lang).ConfigureAwait(false);
            }
        }

        internal override string GetTemplateFolder(string plugin)
        {
            return RootDir;
        }
        
        internal override string GetTemplatePath(TemplateId id)
        {
            DiscordTemplateException.ThrowIfInvalidTemplateName(id.TemplateName, TemplateType);
            string fileName = !string.IsNullOrEmpty(id.TemplateName) ? $"{id.PluginName}.{id.TemplateName}.json" : $"{id.PluginName}.json";
            return Path.Combine(RootDir, id.Language, fileName);
        }

        protected override void OnPluginLoaded(Plugin plugin) { }

        protected override void OnPluginUnloaded(Plugin plugin)
        {
            string name = plugin.Name;
            RegisteredTemplates.RemoveWhere(rt => rt.PluginName == name);
        }
    }
}