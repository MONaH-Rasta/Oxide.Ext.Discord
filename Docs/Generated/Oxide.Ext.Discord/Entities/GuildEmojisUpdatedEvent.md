# GuildEmojisUpdatedEvent class

Represents [Guild Emojis Update](https://discord.com/developers/docs/topics/gateway#guild-emojis-update)

```csharp
public class GuildEmojisUpdatedEvent
```

## Public Members

| name | description |
| --- | --- |
| [GuildEmojisUpdatedEvent](#guildemojisupdatedevent-constructor)() | The default constructor. |
| [Emojis](#emojis-property) { get; set; } | List of emojis |
| [GuildId](#guildid-property) { get; set; } | ID of the guild |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [GuildEmojisUpdatedEvent.cs](../../../../Oxide.Ext.Discord/Entities/GuildEmojisUpdatedEvent.cs)
   
   
# GuildEmojisUpdatedEvent constructor

The default constructor.

```csharp
public GuildEmojisUpdatedEvent()
```

## See Also

* class [GuildEmojisUpdatedEvent](./GuildEmojisUpdatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GuildId property

ID of the guild

```csharp
public Snowflake GuildId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [GuildEmojisUpdatedEvent](./GuildEmojisUpdatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Emojis property

List of emojis

```csharp
public Hash<Snowflake, DiscordEmoji> Emojis { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [DiscordEmoji](./DiscordEmoji.md)
* class [GuildEmojisUpdatedEvent](./GuildEmojisUpdatedEvent.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
