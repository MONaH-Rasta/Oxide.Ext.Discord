using Oxide.Ext.Discord.Builders.Messages.BaseBuilders;
using Oxide.Ext.Discord.Entities.Interactions;
using Oxide.Ext.Discord.Entities.Interactions.Response;
using Oxide.Ext.Discord.Entities.Messages;
using Oxide.Ext.Discord.Exceptions.Builders;

namespace Oxide.Ext.Discord.Builders.Interactions
{
    /// <summary>
    /// Represents a builder for <see cref="BaseInteractionMessage"/>
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <typeparam name="TBuilder"></typeparam>
    public abstract class BaseInteractionMessageBuilder<TMessage, TBuilder> : BaseMessageBuilder<TMessage, TBuilder>
        where TMessage : BaseInteractionMessage
        where TBuilder : BaseInteractionMessageBuilder<TMessage, TBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interaction">Interaction this builder is for</param>
        /// <param name="message">Message to be created</param>
        protected BaseInteractionMessageBuilder(DiscordInteraction interaction, TMessage message) : base(message)
        {
            InteractionResponseBuilderException.ThrowIfInteractionIsAutoComplete(interaction.Type);
        }
        
        /// <summary>
        /// Marks the response as Ephemeral so only the person who executed the command can see
        /// </summary>
        /// <returns></returns>
        public TBuilder AsEphemeral()
        {
            Message.Flags |= MessageFlags.Ephemeral;
            return Builder;
        }
    }
}