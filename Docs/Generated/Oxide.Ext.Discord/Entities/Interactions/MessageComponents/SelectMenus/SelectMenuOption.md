# SelectMenuOption class

Represents a [Select Menu Option Structure](https://discord.com/developers/docs/interactions/message-components#select-option-structure) within discord.

```csharp
public class SelectMenuOption
```

## Public Members

| name | description |
| --- | --- |
| [SelectMenuOption](#SelectMenuOption-constructor)() | The default constructor. |
| [Default](#Default-property) { get; set; } | Will show this option as selected by default |
| [Description](#Description-property) { get; set; } | Additional description of the option, Max 100 characters |
| [Emoji](#Emoji-property) { get; set; } | Emoji in the option |
| [Label](#Label-property) { get; set; } | User-facing name of the option, Max 100 characters |
| [Value](#Value-property) { get; set; } | Dev-define value of the option, Max 100 characters |
| [Validate](#Validate-method)() |  |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
* [SelectMenuOption.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Interactions/MessageComponents/SelectMenus/SelectMenuOption.cs)
   
   
# Validate method

```csharp
public void Validate()
```

## See Also

* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
   
   
# SelectMenuOption constructor

The default constructor.

```csharp
public SelectMenuOption()
```

## See Also

* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
   
   
# Label property

User-facing name of the option, Max 100 characters

```csharp
public string Label { get; set; }
```

## See Also

* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
   
   
# Value property

Dev-define value of the option, Max 100 characters

```csharp
public string Value { get; set; }
```

## See Also

* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
   
   
# Description property

Additional description of the option, Max 100 characters

```csharp
public string Description { get; set; }
```

## See Also

* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
   
   
# Emoji property

Emoji in the option

```csharp
public DiscordEmoji Emoji { get; set; }
```

## See Also

* class [DiscordEmoji](../../../Emojis/DiscordEmoji.md)
* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)
   
   
# Default property

Will show this option as selected by default

```csharp
public bool? Default { get; set; }
```

## See Also

* class [SelectMenuOption](./SelectMenuOption.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.MessageComponents.SelectMenus](./SelectMenusNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->