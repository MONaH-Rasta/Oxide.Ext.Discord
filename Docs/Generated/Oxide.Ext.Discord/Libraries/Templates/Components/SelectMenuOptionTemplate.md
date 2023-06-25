# SelectMenuOptionTemplate class

Template for Select Menu Options

```csharp
public class SelectMenuOptionTemplate
```

## Public Members

| name | description |
| --- | --- |
| [SelectMenuOptionTemplate](#SelectMenuOptionTemplate-constructor)() | Constructor |
| [SelectMenuOptionTemplate](#SelectMenuOptionTemplate-constructor)(…) | Constructor |
| [Default](#Default-property) { get; set; } | Will render this option as selected by default |
| [Description](#Description-property) { get; set; } | An additional description of the option, Max 100 characters |
| [Emoji](#Emoji-property) { get; set; } | Emoji in the option |
| [Label](#Label-property) { get; set; } | The user-facing name of the option, Max 100 characters |
| [Value](#Value-property) { get; set; } | The dev-define value of the option, Max 100 characters |
| [ToOption](#ToOption-method)(…) | Converts the template to [`SelectMenuOption`](../../../Entities/Interactions/MessageComponents/SelectMenus/SelectMenuOption.md) |

## See Also

* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [SelectMenuOptionTemplate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Libraries/Templates/Components/SelectMenuOptionTemplate.cs)
   
   
# ToOption method

Converts the template to [`SelectMenuOption`](../../../Entities/Interactions/MessageComponents/SelectMenus/SelectMenuOption.md)

```csharp
public SelectMenuOption ToOption(PlaceholderData data)
```

| parameter | description |
| --- | --- |
| data | [`PlaceholderData`](../../Placeholders/PlaceholderData.md) to use |

## Return Value

[`SelectMenuOption`](../../../Entities/Interactions/MessageComponents/SelectMenus/SelectMenuOption.md)

## See Also

* class [SelectMenuOption](../../../Entities/Interactions/MessageComponents/SelectMenus/SelectMenuOption.md)
* class [PlaceholderData](../../Placeholders/PlaceholderData.md)
* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# SelectMenuOptionTemplate constructor (1 of 2)

Constructor

```csharp
public SelectMenuOptionTemplate()
```

## See Also

* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

---
   
   
# Label property

The user-facing name of the option, Max 100 characters

```csharp
public string Label { get; set; }
```

## See Also

* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Value property

The dev-define value of the option, Max 100 characters

```csharp
public string Value { get; set; }
```

## See Also

* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Description property

An additional description of the option, Max 100 characters

```csharp
public string Description { get; set; }
```

## See Also

* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Emoji property

Emoji in the option

```csharp
public EmojiTemplate Emoji { get; set; }
```

## See Also

* class [EmojiTemplate](../Emojis/EmojiTemplate.md)
* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Default property

Will render this option as selected by default

```csharp
public bool Default { get; set; }
```

## See Also

* class [SelectMenuOptionTemplate](./SelectMenuOptionTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Components](./ComponentsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->