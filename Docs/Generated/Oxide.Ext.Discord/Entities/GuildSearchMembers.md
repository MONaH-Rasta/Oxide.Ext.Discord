# GuildSearchMembers class

Represents [Search Guild Members](https://discord.com/developers/docs/resources/guild#search-guild-members-query-string-params) Structure

```csharp
public class GuildSearchMembers : IDiscordQueryString
```

## Public Members

| name | description |
| --- | --- |
| [GuildSearchMembers](#guildsearchmembers-constructor)() | The default constructor. |
| [Limit](#limit-property) { get; set; } | Max number of members to return (1-1000) Default is 1 |
| [Query](#query-property) { get; set; } | Query string to match username(s) and nickname(s) against. |
| [ToQueryString](#toquerystring-method)() |  |
| [Validate](#validate-method)() |  |

## See Also

* interface [IDiscordQueryString](../Interfaces/IDiscordQueryString.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [GuildSearchMembers.cs](../../../../Oxide.Ext.Discord/Entities/GuildSearchMembers.cs)
   
   
# ToQueryString method

```csharp
public string ToQueryString()
```

## See Also

* class [GuildSearchMembers](./GuildSearchMembers.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Validate method

```csharp
public void Validate()
```

## See Also

* class [GuildSearchMembers](./GuildSearchMembers.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildSearchMembers constructor

The default constructor.

```csharp
public GuildSearchMembers()
```

## See Also

* class [GuildSearchMembers](./GuildSearchMembers.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Query property

Query string to match username(s) and nickname(s) against.

```csharp
public string Query { get; set; }
```

## See Also

* class [GuildSearchMembers](./GuildSearchMembers.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Limit property

Max number of members to return (1-1000) Default is 1

```csharp
public int? Limit { get; set; }
```

## See Also

* class [GuildSearchMembers](./GuildSearchMembers.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
