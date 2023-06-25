# GuildRoleCreatedEvent class

Represents [Guild Role Create](https://discord.com/developers/docs/topics/gateway#guild-role-create)

```csharp
public class GuildRoleCreatedEvent
```

## Public Members

| name | description |
| --- | --- |
| [GuildRoleCreatedEvent](#GuildRoleCreatedEvent-constructor)() | The default constructor. |
| [GuildId](#GuildId-property) { get; set; } | The id of the guild |
| [Role](#Role-property) { get; set; } | The role created |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [GuildRoleCreatedEvent.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Gateway/Events/GuildRoleCreatedEvent.cs)
   
   
# GuildRoleCreatedEvent constructor

The default constructor.

```csharp
public GuildRoleCreatedEvent()
```

## See Also

* class [GuildRoleCreatedEvent](./GuildRoleCreatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# GuildId property

The id of the guild

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildRoleCreatedEvent](./GuildRoleCreatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Role property

The role created

```csharp
public DiscordRole Role { get; set; }
```

## See Also

* class [DiscordRole](../../Permissions/DiscordRole.md)
* class [GuildRoleCreatedEvent](./GuildRoleCreatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->