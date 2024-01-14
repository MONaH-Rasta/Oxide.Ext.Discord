# DiscordTeam class

Represents a [Team Object](https://discord.com/developers/docs/topics/teams#data-models-team-object)

```csharp
public class DiscordTeam
```

## Public Members

| name | description |
| --- | --- |
| [DiscordTeam](#discordteam-constructor)() | The default constructor. |
| [GetTeamIconUrl](#getteamiconurl-property) { get; } | Returns the url for the team icon |
| [Icon](#icon-property) { get; set; } | Hash of the image of the team's icon |
| [Id](#id-property) { get; set; } | Unique ID of the team |
| [Members](#members-property) { get; set; } | Members of the team See [`TeamMember`](./TeamMember.md) |
| [Name](#name-property) { get; set; } | Name of the team |
| [OwnerUserId](#owneruserid-property) { get; set; } | User ID of the current team owner |
| [Role](#role-property) { get; set; } | Role of the team member |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordTeam.cs](../../../../Oxide.Ext.Discord/Entities/DiscordTeam.cs)
   
   
# DiscordTeam constructor

The default constructor.

```csharp
public DiscordTeam()
```

## See Also

* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Id property

Unique ID of the team

```csharp
public Snowflake Id { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Icon property

Hash of the image of the team's icon

```csharp
public string Icon { get; set; }
```

## See Also

* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Members property

Members of the team See [`TeamMember`](./TeamMember.md)

```csharp
public List<TeamMember> Members { get; set; }
```

## See Also

* class [TeamMember](./TeamMember.md)
* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Name of the team

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# OwnerUserId property

User ID of the current team owner

```csharp
public Snowflake OwnerUserId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Role property

Role of the team member

```csharp
public TeamRole Role { get; set; }
```

## See Also

* enum [TeamRole](./TeamRole.md)
* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetTeamIconUrl property

Returns the url for the team icon

```csharp
public string GetTeamIconUrl { get; }
```

## See Also

* class [DiscordTeam](./DiscordTeam.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->