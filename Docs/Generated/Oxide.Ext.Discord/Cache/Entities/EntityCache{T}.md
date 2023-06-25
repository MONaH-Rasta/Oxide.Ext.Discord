# EntityCache&lt;T&gt; class

Cache for {T}

```csharp
public sealed class EntityCache<T> : Singleton<EntityCache>
    where T : class, IDiscordCacheable<T>, new()
```

## Public Members

| name | description |
| --- | --- |
| readonly [Cache](#Cache-field) | Readonly Cache of [`DiscordUser`](../../Entities/Users/DiscordUser.md) |
| [Get](#Get-method)(…) | Returns the cached entity with the given ID; default(T) otherwise |
| [GetOrCreate](#GetOrCreate-method)(…) | Returns a cached for the given user ID or creates a new with that ID |
| [Update](#Update-method)(…) | Updates the cached entity |

## See Also

* class [Singleton&lt;T&gt;](../../Singleton/Singleton%7BT%7D.md)
* interface [IDiscordCacheable&lt;T&gt;](../../Interfaces/IDiscordCacheable%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [EntityCache.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Cache/Entities/EntityCache.cs)
   
   
# Get method

Returns the cached entity with the given ID; default(T) otherwise

```csharp
public T Get(Snowflake id)
```

| parameter | description |
| --- | --- |
| id | ID of the entity |

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* class [EntityCache&lt;T&gt;](./EntityCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# GetOrCreate method

Returns a cached for the given user ID or creates a new with that ID

```csharp
public T GetOrCreate(Snowflake id)
```

| parameter | description |
| --- | --- |
| id | User ID to lookup in the cache |

## Return Value

Cached [`DiscordUser`](../../Entities/Users/DiscordUser.md)

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* class [EntityCache&lt;T&gt;](./EntityCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Update method

Updates the cached entity

```csharp
public T Update(T entity)
```

| parameter | description |
| --- | --- |
| entity |  |

## See Also

* class [EntityCache&lt;T&gt;](./EntityCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Cache field

Readonly Cache of [`DiscordUser`](../../Entities/Users/DiscordUser.md)

```csharp
public readonly IReadOnlyDictionary<Snowflake, T> Cache;
```

## See Also

* struct [Snowflake](../../Entities/Snowflake.md)
* class [EntityCache&lt;T&gt;](./EntityCache%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Cache.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->