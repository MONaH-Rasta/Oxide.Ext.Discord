# GuildRoleUpdatedEvent class

Represents [Guild Role Update](https://discord.com/developers/docs/topics/gateway#guild-role-update)

```csharp
public class GuildRoleUpdatedEvent
```

## Public Members

| name | description |
| --- | --- |
| [GuildRoleUpdatedEvent](#GuildRoleUpdatedEvent-constructor)() | The default constructor. |
| [GuildId](#GuildId-property) { get; set; } | The id of the guild |
| [Role](#Role-property) { get; set; } | The role updated |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [GuildRoleUpdatedEvent.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Gateway/Events/GuildRoleUpdatedEvent.cs)
   
   
# GuildRoleUpdatedEvent constructor

The default constructor.

```csharp
public GuildRoleUpdatedEvent()
```

## See Also

* class [GuildRoleUpdatedEvent](./GuildRoleUpdatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# GuildId property

The id of the guild

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](../../Snowflake.md)
* class [GuildRoleUpdatedEvent](./GuildRoleUpdatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Role property

The role updated

```csharp
public DiscordRole Role { get; set; }
```

## See Also

* class [DiscordRole](../../Permissions/DiscordRole.md)
* class [GuildRoleUpdatedEvent](./GuildRoleUpdatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway.Events](./EventsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->