# ScheduledEventLookup class

Represents a [Scheduled Event Lookup Structure](https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild-query-string-params) within Discord.

```csharp
public class ScheduledEventLookup : IDiscordQueryString
```

## Public Members

| name | description |
| --- | --- |
| [ScheduledEventLookup](#ScheduledEventLookup-constructor)() | The default constructor. |
| [WithUserCount](#WithUserCount-property) { get; set; } | Include number of users subscribed to each event |
| [ToQueryString](#ToQueryString-method)() |  |

## See Also

* interface [IDiscordQueryString](../../../Interfaces/IDiscordQueryString.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [ScheduledEventLookup.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Guilds/ScheduledEvents/ScheduledEventLookup.cs)
   
   
# ToQueryString method

```csharp
public string ToQueryString()
```

## See Also

* class [ScheduledEventLookup](./ScheduledEventLookup.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# ScheduledEventLookup constructor

The default constructor.

```csharp
public ScheduledEventLookup()
```

## See Also

* class [ScheduledEventLookup](./ScheduledEventLookup.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# WithUserCount property

Include number of users subscribed to each event

```csharp
public bool? WithUserCount { get; set; }
```

## See Also

* class [ScheduledEventLookup](./ScheduledEventLookup.md)
* namespace [Oxide.Ext.Discord.Entities.Guilds.ScheduledEvents](./ScheduledEventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->