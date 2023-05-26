using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Builders.Interactions;
using Oxide.Ext.Discord.Entities.Channels;
using Oxide.Ext.Discord.Entities.Guilds;
using Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands;
using Oxide.Ext.Discord.Entities.Interactions.Response;
using Oxide.Ext.Discord.Entities.Messages;
using Oxide.Ext.Discord.Entities.Permissions;
using Oxide.Ext.Discord.Entities.Users;
using Oxide.Ext.Discord.Exceptions.Entities;
using Oxide.Ext.Discord.Exceptions.Entities.Interactions;
using Oxide.Ext.Discord.Interfaces.Promises;
using Oxide.Ext.Discord.Json.Converters;
using Oxide.Ext.Discord.Libraries.AppCommands.Commands;
using Oxide.Ext.Discord.Libraries.Langs;
using Oxide.Ext.Discord.Libraries.Placeholders;

namespace Oxide.Ext.Discord.Entities.Interactions
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-structure">Interaction Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordInteraction
    {
        /// <summary>
        /// Id of the interaction
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }

        /// <summary>
        /// ID of the application this interaction is for
        /// </summary>
        [JsonProperty("application_id")]
        public Snowflake ApplicationId { get; set; }

        /// <summary>
        /// The type of interaction
        /// See <see cref="InteractionType"/>
        /// </summary>
        [JsonProperty("type")]
        public InteractionType Type { get; set; }

        /// <summary>
        /// Interaction data payload
        /// See <see cref="InteractionData"/>
        /// </summary>
        [JsonProperty("data")]
        public InteractionData Data { get; set; }

        /// <summary>
        /// Guild that the interaction was sent from
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// Channel that the interaction was sent from
        /// </summary>
        [JsonProperty("channel")]
        public DiscordChannel Channel { get; set; }

        /// <summary>
        /// Channel that the interaction was sent from
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake? ChannelId { get; set; }

        /// <summary>
        /// Guild member data for the invoking user, including permissions
        /// </summary>
        [JsonProperty("member")]
        public GuildMember Member { get; set; }

        [JsonProperty("user")]
#pragma warning disable CS0649
        private DiscordUser _user;
#pragma warning restore CS0649

        /// <summary>
        /// User object. If in DM then DM user else GuildMember.User
        /// </summary>
        public DiscordUser User => _user ?? Member?.User;

        /// <summary>
        /// Continuation token for responding to the interaction
        /// Interaction tokens are valid for 15 minutes and can be used to send followup messages but you must send an initial response within 3 seconds of receiving the event.
        /// If the 3 second deadline is exceeded, the token will be invalidated.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Read-only property, always 1
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// For components, the message they were attached to
        /// </summary>
        [JsonProperty("message")]
        public DiscordMessage Message { get; set; }

        /// <summary>
        /// Bitwise set of permissions the app or bot has within the channel the interaction was sent from
        /// </summary>
        [JsonConverter(typeof(PermissionFlagsStringConverter))]
        [JsonProperty("app_permissions")]
        public PermissionFlags? AppPermissions { get; set; }
        
        /// <summary>
        /// The selected language of the invoking user
        /// <a href="https://discord.com/developers/docs/dispatch/field-values#predefined-field-values-accepted-locales">Discord Locale Values</a>
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// The guild's preferred locale, if invoked in a guild
        /// <a href="https://discord.com/developers/docs/dispatch/field-values#predefined-field-values-accepted-locales">Discord Locale Values</a>
        /// </summary>
        [JsonProperty("guild_locale")]
        public string GuildLocale { get; set; }

        private InteractionDataParsed _parsed;

        /// <summary>
        /// Returns the interaction parsed args to make it easier to process that interaction.
        /// </summary>
        public InteractionDataParsed Parsed => _parsed ?? (_parsed = new InteractionDataParsed(this));

        private InteractionDataOption _focused;

        /// <summary>
        /// Returns the Focused option for Auto Complete
        /// </summary>
        public InteractionDataOption Focused => _focused ?? (_focused = GetFocusedOption());

        /// <summary>
        /// The UTC DateTime this interaction was created
        /// </summary>
        public readonly DateTime CreatedDate = DateTime.UtcNow;

        /// <summary>
        /// If CreateInteractionResponse has been successfully called for this interaction
        /// </summary>
        private bool _hasResponded;

        /// <summary>
        /// Returns a localized string for this interaction
        /// </summary>
        /// <param name="plugin">Plugin the localization is for</param>
        /// <param name="langKey">Lang Key to return</param>
        /// <returns>Localized string if it is found; Empty string otherwise</returns>
        [Obsolete("This feature is deprecated and will be removed in the future. Please switch to Discord Templates instead.")]
        public string GetLangMessage(Plugin plugin, string langKey) => DiscordLang.Instance.GetDiscordInteractionLangMessage(plugin, this, langKey);
        
        /// <summary>
        /// Returns a localized string for this interaction
        /// </summary>
        /// <param name="plugin">Plugin the localization is for</param>
        /// <param name="langKey">Lang Key to return</param>
        /// <param name="args">Localization args</param>
        /// <returns>Localized string if it is found; Empty string otherwise</returns>
        [Obsolete("This feature is deprecated and will be removed in the future. Please switch to Discord Templates instead.")]
        public string GetLangMessage(Plugin plugin, string langKey, params object[] args) => DiscordLang.Instance.GetDiscordInteractionLangMessage(plugin, this, langKey, args);
        
        private InteractionDataOption GetFocusedOption()
        {
            if (Type != InteractionType.ApplicationCommandAutoComplete)
            {
                return null;
            }
            
            List<InteractionDataOption> options = Data.Options;
            if (options == null)
            {
                return null;
            }
            
            for (int index = 0; index < options.Count;)
            {
                InteractionDataOption option = options[index];
                if (option.Type == CommandOptionType.SubCommand || option.Type == CommandOptionType.SubCommandGroup)
                {
                    options = option.Options;
                    index = 0;
                    continue;
                }

                if (option.Focused.HasValue && option.Focused.Value)
                {
                    return option;
                }

                index++;
            }

            return null;
        }

        internal AppCommandId GetCommandId()
        {
            string command = Data.Name;
            string group = null;
            string subCommand = null;
            string argument = null;
            
            List<InteractionDataOption> options = Data.Options;
            if (options != null)
            {
                for (int index = 0; index < options.Count;)
                {
                    InteractionDataOption option = options[index];
                    switch (option.Type)
                    {
                        case CommandOptionType.SubCommandGroup:
                            group = option.Name;
                            options = option.Options;
                            index = 0;
                            break;
                        case CommandOptionType.SubCommand:
                            subCommand = option.Name;
                            options = option.Options;
                            index = 0;
                            break;
                        
                        default:
                            if (option.Focused.HasValue && option.Focused.Value)
                            {
                                argument = option.Name;
                            }
                            index++;
                            break;
                    }
                }
            }

            return new AppCommandId(command, group, subCommand, argument);
        }
        
        /// <summary>
        /// Returns a <see cref="InteractionResponseBuilder"/> for this interaction
        /// </summary>
        /// <returns></returns>
        public InteractionResponseBuilder GetResponseBuilder()
        {
            InvalidInteractionResponseException.ThrowIfAlreadyResponded(_hasResponded);
            return new InteractionResponseBuilder(this);
        }
        
        /// <summary>
        /// Returns a <see cref="InteractionFollowupBuilder"/> for this interaction
        /// </summary>
        /// <returns></returns>
        public InteractionFollowupBuilder GetFollowupBuilder()
        {
            InvalidInteractionResponseException.ThrowIfNotResponded(_hasResponded);
            return new InteractionFollowupBuilder(this);
        }
        
        /// <summary>
        /// Returns a <see cref="InteractionAutoCompleteBuilder"/> for this interaction
        /// </summary>
        /// <returns></returns>
        public InteractionAutoCompleteBuilder GetAutoCompleteBuilder()
        {
            InvalidInteractionResponseException.ThrowIfAlreadyResponded(_hasResponded);
            return new InteractionAutoCompleteBuilder(this);
        }
        
        /// <summary>
        /// Returns a <see cref="InteractionAutoCompleteBuilder"/> for this interaction
        /// </summary>
        /// <returns></returns>
        public InteractionModalBuilder GetModalBuilder()
        {
            InvalidInteractionResponseException.ThrowIfAlreadyResponded(_hasResponded);
            return new InteractionModalBuilder(this);
        }

        /// <summary>
        /// Create a response to an Interaction from the gateway.
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="response">Response to respond with</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, BaseInteractionResponse response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));
            InvalidInteractionResponseException.ThrowIfAlreadyResponded(_hasResponded);
            InvalidInteractionResponseException.ThrowIfInitialResponseTimeElapsed(CreatedDate);
            InvalidInteractionResponseException.ThrowIfInvalidResponseType(Type, response.Type);

            _hasResponded = true;
            return client.Bot.Rest.Post(client, $"interactions/{Id}/{Token}/callback", response);
        }

        /// <summary>
        /// Create a response to an Interaction from the gateway.
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="type">Type of the interaction response</param>
        /// <param name="response">Interaction Callback Message Data</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, InteractionResponseType type, InteractionCallbackData response = null)
        {
            InteractionResponse data = new InteractionResponse(type, response);
            return CreateInteractionResponse(client, data);
        }

        /// <summary>
        /// Creates a interaction message response from a message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="type">Response type for the interaction</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="message">Message to send (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        /// <exception cref="ArgumentNullException">Thrown if plugin or templateName is null</exception>
        public IPromise CreateTemplateInteractionResponse(DiscordClient client, Plugin plugin, InteractionResponseType type, string templateName, InteractionCallbackData message = null, PlaceholderData placeholders = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(templateName)) throw new ArgumentNullException(nameof(templateName));
            
            InteractionCallbackData template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(plugin, templateName, this).ToMessage(placeholders, message);
            return CreateInteractionResponse(client, type, template);
        }
        
        /// <summary>
        /// Creates a interaction modal response from a modal template 
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName"></param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IPromise CreateTemplateModalResponse(DiscordClient client, Plugin plugin, string templateName, InteractionModalMessage message = null, PlaceholderData placeholders = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(templateName)) throw new ArgumentNullException(nameof(templateName));
            
            InteractionModalMessage template = DiscordExtension.DiscordModalTemplates.GetLocalizedTemplate(plugin, templateName, this).ToModal(placeholders, message);
            return CreateInteractionResponse(client, template);
        }

        /// <summary>
        /// Create a response to an Interaction from the gateway.
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="type">Type of the interaction response</param>
        /// <param name="builder">Builder for this response</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, InteractionResponseType type, InteractionResponseBuilder builder)
        {
            InteractionResponse data = new InteractionResponse(type, builder.Build());
            return CreateInteractionResponse(client, data);
        }
        
        /// <summary>
        /// Create a Auto Complete response to an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message for this response</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, InteractionAutoCompleteMessage message)
        {
            InteractionAutoCompleteResponse data = new InteractionAutoCompleteResponse(message);
            return CreateInteractionResponse(client, data);
        }
        
        /// <summary>
        /// Create a Auto Complete response to an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Auto Complete Builder for this response</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, InteractionAutoCompleteBuilder builder)
        {
            return CreateInteractionResponse(client, builder.Build());
        }
        
        /// <summary>
        /// Create a Modal response to an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message for this response</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, InteractionModalMessage message)
        {
            InteractionModalResponse data = new InteractionModalResponse(message);
            return CreateInteractionResponse(client, data);
        }
        
        /// <summary>
        /// Create a Modal response to an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Modal Builder for this response</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise CreateInteractionResponse(DiscordClient client, InteractionModalBuilder builder)
        {
            return CreateInteractionResponse(client, builder.Build());
        }
        
        /// <summary>
        /// Creates a response indicating that:
        /// for application commands there will be an update in the future
        /// for message component commands that you have acknowledged the command and there may be an update in the future
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-interaction-response">Create Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise DefferResponse(DiscordClient client)
        {
            InteractionResponseType type = Type == InteractionType.ApplicationCommand ? InteractionResponseType.DeferredChannelMessageWithSource : InteractionResponseType.DeferredUpdateMessage;
            return CreateInteractionResponse(client, type);
        }

        /// <summary>
        /// Edits the initial Interaction response
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#edit-original-interaction-response">Edit Original Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// /// <param name="message">Updated message</param>
        /// <param name="callback">Callback with the created message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise<DiscordMessage> EditOriginalInteractionResponse(DiscordClient client, DiscordMessage message)
        {
            InvalidInteractionResponseException.ThrowIfNotResponded(_hasResponded);
            InvalidInteractionResponseException.ThrowIfMaxResponseTimeElapsed(CreatedDate);
            return client.Bot.Rest.Patch<DiscordMessage>(client, $"webhooks/{ApplicationId}/{Token}/messages/@original", message);
        }
        
        /// <summary>
        /// Edit a interaction response with a message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IPromise<DiscordMessage> EditTemplateOriginalInteractionResponse(DiscordClient client, Plugin plugin, string templateName, DiscordMessage message = null, PlaceholderData placeholders = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (string.IsNullOrEmpty(templateName)) throw new ArgumentNullException(nameof(templateName));
            
            DiscordMessage template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(plugin, templateName, this).ToMessage(placeholders, message);
            return EditOriginalInteractionResponse(client, template);
        }

        /// <summary>
        /// Deletes the initial Interaction response
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#delete-original-interaction-response">Delete Original Interaction Response</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise DeleteOriginalInteractionResponse(DiscordClient client)
        {
            InvalidInteractionResponseException.ThrowIfNotResponded(_hasResponded);
            InvalidInteractionResponseException.ThrowIfMaxResponseTimeElapsed(CreatedDate);
            return client.Bot.Rest.Delete(client, $"webhooks/{ApplicationId}/{Token}/messages/@original");
        }

        /// <summary>
        /// Create a followup message for an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-followup-message">Create Followup Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message to follow up with</param>
        /// <param name="callback">Callback with the message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise<DiscordMessage> CreateFollowUpMessage(DiscordClient client, CommandFollowupCreate message)
        {
            InvalidInteractionResponseException.ThrowIfNotResponded(_hasResponded);
            InvalidInteractionResponseException.ThrowIfMaxResponseTimeElapsed(CreatedDate);
            return client.Bot.Rest.Post<DiscordMessage>(client, $"webhooks/{ApplicationId}/{Token}", message);
        }
        
        /// <summary>
        /// Create a followup message for an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#create-followup-message">Create Followup Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Builder for the follow up</param>
        /// <param name="callback">Callback with the message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise<DiscordMessage> CreateFollowUpMessage(DiscordClient client, InteractionFollowupBuilder builder)
        {
            return CreateFollowUpMessage(client, builder.Build());
        }

        /// <summary>
        /// Edits a followup message for an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#edit-followup-message">Edit Followup Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID of the follow up message</param>
        /// <param name="edit">Updated message</param>
        /// <param name="callback">Callback with the updated message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise<DiscordMessage> EditFollowUpMessage(DiscordClient client, Snowflake messageId, CommandFollowupUpdate edit)
        {
            InvalidInteractionResponseException.ThrowIfNotResponded(_hasResponded);
            InvalidInteractionResponseException.ThrowIfMaxResponseTimeElapsed(CreatedDate);
            InvalidSnowflakeException.ThrowIfInvalid(messageId, nameof(messageId));
            return client.Bot.Rest.Patch<DiscordMessage>(client, $"webhooks/{ApplicationId}/{Token}/messages/{messageId}", edit);
        }

        /// <summary>
        /// Deletes a followup message for an Interaction
        /// See <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#delete-followup-message">Delete Followup Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to delete</param>
        /// <param name="callback">Callback with the updated message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IPromise DeleteFollowUpMessage(DiscordClient client, Snowflake messageId)
        {
            InvalidInteractionResponseException.ThrowIfNotResponded(_hasResponded);
            InvalidInteractionResponseException.ThrowIfMaxResponseTimeElapsed(CreatedDate);
            InvalidSnowflakeException.ThrowIfInvalid(messageId, nameof(messageId));
            return client.Bot.Rest.Delete(client, $"webhooks/{ApplicationId}/{Token}/messages/{messageId}");
        }
    }
}