# EmojiUpdate class

Represents [Emoji Update Structure](https://discord.com/developers/docs/resources/emoji#modify-guild-emoji-json-params)

```csharp
public class EmojiUpdate
```

## Public Members

| name | description |
| --- | --- |
| [EmojiUpdate](#EmojiUpdate-constructor)() | The default constructor. |
| [Name](#Name-property) { get; set; } | Emoji name |
| [Roles](#Roles-property) { get; set; } | Roles this emoji is whitelisted to |
| [Validate](#Validate-method)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Emojis](./EmojisNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [EmojiUpdate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Emojis/EmojiUpdate.cs)
   
   
# Validate method

```csharp
public void Validate()
```

## See Also

* class [EmojiUpdate](./EmojiUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Emojis](./EmojisNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EmojiUpdate constructor

The default constructor.

```csharp
public EmojiUpdate()
```

## See Also

* class [EmojiUpdate](./EmojiUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Emojis](./EmojisNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Name property

Emoji name

```csharp
public string Name { get; set; }
```

## See Also

* class [EmojiUpdate](./EmojiUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Emojis](./EmojisNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Roles property

Roles this emoji is whitelisted to

```csharp
public List<Snowflake> Roles { get; set; }
```

## See Also

* struct [Snowflake](../Snowflake.md)
* class [EmojiUpdate](./EmojiUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Emojis](./EmojisNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->