# IntegrationCreatedEvent class

Represents a [Integration Create Structure](https://discord.com/developers/docs/topics/gateway#integration-create-integration-create-event-additional-fields)

```csharp
public class IntegrationCreatedEvent : Integration
```

## Public Members

| name | description |
| --- | --- |
| [IntegrationCreatedEvent](#integrationcreatedevent-constructor)() | The default constructor. |
| [GuildId](#guildid-property) { get; set; } | Guild Id the Integration was created in |

## See Also

* class [Integration](./Integration.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [IntegrationCreatedEvent.cs](../../../../Oxide.Ext.Discord/Entities/IntegrationCreatedEvent.cs)
   
   
# IntegrationCreatedEvent constructor

The default constructor.

```csharp
public IntegrationCreatedEvent()
```

## See Also

* class [IntegrationCreatedEvent](./IntegrationCreatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

Guild Id the Integration was created in

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [IntegrationCreatedEvent](./IntegrationCreatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
