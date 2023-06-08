using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Entities.Channels;

namespace Oxide.Ext.Discord.Exceptions.Entities.Channels
{
    /// <summary>
    /// Represents using an invalid channel
    /// </summary>
    public class InvalidChannelException : BaseDiscordException
    {
        private InvalidChannelException(string message): base(message) { }

        internal static void ThrowIfInvalidName(string name, bool allowNullOrEmpty)
        {
            const int MaxLength = 100;
            
            if (!allowNullOrEmpty && string.IsNullOrEmpty(name))
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Name)} cannot be less than 1 character");
            }
            
            if (name.Length > MaxLength)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Name)} cannot be more than {MaxLength} characters");
            }
        }

        internal static void ThrowIfInvalidTopic(string topic, ChannelType type, bool allowNullOrEmpty)
        {
            const int MaxForumLength = 4096;
            const int MaxTopicLength = 1024;
            
            if (!allowNullOrEmpty && string.IsNullOrEmpty(topic))
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Topic)}  cannot be less than 1 character");
            }

            if (type == ChannelType.GuildForum)
            {
                if (topic.Length > MaxForumLength)
                {
                    throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Topic)} cannot be more than {MaxForumLength} characters for Guild Forum Channels");
                }

                return;
            }
            
            if (topic.Length > MaxTopicLength)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Topic)} cannot be more than {MaxTopicLength} characters");
            }
        }
        
        internal static void ThrowIfInvalidRateLimitPerUser(int? rateLimitPerUser)
        {
            const int MinRateLimit = 0;
            const int MaxRateLimit = 21600;
            if (!rateLimitPerUser.HasValue)
            {
                return;
            }
            
            if (rateLimitPerUser.Value < MinRateLimit)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.RateLimitPerUser)} cannot be less than {MinRateLimit}");
            }
                
            if (rateLimitPerUser.Value > MaxRateLimit)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.RateLimitPerUser)} cannot be more than {MaxRateLimit}");
            }
        }
        
        internal static void ThrowIfInvalidBitRate(int? bitRate)
        {
            const int MinBitRate = 8000;
            const int MaxBitRate = 128000;
            if (!bitRate.HasValue)
            {
                return;
            }
            
            if (bitRate.Value < MinBitRate)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Bitrate)} cannot be less than {MinBitRate}");
            }
                
            if (bitRate.Value > MaxBitRate)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.Bitrate)} cannot be more than {MaxBitRate}");
            }
        }
        
        internal static void ThrowIfInvalidUserLimit(int? userLimit)
        {
            const int MinUserLimit = 0;
            const int MaxUserLimit = 99;

            if (!userLimit.HasValue)
            {
                return;
            }
            
            if (userLimit.Value < MinUserLimit)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.UserLimit)} cannot be less than {MinUserLimit}");
            }
                
            if (userLimit.Value > MaxUserLimit)
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.UserLimit)} cannot be more than {MaxUserLimit}");
            }
        }
        
        internal static void ThrowIfInvalidParentId(Snowflake? parentId)
        {
            if (parentId.HasValue && !parentId.Value.IsValid())
            {
                throw new InvalidChannelException($"{nameof(DiscordChannel)}.{nameof(DiscordChannel.ParentId)} is not a valid snowflake");
            }
        }
        
        internal static void ThrowIfNotThread(DiscordChannel channel, string message)
        {
            if (channel == null || !channel.IsThreadChannel())
            {
                throw new InvalidChannelException(message);
            }
        }
        
        internal static void ThrowIfNotGuildChannel(DiscordChannel channel, string message)
        {
            if (channel == null || !channel.IsDmChannel())
            {
                throw new InvalidChannelException(message);
            }
        }
        
        internal static void ThrowIfChannelToSelf(Snowflake userId, DiscordClient client)
        {
            if (userId == client.Bot.BotUser.Id)
            {
                throw new InvalidChannelException("Tried to create a direct message channel to yourself which is not allowed.");
            }
        }
    }
}