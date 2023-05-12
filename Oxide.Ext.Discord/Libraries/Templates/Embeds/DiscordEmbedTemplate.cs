using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Entities.Messages.Embeds;
using Oxide.Ext.Discord.Entities.Permissions;
using Oxide.Ext.Discord.Exceptions.Entities.Messages;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Libraries.Placeholders;

namespace Oxide.Ext.Discord.Libraries.Templates.Embeds
{
    /// <summary>
    /// Discord Template for embed
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordEmbedTemplate
    {
        /// <summary>
        /// If this embed is enabled
        /// </summary>
        [JsonProperty("Show Embed")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The Tile for the embed
        /// </summary>
        [JsonProperty("Embed Title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// This Title Url for the embed
        /// </summary>
        [JsonProperty("Embed Title URL")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// The description of the embed
        /// </summary>
        [JsonProperty("Embed Description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The Hex Color for the embed
        /// </summary>
        [JsonProperty("Embed Hex Color")]
        public string Color { get; set; } = DiscordColor.Default.ToHex();

        /// <summary>
        /// Image URL to show in the embed
        /// </summary>
        [JsonProperty("Embed Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Thumbnail url to show in the embed
        /// </summary>
        [JsonProperty("Embed Thumbnail URL")]
        public string ThumbnailUrl { get; set; } = string.Empty;

        /// <summary>
        /// Video url to show in the embed
        /// </summary>
        [JsonProperty("Embed View Url")]
        public string VideoUrl { get; set; } = string.Empty;

        /// <summary>
        /// Show timestamp in the embed
        /// </summary>
        [JsonProperty("Show Embed TimeStamp")]
        public bool TimeStamp { get; set; } = false;

        /// <summary>
        /// Fields for the embed
        /// </summary>
        [JsonProperty("Embed Fields")]
        public List<DiscordEmbedFieldTemplate> Fields { get; set; } = new List<DiscordEmbedFieldTemplate>();

        /// <summary>
        /// Footer for the embed
        /// </summary>
        [JsonProperty("Embed Footer")]
        public EmbedFooterTemplate Footer { get; set; } = new EmbedFooterTemplate();
        
        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public DiscordEmbedTemplate() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="titleUrl"></param>
        public DiscordEmbedTemplate(string title, string description, string titleUrl = "")
        {
            Title = title;
            Description = description;
            Url = titleUrl;
        }

        /// <summary>
        /// Converts the template to a <see cref="DiscordEmbed"/>
        /// </summary>
        /// <param name="data">Data to use</param>
        /// <param name="embed">Initial embed to use</param>
        /// <returns></returns>
        public DiscordEmbed ToEntity(PlaceholderData data = null, DiscordEmbed embed = null)
        {
            if (embed == null)
            {
                embed = new DiscordEmbed();
            }

            embed.Title = PlaceholderFormatting.ApplyPlaceholder(Title, data);
            embed.Url = PlaceholderFormatting.ApplyPlaceholder(Url, data);
            embed.Description = PlaceholderFormatting.ApplyPlaceholder(Description, data);
            embed.Color = !string.IsNullOrEmpty(Color) ? new DiscordColor(PlaceholderFormatting.ApplyPlaceholder(Color, data)) : (DiscordColor?)null;
            embed.Timestamp = TimeStamp ? DateTime.UtcNow : (DateTime?)null;

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                embed.Image = new EmbedImage
                {
                    Url = PlaceholderFormatting.ApplyPlaceholder(Url, data)
                };
            }

            if (!string.IsNullOrEmpty(ThumbnailUrl))
            {
                embed.Thumbnail = new EmbedThumbnail
                {
                    Url = PlaceholderFormatting.ApplyPlaceholder(ThumbnailUrl, data)
                };
            }

            if (!string.IsNullOrEmpty(VideoUrl))
            {
                embed.Video = new EmbedVideo
                {
                    Url = PlaceholderFormatting.ApplyPlaceholder(ThumbnailUrl, data)
                };
            }

            if (Fields != null && Fields.Count != 0)
            {
                InvalidEmbedException.ThrowIfInvalidFieldCount(Fields.Count);
                embed.Fields = new List<EmbedField>();
                for (int index = 0; index < Fields.Count; index++)
                {
                    embed.Fields.Add(Fields[index].ToEntity(data));
                }
            }

            if (Footer != null && Footer.Enabled)
            {
                embed.Footer = Footer.ToFooter(data);
            }

            return embed;
        }
    }
}