# GuildScheduledEvent class

Represents [Guild Scheduled Event Structure](https://discord.com/developers/docs/resources/guild-scheduled-event)

```csharp
public class GuildScheduledEvent : ISnowflakeEntity
```

## Public Members

| name | description |
| --- | --- |
| [GuildScheduledEvent](#GuildScheduledEvent-constructor)() | The default constructor. |
| [ChannelId](#ChannelId-property) { get; set; } | The channel ID in which the scheduled event will be hosted, or null if [`scheduled entity type`](./ScheduledEventEntityType.md) is EXTERNAL |
| [Creator](#Creator-property) { get; set; } | The user that created the scheduled event |
| [CreatorId](#CreatorId-property) { get; set; } | The ID of the user that created the scheduled event |
| [Description](#Description-property) { get; set; } | The description of the scheduled event (1-1000 characters) |
| [EntityId](#EntityId-property) { get; set; } | The id of an entity associated with a guild scheduled event |
| [EntityMetadata](#EntityMetadata-property) { get; set; } | Additional metadata for the guild scheduled event |
| [EntityType](#EntityType-property) { get; set; } | The type of the scheduled event |
| [GuildId](#GuildId-property) { get; set; } | The guild ID which the scheduled event belongs to |
| [Id](#Id-property) { get; set; } | The ID of the scheduled event |
| [Name](#Name-property) { get; set; } | The name of the scheduled event (1-100 characters) |
| [PrivacyLevel](#PrivacyLevel-property) { get; set; } | The privacy level of the scheduled event |
| [ScheduledEndTime](#ScheduledEndTime-property) { get; set; } | The time the scheduled event will end, required if [`EntityType`](./GuildScheduledEvent/EntityType.md) is EXTERNAL |
| [ScheduledStartTime](#ScheduledStartTime-property) { get; set; } | The time the scheduled event will start |
| [Status](#Status-property) { get; set; } | The status of the scheduled event |
| [UserCount](#UserCount-property) { get; set; } | The number of users subscribed to the scheduled event |
| [Delete](#Delete-method)(…) | Delete a guild scheduled event See [Delete Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#delete-guild-scheduled-event) |
| [Edit](#Edit-method)(…) | Modify a guild scheduled event. Returns the modified [`guild scheduled event`](./GuildScheduledEvent.md) object on success. See [Modify Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#modify-guild-scheduled-event) |
| static [Create](#Create-method)(…) | Create a guild scheduled event in the guild. Returns a [`guild scheduled event`](./GuildScheduledEvent.md) object on success. See [Create Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#create-guild-scheduled-event) |
| static [Get](#Get-method)(…) | Get a guild scheduled event. Returns a guild scheduled event object on success. See [Get Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#get-guild-scheduled-event) |
| static [GetGuildEvents](#GetGuildEvents-method)(…) | Returns a list of guild scheduled event objects for the given guild. See [List Scheduled Events for Guild](https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild) |
| static [GetUsers](#GetUsers-method)(…) | Get a list of guild scheduled event users subscribed to a guild scheduled event. Returns a list of guild scheduled event user objects on success. Guild member data, if it exists, is included if the WithMember query parameter is set. See [Get Guild Scheduled Event Users](https://discord.com/developers/docs/resources/guild-scheduled-event#get-guild-scheduled-event-users) |

## See Also

* interface [ISnowflakeEntity](../../../Interfaces/ISnowflakeEntity.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [GuildScheduledEvent.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Guilds/ScheduledEvents/GuildScheduledEvent.cs)
   
   
# GetGuildEvents method

Returns a list of guild scheduled event objects for the given guild. See [List Scheduled Events for Guild](https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild)

```csharp
public static IPromise<List<GuildScheduledEvent>> GetGuildEvents(DiscordClient client, 
    Snowflake guildId, ScheduledEventLookup lookup = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to get events for |
| lookup | Query string parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [ScheduledEventLookup](./ScheduledEventLookup.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Create method

Create a guild scheduled event in the guild. Returns a [`guild scheduled event`](./GuildScheduledEvent.md) object on success. See [Create Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#create-guild-scheduled-event)

```csharp
public static IPromise<GuildScheduledEvent> Create(DiscordClient client, Snowflake guildId, 
    ScheduledEventCreate create)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to create event in |
| create | Guild Scheduled Event to create |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [ScheduledEventCreate](./ScheduledEventCreate.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Get method

Get a guild scheduled event. Returns a guild scheduled event object on success. See [Get Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#get-guild-scheduled-event)

```csharp
public static IPromise<GuildScheduledEvent> Get(DiscordClient client, Snowflake guildId, 
    Snowflake eventId, ScheduledEventLookup lookup = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to get events for |
| eventId | Id of the scheduled event |
| lookup | Query string parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [ScheduledEventLookup](./ScheduledEventLookup.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Edit method

Modify a guild scheduled event. Returns the modified [`guild scheduled event`](./GuildScheduledEvent.md) object on success. See [Modify Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#modify-guild-scheduled-event)

```csharp
public IPromise<GuildScheduledEvent> Edit(DiscordClient client, Snowflake guildId, 
    Snowflake eventId, ScheduledEventUpdate update)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to modify event in |
| eventId | Id of the event to update |
| update | Guild Scheduled Event to update |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [ScheduledEventUpdate](./ScheduledEventUpdate.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Delete method

Delete a guild scheduled event See [Delete Guild Scheduled Event](https://discord.com/developers/docs/resources/guild-scheduled-event#delete-guild-scheduled-event)

```csharp
public IPromise Delete(DiscordClient client, Snowflake guildId, Snowflake eventId)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to modify event in |
| eventId | Id of the event to delete |

## See Also

* interface [IPromise](../../../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# GetUsers method

Get a list of guild scheduled event users subscribed to a guild scheduled event. Returns a list of guild scheduled event user objects on success. Guild member data, if it exists, is included if the WithMember query parameter is set. See [Get Guild Scheduled Event Users](https://discord.com/developers/docs/resources/guild-scheduled-event#get-guild-scheduled-event-users)

```csharp
public static IPromise<List<ScheduledEventUser>> GetUsers(DiscordClient client, Snowflake guildId, 
    Snowflake eventId, ScheduledEventUsersLookup lookup = null)
```

| parameter | description |
| --- | --- |
| client | Client to use |
| guildId | Guild to get event users for |
| eventId | Id of the event to get users for |
| lookup | Query string parameters |

## See Also

* interface [IPromise&lt;TPromised&gt;](../../../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [ScheduledEventUser](./ScheduledEventUser.md)
* class [DiscordClient](../../../Clients/DiscordClient.md)
* struct [Snowflake](../../Snowflake.md)
* class [ScheduledEventUsersLookup](./ScheduledEventUsersLookup.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# GuildScheduledEvent constructor

The default constructor.

```csharp
public GuildScheduledEvent()
```

## See Also

* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Id property

The ID of the scheduled event

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# GuildId property

The guild ID which the scheduled event belongs to

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# ChannelId property

The channel ID in which the scheduled event will be hosted, or null if [`scheduled entity type`](./ScheduledEventEntityType.md) is EXTERNAL

```csharp
public Snowflake? ChannelId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# CreatorId property

The ID of the user that created the scheduled event

```csharp
public Snowflake? CreatorId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Name property

The name of the scheduled event (1-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Description property

The description of the scheduled event (1-1000 characters)

```csharp
public string Description { get; set; }
```

## See Also

* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# ScheduledStartTime property

The time the scheduled event will start

```csharp
public DateTime ScheduledStartTime { get; set; }
```

## See Also

* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# ScheduledEndTime property

The time the scheduled event will end, required if [`EntityType`](./GuildScheduledEvent/EntityType) is EXTERNAL

```csharp
public DateTime? ScheduledEndTime { get; set; }
```

## See Also

* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# PrivacyLevel property

The privacy level of the scheduled event

```csharp
public ScheduledEventPrivacyLevel PrivacyLevel { get; set; }
```

## See Also

* enum [ScheduledEventPrivacyLevel](./ScheduledEventPrivacyLevel.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Status property

The status of the scheduled event

```csharp
public ScheduledEventStatus Status { get; set; }
```

## See Also

* enum [ScheduledEventStatus](./ScheduledEventStatus.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# EntityType property

The type of the scheduled event

```csharp
public ScheduledEventEntityType EntityType { get; set; }
```

## See Also

* enum [ScheduledEventEntityType](./ScheduledEventEntityType.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# EntityId property

The id of an entity associated with a guild scheduled event

```csharp
public Snowflake? EntityId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# EntityMetadata property

Additional metadata for the guild scheduled event

```csharp
public ScheduledEventEntityMetadata EntityMetadata { get; set; }
```

## See Also

* class [ScheduledEventEntityMetadata](./ScheduledEventEntityMetadata.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Creator property

The user that created the scheduled event

```csharp
public DiscordUser Creator { get; set; }
```

## See Also

* class [DiscordUser](../../Users/DiscordUser.md)
* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# UserCount property

The number of users subscribed to the scheduled event

```csharp
public int? UserCount { get; set; }
```

## See Also

* class [GuildScheduledEvent](./GuildScheduledEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->