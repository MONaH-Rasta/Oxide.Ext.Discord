# DiscordLink class

Represents a library for discord linking

```csharp
public class DiscordLink : BaseDiscordLibrary<DiscordLink>, IDebugLoggable
```

## Public Members

| name | description |
| --- | --- |
| [IsEnabled](#IsEnabled-property) { get; } | Returns if there is a registered link plugin |
| [LinkedCount](#LinkedCount-property) { get; } | Returns the number of linked players |
| readonly [DiscordIds](#DiscordIds-field) | Readonly Collection of all Discord ID's |
| readonly [DiscordToPlayerIds](#DiscordToPlayerIds-field) | Readonly Dictionary of Discord ID's to Player ID's |
| readonly [PlayerIds](#PlayerIds-field) | Readonly Collection of all Player ID's |
| readonly [PlayerToDiscordIds](#PlayerToDiscordIds-field) | Readonly Dictionary of Player ID's to Discord ID's |
| [AddLinkPlugin](#AddLinkPlugin-method)(…) | Adds a link plugin to be the plugin used with the Discord Link library |
| [GetDiscordId](#GetDiscordId-method)(…) | Returns the Discord ID for the given Steam ID (2 methods) |
| [GetDiscordUser](#GetDiscordUser-method)(…) | Returns a minimal Discord User (2 methods) |
| [GetLinkedMember](#GetLinkedMember-method)(…) | Returns a linked guild member for the matching steam id in the given guild (2 methods) |
| [GetPlayer](#GetPlayer-method)(…) | Returns the IPlayer for the given Discord ID |
| [GetPlayerId](#GetPlayerId-method)(…) | Returns the Player ID of the given Discord ID if there is a link (2 methods) |
| [IsLinked](#IsLinked-method)(…) | Returns if the specified ID is linked (4 methods) |
| [LogDebug](#LogDebug-method)(…) |  |
| [OnLinked](#OnLinked-method)(…) | Called by a link plugin when a link occured |
| [OnUnlinked](#OnUnlinked-method)(…) | Called by a link plugin when an unlink occured |
| [RemoveLinkPlugin](#RemoveLinkPlugin-method)(…) | Removes a link plugin from the Discord Link library |

## Protected Members

| name | description |
| --- | --- |
| override [OnPluginUnloaded](#OnPluginUnloaded-method)(…) |  |

## See Also

* class [BaseDiscordLibrary&lt;TLibrary&gt;](../BaseDiscordLibrary%7BTLibrary%7D.md)
* interface [IDebugLoggable](../../Interfaces/Logging/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [DiscordLink.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Libraries/Linking/DiscordLink.cs)
   
   
# AddLinkPlugin method

Adds a link plugin to be the plugin used with the Discord Link library

```csharp
public void AddLinkPlugin(IDiscordLinkPlugin plugin)
```

| parameter | description |
| --- | --- |
| plugin |  |

## See Also

* interface [IDiscordLinkPlugin](./IDiscordLinkPlugin.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# RemoveLinkPlugin method

Removes a link plugin from the Discord Link library

```csharp
public void RemoveLinkPlugin(IDiscordLinkPlugin plugin)
```

| parameter | description |
| --- | --- |
| plugin |  |

## See Also

* interface [IDiscordLinkPlugin](./IDiscordLinkPlugin.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# OnPluginUnloaded method

```csharp
protected override void OnPluginUnloaded(Plugin plugin)
```

## See Also

* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# IsLinked method (1 of 4)

Returns if the specified ID is linked

```csharp
public bool IsLinked(DiscordUser user)
```

| parameter | description |
| --- | --- |
| user | Discord user to check |

## Return Value

True if the user is linked; false otherwise

## See Also

* class [DiscordUser](../../Entities/Users/DiscordUser.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# GetPlayerId method (1 of 2)

Returns the Player ID of the given Discord ID if there is a link

```csharp
public PlayerId GetPlayerId(DiscordUser user)
```

| parameter | description |
| --- | --- |
| user | [`DiscordUser`](../../Entities/Users/DiscordUser.md) to get steam Id for |

## Return Value

Steam ID of the given given discord ID if linked; null otherwise

## See Also

* struct [PlayerId](./PlayerId.md)
* class [DiscordUser](../../Entities/Users/DiscordUser.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# GetPlayer method

Returns the IPlayer for the given Discord ID

```csharp
public IPlayer GetPlayer(Snowflake discordId)
```

| parameter | description |
| --- | --- |
| discordId | Discord ID to get IPlayer for |

## Return Value

IPlayer for the given Discord ID; null otherwise

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetDiscordId method (1 of 2)

Returns the Discord ID for the given IPlayer

```csharp
public Snowflake GetDiscordId(IPlayer player)
```

| parameter | description |
| --- | --- |
| player | Player to get Discord ID for |

## Return Value

Discord ID for the given Steam ID; null otherwise

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# GetDiscordUser method (1 of 2)

Returns a minimal Discord User

```csharp
public DiscordUser GetDiscordUser(IPlayer player)
```

| parameter | description |
| --- | --- |
| player | Player to get the Discord User for |

## Return Value

Discord ID for the given IPlayer; null otherwise

## See Also

* class [DiscordUser](../../Entities/Users/DiscordUser.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# GetLinkedMember method (1 of 2)

Returns a linked guild member for the matching IPlayer in the given guild

```csharp
public GuildMember GetLinkedMember(IPlayer player, DiscordGuild guild)
```

| parameter | description |
| --- | --- |
| player | Player to get the Discord User for |
| guild | Guild the member is in |

## Return Value

Discord ID for the given Steam ID; null otherwise

## See Also

* class [GuildMember](../../Entities/Guilds/GuildMember.md)
* class [DiscordGuild](../../Entities/Guilds/DiscordGuild.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

---
   
   
# OnLinked method

Called by a link plugin when a link occured

```csharp
public void OnLinked(Plugin plugin, IPlayer player, DiscordUser discord)
```

| parameter | description |
| --- | --- |
| plugin | Plugin that initiated the link |
| player | Player being linked |
| discord | DiscordUser being linked |

## See Also

* class [DiscordUser](../../Entities/Users/DiscordUser.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# OnUnlinked method

Called by a link plugin when an unlink occured

```csharp
public void OnUnlinked(Plugin plugin, IPlayer player, DiscordUser discord)
```

| parameter | description |
| --- | --- |
| plugin | Plugin that is unlinking |
| player | Player being unlinked |
| discord | DiscordUser being unlinked |

## See Also

* class [DiscordUser](../../Entities/Users/DiscordUser.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../../Logging/DebugLogger.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# IsEnabled property

Returns if there is a registered link plugin

```csharp
public bool IsEnabled { get; }
```

## See Also

* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# LinkedCount property

Returns the number of linked players

```csharp
public int LinkedCount { get; }
```

## See Also

* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# PlayerToDiscordIds field

Readonly Dictionary of Player ID's to Discord ID's

```csharp
public readonly IReadOnlyDictionary<PlayerId, Snowflake> PlayerToDiscordIds;
```

## See Also

* struct [PlayerId](./PlayerId.md)
* struct [Snowflake](../../Entities/Snowflake.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DiscordToPlayerIds field

Readonly Dictionary of Discord ID's to Player ID's

```csharp
public readonly IReadOnlyDictionary<Snowflake, PlayerId> DiscordToPlayerIds;
```

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* struct [PlayerId](./PlayerId.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# PlayerIds field

Readonly Collection of all Player ID's

```csharp
public readonly ICollection<PlayerId> PlayerIds;
```

## See Also

* struct [PlayerId](./PlayerId.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# DiscordIds field

Readonly Collection of all Discord ID's

```csharp
public readonly ICollection<Snowflake> DiscordIds;
```

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* class [DiscordLink](./DiscordLink.md)
* namespace [Oxide.Ext.Discord.Libraries.Linking](./LinkingNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->