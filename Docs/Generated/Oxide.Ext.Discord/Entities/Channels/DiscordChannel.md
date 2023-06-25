# DiscordChannel class

Represents a guild or DM [Channel Structure](https://discord.com/developers/docs/resources/channel#channel-object) within Discord.

```csharp
public class DiscordChannel : IDebugLoggable, ISnowflakeEntity
```

## Public Members

| name | description |
| --- | --- |
| [DiscordChannel](#DiscordChannel-constructor)() | The default constructor. |
| [ApplicationId](#ApplicationId-property) { get; set; } | Application id of the group DM creator if it is bot-created |
| [AppliedTags](#AppliedTags-property) { get; set; } | The IDs of the set of tags that have been applied to a thread in a GUILD_FORUM channel |
| [AvailableTags](#AvailableTags-property) { get; set; } | The set of tags that can be used in a GUILD_FORUM channel Limited to 20 |
| [Bitrate](#Bitrate-property) { get; set; } | The bitrate (in bits) of the voice channel |
| [DefaultAutoArchiveDuration](#DefaultAutoArchiveDuration-property) { get; set; } | Default duration for newly created threads, in minutes, to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080 |
| [DefaultForumLayout](#DefaultForumLayout-property) { get; set; } | The default [`ForumLayoutTypes`](./ForumLayoutTypes.md) used to display posts in GUILD_FORUM channels. Defaults to NotSet, which indicates a layout view has not been set by a channel admin |
| [DefaultReactionEmoji](#DefaultReactionEmoji-property) { get; set; } | The emoji to show in the add reaction button on a thread in a GUILD_FORUM channel |
| [DefaultSortOrder](#DefaultSortOrder-property) { get; set; } | The default [`SortOrderType`](./SortOrderType.md) used to order posts in `GUILD_FORUM` channels |
| [DefaultThreadRateLimitPerUser](#DefaultThreadRateLimitPerUser-property) { get; set; } | The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update. |
| [Flags](#Flags-property) { get; set; } | Flags for this channel |
| [GuildId](#GuildId-property) { get; set; } | the ID of the guild Warning: May be missing for some channel objects received over gateway guild dispatches |
| [Icon](#Icon-property) { get; set; } | icon hash of the group DM |
| [IconUrl](#IconUrl-property) { get; } | Returns the Icon URL for the given channel |
| [Id](#Id-property) { get; set; } | The ID of this channel |
| [LastMessageId](#LastMessageId-property) { get; set; } | The id of the last message sent in this channel (or thread for GUILD_FORUM channels) May not point to an existing or valid message or thread |
| [LastPinTimestamp](#LastPinTimestamp-property) { get; set; } | When the last pinned message was pinned. This may be null in events such as GUILD_CREATE when a message is not pinned. |
| [Managed](#Managed-property) { get; set; } | For group DM channels: whether the channel is managed by an application via the `gdm.join` OAuth2 scope |
| [Member](#Member-property) { get; set; } | Thread member object for the current user, if they have joined the thread, only included on certain API endpoints |
| [MemberCount](#MemberCount-property) { get; set; } | An approximate count of users in a thread, stops counting at 50 |
| [Mention](#Mention-property) { get; } | Returns a string to mention this channel in a message |
| [MessageCount](#MessageCount-property) { get; set; } | umber of messages (not including the initial messages or deleted messages) in a thread (if the thread was created before July 1, 2022, it stops counting at 50) |
| [Name](#Name-property) { get; set; } | The name of the channel (1-100 characters) |
| [Nsfw](#Nsfw-property) { get; set; } | Whether the channel is nsfw |
| [OwnerId](#OwnerId-property) { get; set; } | ID of the DM creator |
| [ParentId](#ParentId-property) { get; set; } | ID of the parent category for a channel (each parent category can contain up to 50 channels) |
| [PermissionOverwrites](#PermissionOverwrites-property) { get; set; } | Explicit permission overwrites for members and roles [`Overwrite`](./Overwrite.md) |
| [Permissions](#Permissions-property) { get; set; } | Default duration for newly created threads, in minutes, to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080 |
| [Position](#Position-property) { get; set; } | Sorting position of the channel |
| [RateLimitPerUser](#RateLimitPerUser-property) { get; set; } | Amount of seconds a user has to wait before sending another message (0-21600); bots, as well as users with the permission manage_messages or manage_channel, are unaffected |
| [Recipients](#Recipients-property) { get; set; } | The recipients of the DM |
| [RtcRegion](#RtcRegion-property) { get; set; } | Voice region id for the voice channel, automatic when set to null |
| [ThreadMembers](#ThreadMembers-property) { get; } | List of thread members if channel is thread; Null Otherwise. |
| [ThreadMetadata](#ThreadMetadata-property) { get; set; } | Thread-specific fields not needed by other channels |
| [Topic](#Topic-property) { get; set; } | The channel topic (0-1024 characters) |
| [TotalMessageSent](#TotalMessageSent-property) { get; set; } | Number of messages ever sent in a thread, it's similar to message_count on message creation, but will not decrement the number when a message is deleted |
| [Type](#Type-property) { get; set; } | the type of channel [`ChannelType`](./ChannelType.md) |
| [UserLimit](#UserLimit-property) { get; set; } | The user limit of the voice channel |
| [VideoQualityMode](#VideoQualityMode-property) { get; set; } | The camera video quality mode of the voice channel 1 when not present |
| [AddThreadMember](#AddThreadMember-method)(…) | Adds another user to a thread. Requires the ability to send messages in the thread. Also requires the thread is not archived. See [Add Thread Member](https://discord.com/developers/docs/resources/channel#add-thread-member) |
| [BulkDeleteMessages](#BulkDeleteMessages-method)(…) | Delete multiple messages in a single request. This endpoint can only be used on guild channels and requires the MANAGE_MESSAGES permission. See [Bulk Delete Messages](https://discord.com/developers/docs/resources/channel#bulk-delete-messages) |
| [CreateGlobalTemplateMessage](#CreateGlobalTemplateMessage-method)(…) | Creates a message in a text channel using a global message template |
| [CreateInvite](#CreateInvite-method)(…) | Create a new invite object for the channel. Only usable for guild channels. Requires the CREATE_INSTANT_INVITE permission. See [Create Channel Invite](https://discord.com/developers/docs/resources/channel#create-channel-invite) |
| [CreateMessage](#CreateMessage-method)(…) | Post a message to a guild text or DM channel. If operating on a guild channel, this endpoint requires the SEND_MESSAGES permission to be present on the current user. If the tts field is set to true, the SEND_TTS_MESSAGES permission is required for the message to be spoken. See [Create Message](https://discord.com/developers/docs/resources/channel#create-message) (4 methods) |
| [CreateTemplateMessage](#CreateTemplateMessage-method)(…) | Creates a message in a text channel using a localized message template |
| [Delete](#Delete-method)(…) | Delete a channel, or close a private message. Requires the MANAGE_CHANNELS or MANAGE_THREADS permission for the guild depending on the channel type. See [Delete/Close Channel](https://discord.com/developers/docs/resources/channel#deleteclose-channel) |
| [DeletePermission](#DeletePermission-method)(…) | Delete a channel permission overwrite for a user or role in a channel. Only usable for guild channels. Requires the MANAGE_ROLES permission. See [Delete Channel Permission](https://discord.com/developers/docs/resources/channel#delete-channel-permission) (2 methods) |
| [EditGroupDmChannel](#EditGroupDmChannel-method)(…) | Update a group dm channel's settings. See [Modify Channel](https://discord.com/developers/docs/resources/channel#modify-channel) |
| [EditGuildChannel](#EditGuildChannel-method)(…) | Update a guild channel's settings. Requires the MANAGE_CHANNELS permission for the guild. See [Modify Channel](https://discord.com/developers/docs/resources/channel#modify-channel) |
| [EditPermissions](#EditPermissions-method)(…) | Edit the channel permission overwrites for a user or role in a channel. Only usable for guild channels. Requires the MANAGE_ROLES permission. See [Edit Channel Permissions](https://discord.com/developers/docs/resources/channel#edit-channel-permissions) |
| [EditThreadChannel](#EditThreadChannel-method)(…) | Update a thread channel's settings. Requires the MANAGE_THREADS permission for the guild. See [Modify Channel](https://discord.com/developers/docs/resources/channel#modify-channel) |
| [FollowNewsChannel](#FollowNewsChannel-method)(…) | Follow a News Channel to send messages to a target channel. Requires the MANAGE_WEBHOOKS permission in the target channel. See [Follow Announcement Channel](https://discord.com/developers/docs/resources/channel#follow-announcement-channel) |
| [GetInvites](#GetInvites-method)(…) | Returns a list of invite objects (with invite metadata) for the channel. Only usable for guild channels. Requires the MANAGE_CHANNELS permission. See [Get Channel Invites](https://discord.com/developers/docs/resources/channel#get-channel-invites) |
| [GetMessage](#GetMessage-method)(…) | Returns a specific message in the channel. If operating on a guild channel, this endpoint requires the 'READ_MESSAGE_HISTORY' permission to be present on the current user. See [Get Channel Messages](https://discord.com/developers/docs/resources/channel#get-channel-message) |
| [GetMessages](#GetMessages-method)(…) | Returns the messages for a channel. If operating on a guild channel, this endpoint requires the VIEW_CHANNEL permission to be present on the current user. If the current user is missing the 'READ_MESSAGE_HISTORY' permission in the channel then this will return no messages (since they cannot read the message history). See [Get Channel Messages](https://discord.com/developers/docs/resources/channel#get-channel-messages) |
| [GetPinnedMessages](#GetPinnedMessages-method)(…) | Returns all pinned messages in the channel See [Get Pinned Messages](https://discord.com/developers/docs/resources/channel#get-pinned-messages) |
| [GetStageInstance](#GetStageInstance-method)(…) | Gets the stage instance associated with the Stage channel, if it exists. See [Get Stage Instance](https://discord.com/developers/docs/resources/stage-instance#get-stage-instance) |
| [GetThreadMember](#GetThreadMember-method)(…) | Returns a thread member object for the specified user if they are a member of the thread returns a 404 response otherwise. See [Remove Thread Member](https://discord.com/developers/docs/resources/channel#get-thread-member) |
| [GroupDmAddRecipient](#GroupDmAddRecipient-method)(…) | Adds a recipient to a Group DM using their access token See [Group DM Add Recipient](https://discord.com/developers/docs/resources/channel#group-dm-add-recipient) (2 methods) |
| [GroupDmRemoveRecipient](#GroupDmRemoveRecipient-method)(…) | Removes a recipient from a Group DM See [Group DM Remove Recipient](https://discord.com/developers/docs/resources/channel#group-dm-remove-recipient) |
| [IsDmChannel](#IsDmChannel-method)() | Returns if a channel is a DM channel |
| [IsGuildChannel](#IsGuildChannel-method)() | Returns if the channel is a guild channel |
| [IsThreadChannel](#IsThreadChannel-method)() | Returns if a channel is a thread channel |
| [JoinThread](#JoinThread-method)(…) | Adds the bot to the thread. Also requires the thread is not archived. See [Join Thread](https://discord.com/developers/docs/resources/channel#join-thread) |
| [LeaveThread](#LeaveThread-method)(…) | Removes the bot from the thread. Also requires the thread is not archived. See [Leave Thread](https://discord.com/developers/docs/resources/channel#leave-thread) |
| [ListJoinedPrivateArchivedThreads](#ListJoinedPrivateArchivedThreads-method)(…) | Returns archived threads in the channel that are of type GUILD_PRIVATE_THREAD, and the user has joined. Threads are ordered by their id, in descending order. Requires the READ_MESSAGE_HISTORY permission. See [List Joined Private Archived Threads](https://discord.com/developers/docs/resources/channel#list-joined-private-archived-threads) |
| [ListPrivateArchivedThreads](#ListPrivateArchivedThreads-method)(…) | Returns archived threads in the channel that are of type GUILD_PRIVATE_THREAD. Threads are ordered by archive_timestamp, in descending order. Requires both the READ_MESSAGE_HISTORY and MANAGE_THREADS permissions. See [List Private Archived Threads](https://discord.com/developers/docs/resources/channel#list-private-archived-threads) |
| [ListPublicArchivedThreads](#ListPublicArchivedThreads-method)(…) | Returns archived threads in the channel that are public. When called on a GUILD_TEXT channel, returns threads of type GUILD_PUBLIC_THREAD. When called on a GUILD_NEWS channel returns threads of type GUILD_NEWS_THREAD. Threads are ordered by archive_timestamp, in descending order. Requires the READ_MESSAGE_HISTORY permission. See [List Public Archived Threads](https://discord.com/developers/docs/resources/channel#list-public-archived-threads) |
| [ListThreadMembers](#ListThreadMembers-method)(…) | Returns array of thread members objects that are members of the thread. This endpoint is restricted according to whether the GUILD_MEMBERS Privileged Intent is enabled for your application. See [List Thread Members](https://discord.com/developers/docs/resources/channel#list-thread-members) |
| [LogDebug](#LogDebug-method)(…) |  |
| [RemoveThreadMember](#RemoveThreadMember-method)(…) | Removes another user from a thread. Requires the MANAGE_THREADS permission or that you are the creator of the thread. Also requires the thread is not archived. See [Remove Thread Member](https://discord.com/developers/docs/resources/channel#remove-thread-member) |
| [StartThreadFromMessage](#StartThreadFromMessage-method)(…) | Creates a new public thread from a message See [Start Thread with Message](https://discord.com/developers/docs/resources/channel#start-thread-from-message) |
| [StartThreadInForumChannel](#StartThreadInForumChannel-method)(…) | Creates a new thread in a forum channel, and sends a message within the created thread. Returns a channel, with a nested message object See [Start Thread in Forum Channel](https://discord.com/developers/docs/resources/channel#start-thread-in-forum-channel) |
| [StartThreadWithoutMessage](#StartThreadWithoutMessage-method)(…) | Creates a new thread that is not connected to an existing message. The created thread is always a GUILD_PRIVATE_THREAD See [Start Thread without Message](https://discord.com/developers/docs/resources/channel#start-thread-without-message) |
| [TriggerTypingIndicator](#TriggerTypingIndicator-method)(…) | Post a typing indicator for the specified channel. Generally bots should not implement this route. However, if a bot is responding to a command and expects the computation to take a few seconds, this endpoint may be called to let the user know that the bot is processing their message. See [Trigger Typing Indicator](https://discord.com/developers/docs/resources/channel#trigger-typing-indicator) |
| static [Create](#Create-method)(…) | Create a new channel object for the guild. Requires the MANAGE_CHANNELS permission. See [Create Guild Channel](https://discord.com/developers/docs/resources/guild#create-guild-channel) |
| static [Get](#Get-method)(…) | Get a channel by ID See [Get Channel](https://discord.com/developers/docs/resources/channel#get-channel) If the channel is a thread, a thread member object is included in the returned result. |

## See Also

* interface [IDebugLoggable](../../Interfaces/Logging/IDebugLoggable.md)
* interface [ISnowflakeEntity](../../Interfaces/ISnowflakeEntity.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [DiscordChannel.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Channels/DiscordChannel.cs)
   
   
# IsGuildChannel method

Returns if the channel is a guild channel

```csharp
public bool IsGuildChannel()
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# IsDmChannel method

Returns if a channel is a DM channel

```csharp
public bool IsDmChannel()
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# IsThreadChannel method

Returns if a channel is a thread channel

```csharp
public bool IsThreadChannel()
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Create method

Create a new channel object for the guild. Requires the MANAGE_CHANNELS permission. See [Create Guild Channel](https://discord.com/developers/docs/resources/guild#create-guild-channel)

```csharp
public static IPromise<DiscordChannel> Create(DiscordClient client, Snowflake guildId, 
    ChannelCreate channel)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to create the channel in |
| channel | Channel to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [ChannelCreate](./ChannelCreate.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Get method

Get a channel by ID See [Get Channel](https://discord.com/developers/docs/resources/channel#get-channel) If the channel is a thread, a thread member object is included in the returned result.

```csharp
public static IPromise<DiscordChannel> Get(DiscordClient client, Snowflake channelId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| channelId | ID of the channel to get |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EditGroupDmChannel method

Update a group dm channel's settings. See [Modify Channel](https://discord.com/developers/docs/resources/channel#modify-channel)

```csharp
public IPromise<DiscordChannel> EditGroupDmChannel(DiscordClient client, 
    GroupDmChannelUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to be made to the channel. All fields are optional |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [GroupDmChannelUpdate](./GroupDmChannelUpdate.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EditGuildChannel method

Update a guild channel's settings. Requires the MANAGE_CHANNELS permission for the guild. See [Modify Channel](https://discord.com/developers/docs/resources/channel#modify-channel)

```csharp
public IPromise<DiscordChannel> EditGuildChannel(DiscordClient client, GuildChannelUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to be made to the channel. All fields are optional |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [GuildChannelUpdate](./GuildChannelUpdate.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EditThreadChannel method

Update a thread channel's settings. Requires the MANAGE_THREADS permission for the guild. See [Modify Channel](https://discord.com/developers/docs/resources/channel#modify-channel)

```csharp
public IPromise<DiscordChannel> EditThreadChannel(DiscordClient client, ThreadChannelUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| update | Update to be made to the channel. All fields are optional |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ThreadChannelUpdate](./Threads/ThreadChannelUpdate.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Delete method

Delete a channel, or close a private message. Requires the MANAGE_CHANNELS or MANAGE_THREADS permission for the guild depending on the channel type. See [Delete/Close Channel](https://discord.com/developers/docs/resources/channel#deleteclose-channel)

```csharp
public IPromise<DiscordChannel> Delete(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetMessages method

Returns the messages for a channel. If operating on a guild channel, this endpoint requires the VIEW_CHANNEL permission to be present on the current user. If the current user is missing the 'READ_MESSAGE_HISTORY' permission in the channel then this will return no messages (since they cannot read the message history). See [Get Channel Messages](https://discord.com/developers/docs/resources/channel#get-channel-messages)

```csharp
public IPromise<List<DiscordMessage>> GetMessages(DiscordClient client, 
    ChannelMessagesRequest request = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| request | Optional request filters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](../Messages/DiscordMessage.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ChannelMessagesRequest](./ChannelMessagesRequest.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetMessage method

Returns a specific message in the channel. If operating on a guild channel, this endpoint requires the 'READ_MESSAGE_HISTORY' permission to be present on the current user. See [Get Channel Messages](https://discord.com/developers/docs/resources/channel#get-channel-message)

```csharp
public IPromise<DiscordMessage> GetMessage(DiscordClient client, Snowflake messageId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | Message ID of the message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](../Messages/DiscordMessage.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CreateMessage method (1 of 4)

Post a message to a guild text or DM channel. If operating on a guild channel, this endpoint requires the SEND_MESSAGES permission to be present on the current user. If the tts field is set to true, the SEND_TTS_MESSAGES permission is required for the message to be spoken. See [Create Message](https://discord.com/developers/docs/resources/channel#create-message)

```csharp
public IPromise<DiscordMessage> CreateMessage(DiscordClient client, DiscordEmbed embed)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| embed | Embed to be send in the message |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](../Messages/DiscordMessage.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordEmbed](../Messages/Embeds/DiscordEmbed.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# CreateGlobalTemplateMessage method

Creates a message in a text channel using a global message template

```csharp
public IPromise<DiscordMessage> CreateGlobalTemplateMessage(DiscordClient client, 
    string templateName, MessageCreate message = null, PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName | Template name |
| message | message to use (optional) |
| placeholders | Placeholders to apply (optional) |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](../Messages/DiscordMessage.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [MessageCreate](../Messages/MessageCreate.md)
* class [PlaceholderData](../../Libraries/Placeholders/PlaceholderData.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CreateTemplateMessage method

Creates a message in a text channel using a localized message template

```csharp
public IPromise<DiscordMessage> CreateTemplateMessage(DiscordClient client, string templateName, 
    string language = "en", MessageCreate message = null, PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| templateName | Template name |
| language | Oxide language for the template |
| message | message to use (optional) |
| placeholders | Placeholders to apply (optional) |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](../Messages/DiscordMessage.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [MessageCreate](../Messages/MessageCreate.md)
* class [PlaceholderData](../../Libraries/Placeholders/PlaceholderData.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# BulkDeleteMessages method

Delete multiple messages in a single request. This endpoint can only be used on guild channels and requires the MANAGE_MESSAGES permission. See [Bulk Delete Messages](https://discord.com/developers/docs/resources/channel#bulk-delete-messages)

```csharp
public IPromise BulkDeleteMessages(DiscordClient client, ICollection<Snowflake> messageIds)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageIds | Collect of message ids to delete (Between 2 - 100) |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EditPermissions method

Edit the channel permission overwrites for a user or role in a channel. Only usable for guild channels. Requires the MANAGE_ROLES permission. See [Edit Channel Permissions](https://discord.com/developers/docs/resources/channel#edit-channel-permissions)

```csharp
public IPromise EditPermissions(DiscordClient client, Overwrite overwrite)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| overwrite | Overwrite to edit with changes |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [Overwrite](./Overwrite.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DeletePermission method (1 of 2)

Delete a channel permission overwrite for a user or role in a channel. Only usable for guild channels. Requires the MANAGE_ROLES permission. See [Delete Channel Permission](https://discord.com/developers/docs/resources/channel#delete-channel-permission)

```csharp
public IPromise DeletePermission(DiscordClient client, Overwrite overwrite)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| overwrite | Overwrite to delete |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [Overwrite](./Overwrite.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# GetInvites method

Returns a list of invite objects (with invite metadata) for the channel. Only usable for guild channels. Requires the MANAGE_CHANNELS permission. See [Get Channel Invites](https://discord.com/developers/docs/resources/channel#get-channel-invites)

```csharp
public IPromise<List<DiscordInvite>> GetInvites(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## Exceptions

| exception | condition |
| --- | --- |
| Exception | Thrown when the channel type is Dm or GroupDm |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordInvite](../Invites/DiscordInvite.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CreateInvite method

Create a new invite object for the channel. Only usable for guild channels. Requires the CREATE_INSTANT_INVITE permission. See [Create Channel Invite](https://discord.com/developers/docs/resources/channel#create-channel-invite)

```csharp
public IPromise<DiscordInvite> CreateInvite(DiscordClient client, ChannelInvite invite)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| invite | Invite to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordInvite](../Invites/DiscordInvite.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ChannelInvite](./ChannelInvite.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# FollowNewsChannel method

Follow a News Channel to send messages to a target channel. Requires the MANAGE_WEBHOOKS permission in the target channel. See [Follow Announcement Channel](https://discord.com/developers/docs/resources/channel#follow-announcement-channel)

```csharp
public IPromise<FollowedChannel> FollowNewsChannel(DiscordClient client, Snowflake webhookChannelId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| webhookChannelId | ID of target channel |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [FollowedChannel](./FollowedChannel.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# TriggerTypingIndicator method

Post a typing indicator for the specified channel. Generally bots should not implement this route. However, if a bot is responding to a command and expects the computation to take a few seconds, this endpoint may be called to let the user know that the bot is processing their message. See [Trigger Typing Indicator](https://discord.com/developers/docs/resources/channel#trigger-typing-indicator)

```csharp
public IPromise TriggerTypingIndicator(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetPinnedMessages method

Returns all pinned messages in the channel See [Get Pinned Messages](https://discord.com/developers/docs/resources/channel#get-pinned-messages)

```csharp
public IPromise<List<DiscordMessage>> GetPinnedMessages(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordMessage](../Messages/DiscordMessage.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GroupDmAddRecipient method (1 of 2)

Adds a recipient to a Group DM using their access token See [Group DM Add Recipient](https://discord.com/developers/docs/resources/channel#group-dm-add-recipient)

```csharp
public IPromise GroupDmAddRecipient(DiscordClient client, DiscordUser user, string accessToken)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| user | User to add |
| accessToken | Users access token |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordUser](../Users/DiscordUser.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# GroupDmRemoveRecipient method

Removes a recipient from a Group DM See [Group DM Remove Recipient](https://discord.com/developers/docs/resources/channel#group-dm-remove-recipient)

```csharp
public IPromise GroupDmRemoveRecipient(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | User ID to remove |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# StartThreadFromMessage method

Creates a new public thread from a message See [Start Thread with Message](https://discord.com/developers/docs/resources/channel#start-thread-from-message)

```csharp
public IPromise<DiscordChannel> StartThreadFromMessage(DiscordClient client, Snowflake messageId, 
    ThreadCreateFromMessage create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| messageId | ID of the message to start the thread from |
| create | Data to use when creating the thread |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [ThreadCreateFromMessage](./Threads/ThreadCreateFromMessage.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# StartThreadWithoutMessage method

Creates a new thread that is not connected to an existing message. The created thread is always a GUILD_PRIVATE_THREAD See [Start Thread without Message](https://discord.com/developers/docs/resources/channel#start-thread-without-message)

```csharp
public IPromise<DiscordChannel> StartThreadWithoutMessage(DiscordClient client, ThreadCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| create | Data to use when creating the thread |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ThreadCreate](./Threads/ThreadCreate.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# StartThreadInForumChannel method

Creates a new thread in a forum channel, and sends a message within the created thread. Returns a channel, with a nested message object See [Start Thread in Forum Channel](https://discord.com/developers/docs/resources/channel#start-thread-in-forum-channel)

```csharp
public IPromise<DiscordChannel> StartThreadInForumChannel(DiscordClient client, 
    ThreadForumCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| create | Data to use when creating the thread |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ThreadForumCreate](./Threads/ThreadForumCreate.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# JoinThread method

Adds the bot to the thread. Also requires the thread is not archived. See [Join Thread](https://discord.com/developers/docs/resources/channel#join-thread)

```csharp
public IPromise JoinThread(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# AddThreadMember method

Adds another user to a thread. Requires the ability to send messages in the thread. Also requires the thread is not archived. See [Add Thread Member](https://discord.com/developers/docs/resources/channel#add-thread-member)

```csharp
public IPromise AddThreadMember(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | ID of the user to thread |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# LeaveThread method

Removes the bot from the thread. Also requires the thread is not archived. See [Leave Thread](https://discord.com/developers/docs/resources/channel#leave-thread)

```csharp
public IPromise LeaveThread(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# RemoveThreadMember method

Removes another user from a thread. Requires the MANAGE_THREADS permission or that you are the creator of the thread. Also requires the thread is not archived. See [Remove Thread Member](https://discord.com/developers/docs/resources/channel#remove-thread-member)

```csharp
public IPromise RemoveThreadMember(DiscordClient client, Snowflake userId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | ID of the user to thread |

## See Also

* interface [IPromise](../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetThreadMember method

Returns a thread member object for the specified user if they are a member of the thread returns a 404 response otherwise. See [Remove Thread Member](https://discord.com/developers/docs/resources/channel#get-thread-member)

```csharp
public IPromise<ThreadMember> GetThreadMember(DiscordClient client, Snowflake userId, 
    GetThreadMember request = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| userId | ID of the user to thread |
| request | Query String Arguments |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [ThreadMember](./Threads/ThreadMember.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* struct [Snowflake](../Snowflake.md)
* class [GetThreadMember](./Threads/GetThreadMember.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ListThreadMembers method

Returns array of thread members objects that are members of the thread. This endpoint is restricted according to whether the GUILD_MEMBERS Privileged Intent is enabled for your application. See [List Thread Members](https://discord.com/developers/docs/resources/channel#list-thread-members)

```csharp
public IPromise<List<ThreadMember>> ListThreadMembers(DiscordClient client, 
    ListThreadMembers request = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| request | Query string for the List Thread Members |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [ThreadMember](./Threads/ThreadMember.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ListThreadMembers](./Threads/ListThreadMembers.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ListPublicArchivedThreads method

Returns archived threads in the channel that are public. When called on a GUILD_TEXT channel, returns threads of type GUILD_PUBLIC_THREAD. When called on a GUILD_NEWS channel returns threads of type GUILD_NEWS_THREAD. Threads are ordered by archive_timestamp, in descending order. Requires the READ_MESSAGE_HISTORY permission. See [List Public Archived Threads](https://discord.com/developers/docs/resources/channel#list-public-archived-threads)

```csharp
public IPromise<ThreadList> ListPublicArchivedThreads(DiscordClient client, 
    ThreadArchivedLookup request = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| request | The options to use when looking up the archived threads |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [ThreadList](./Threads/ThreadList.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ThreadArchivedLookup](./Threads/ThreadArchivedLookup.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ListPrivateArchivedThreads method

Returns archived threads in the channel that are of type GUILD_PRIVATE_THREAD. Threads are ordered by archive_timestamp, in descending order. Requires both the READ_MESSAGE_HISTORY and MANAGE_THREADS permissions. See [List Private Archived Threads](https://discord.com/developers/docs/resources/channel#list-private-archived-threads)

```csharp
public IPromise<ThreadList> ListPrivateArchivedThreads(DiscordClient client, 
    ThreadArchivedLookup request = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| request | The options to use when looking up the archived threads |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [ThreadList](./Threads/ThreadList.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ThreadArchivedLookup](./Threads/ThreadArchivedLookup.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ListJoinedPrivateArchivedThreads method

Returns archived threads in the channel that are of type GUILD_PRIVATE_THREAD, and the user has joined. Threads are ordered by their id, in descending order. Requires the READ_MESSAGE_HISTORY permission. See [List Joined Private Archived Threads](https://discord.com/developers/docs/resources/channel#list-joined-private-archived-threads)

```csharp
public IPromise<ThreadList> ListJoinedPrivateArchivedThreads(DiscordClient client, 
    ThreadArchivedLookup lookup = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| lookup | The options to use when looking up the archived threads |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [ThreadList](./Threads/ThreadList.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [ThreadArchivedLookup](./Threads/ThreadArchivedLookup.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetStageInstance method

Gets the stage instance associated with the Stage channel, if it exists. See [Get Stage Instance](https://discord.com/developers/docs/resources/stage-instance#get-stage-instance)

```csharp
public IPromise<StageInstance> GetStageInstance(DiscordClient client)
```

| parameter | description |
| --- | --- |
| client | Client to use |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [StageInstance](./Stages/StageInstance.md)
* class [DiscordClient](../../Clients/DiscordClient.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../../Logging/DebugLogger.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DiscordChannel constructor

The default constructor.

```csharp
public DiscordChannel()
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Id property

The ID of this channel

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Type property

the type of channel [`ChannelType`](./ChannelType.md)

```csharp
public ChannelType Type { get; set; }
```

## See Also

* enum [ChannelType](./ChannelType.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GuildId property

the ID of the guild Warning: May be missing for some channel objects received over gateway guild dispatches

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Position property

Sorting position of the channel

```csharp
public int? Position { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# PermissionOverwrites property

Explicit permission overwrites for members and roles [`Overwrite`](./Overwrite.md)

```csharp
public Hash<Snowflake, Overwrite> PermissionOverwrites { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [Overwrite](./Overwrite.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Name property

The name of the channel (1-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Topic property

The channel topic (0-1024 characters)

```csharp
public string Topic { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Nsfw property

Whether the channel is nsfw

```csharp
public bool? Nsfw { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# LastMessageId property

The id of the last message sent in this channel (or thread for GUILD_FORUM channels) May not point to an existing or valid message or thread

```csharp
public Snowflake? LastMessageId { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Bitrate property

The bitrate (in bits) of the voice channel

```csharp
public int? Bitrate { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# UserLimit property

The user limit of the voice channel

```csharp
public int? UserLimit { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# RateLimitPerUser property

Amount of seconds a user has to wait before sending another message (0-21600); bots, as well as users with the permission manage_messages or manage_channel, are unaffected

```csharp
public int? RateLimitPerUser { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Recipients property

The recipients of the DM

```csharp
public Hash<Snowflake, DiscordUser> Recipients { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordUser](../Users/DiscordUser.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Icon property

icon hash of the group DM

```csharp
public string Icon { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# OwnerId property

ID of the DM creator

```csharp
public Snowflake? OwnerId { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ApplicationId property

Application id of the group DM creator if it is bot-created

```csharp
public Snowflake? ApplicationId { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Managed property

For group DM channels: whether the channel is managed by an application via the `gdm.join` OAuth2 scope

```csharp
public bool? Managed { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ParentId property

ID of the parent category for a channel (each parent category can contain up to 50 channels)

```csharp
public Snowflake? ParentId { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# LastPinTimestamp property

When the last pinned message was pinned. This may be null in events such as GUILD_CREATE when a message is not pinned.

```csharp
public DateTime? LastPinTimestamp { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# RtcRegion property

Voice region id for the voice channel, automatic when set to null

```csharp
public string RtcRegion { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# VideoQualityMode property

The camera video quality mode of the voice channel 1 when not present

```csharp
public VideoQualityMode? VideoQualityMode { get; set; }
```

## See Also

* enum [VideoQualityMode](./VideoQualityMode.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# MessageCount property

umber of messages (not including the initial messages or deleted messages) in a thread (if the thread was created before July 1, 2022, it stops counting at 50)

```csharp
public int? MessageCount { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# MemberCount property

An approximate count of users in a thread, stops counting at 50

```csharp
public int? MemberCount { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ThreadMetadata property

Thread-specific fields not needed by other channels

```csharp
public ThreadMetadata ThreadMetadata { get; set; }
```

## See Also

* class [ThreadMetadata](./Threads/ThreadMetadata.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Member property

Thread member object for the current user, if they have joined the thread, only included on certain API endpoints

```csharp
public ThreadMember Member { get; set; }
```

## See Also

* class [ThreadMember](./Threads/ThreadMember.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DefaultAutoArchiveDuration property

Default duration for newly created threads, in minutes, to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080

```csharp
public int? DefaultAutoArchiveDuration { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Permissions property

Default duration for newly created threads, in minutes, to automatically archive the thread after recent activity, can be set to: 60, 1440, 4320, 10080

```csharp
public string Permissions { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Flags property

Flags for this channel

```csharp
public ChannelFlags? Flags { get; set; }
```

## See Also

* enum [ChannelFlags](./ChannelFlags.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# TotalMessageSent property

Number of messages ever sent in a thread, it's similar to message_count on message creation, but will not decrement the number when a message is deleted

```csharp
public int? TotalMessageSent { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# AvailableTags property

The set of tags that can be used in a GUILD_FORUM channel Limited to 20

```csharp
public List<ForumTag> AvailableTags { get; set; }
```

## See Also

* class [ForumTag](./ForumTag.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# AppliedTags property

The IDs of the set of tags that have been applied to a thread in a GUILD_FORUM channel

```csharp
public List<Snowflake> AppliedTags { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DefaultReactionEmoji property

The emoji to show in the add reaction button on a thread in a GUILD_FORUM channel

```csharp
public DefaultReaction DefaultReactionEmoji { get; set; }
```

## See Also

* class [DefaultReaction](../Emojis/DefaultReaction.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DefaultThreadRateLimitPerUser property

The initial rate_limit_per_user to set on newly created threads in a channel. this field is copied to the thread at creation time and does not live update.

```csharp
public int? DefaultThreadRateLimitPerUser { get; set; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DefaultSortOrder property

The default [`SortOrderType`](./SortOrderType.md) used to order posts in `GUILD_FORUM` channels

```csharp
public SortOrderType? DefaultSortOrder { get; set; }
```

## See Also

* enum [SortOrderType](./SortOrderType.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DefaultForumLayout property

The default [`ForumLayoutTypes`](./ForumLayoutTypes.md) used to display posts in GUILD_FORUM channels. Defaults to NotSet, which indicates a layout view has not been set by a channel admin

```csharp
public ForumLayoutTypes? DefaultForumLayout { get; set; }
```

## See Also

* enum [ForumLayoutTypes](./ForumLayoutTypes.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ThreadMembers property

List of thread members if channel is thread; Null Otherwise.

```csharp
public Hash<Snowflake, ThreadMember> ThreadMembers { get; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [ThreadMember](./Threads/ThreadMember.md)
* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Mention property

Returns a string to mention this channel in a message

```csharp
public string Mention { get; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# IconUrl property

Returns the Icon URL for the given channel

```csharp
public string IconUrl { get; }
```

## See Also

* class [DiscordChannel](./DiscordChannel.md)
* namespace [Oxide.Ext.Discord.Entities.Channels](./ChannelsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->