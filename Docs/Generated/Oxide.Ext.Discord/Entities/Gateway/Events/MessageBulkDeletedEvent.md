# MessageBulkDeletedEvent class

Represents [Message Delete Bulk](https://discord.com/developers/docs/topics/gateway#message-delete-bulk)

```csharp
public class MessageBulkDeletedEvent
```

## Public Members

| name | description |
| --- | --- |
| [MessageBulkDeletedEvent](#MessageBulkDeletedEvent-constructor)() | The default constructor. |
| [ChannelId](#ChannelId-property) { get; set; } | The id of the channel |
| [GuildId](#GuildId-property) { get; set; } | The id of the guild |
| [Ids](#Ids-property) { get; set; } | The ids of the messages |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [MessageBulkDeletedEvent.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Gateway/Events/MessageBulkDeletedEvent.cs)
   
   
# MessageBulkDeletedEvent constructor

The default constructor.

```csharp
public MessageBulkDeletedEvent()
```

## See Also

* class [MessageBulkDeletedEvent](./MessageBulkDeletedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Ids property

The ids of the messages

```csharp
public List<Snowflake> Ids { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [MessageBulkDeletedEvent](./MessageBulkDeletedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# ChannelId property

The id of the channel

```csharp
public Snowflake ChannelId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [MessageBulkDeletedEvent](./MessageBulkDeletedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# GuildId property

The id of the guild

```csharp
public Snowflake? GuildId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [MessageBulkDeletedEvent](./MessageBulkDeletedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->