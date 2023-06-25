# DiscordModalTemplate class

Template used for Modal Message Component

```csharp
public class DiscordModalTemplate
```

## Public Members

| name | description |
| --- | --- |
| [DiscordModalTemplate](#DiscordModalTemplate-constructor)() | Constructor |
| [DiscordModalTemplate](#DiscordModalTemplate-constructor)(…) | Constructor |
| [Components](#Components-property) { get; set; } | Components of the Modal |
| [CustomId](#CustomId-property) { get; set; } | Title of the modal |
| [Title](#Title-property) { get; set; } | Title of the modal |
| [ToModal](#ToModal-method)(…) | Converts the template to a [`InteractionModalMessage`](../../../Entities/Interactions/Response/InteractionModalMessage.md) |

## See Also

* namespace [Oxide.Ext.Discord.Libraries.Templates.Modals](./ModalsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [DiscordModalTemplate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Libraries/Templates/Modals/DiscordModalTemplate.cs)
   
   
# ToModal method

Converts the template to a [`InteractionModalMessage`](../../../Entities/Interactions/Response/InteractionModalMessage.md)

```csharp
public InteractionModalMessage ToModal(PlaceholderData data = null, 
    InteractionModalMessage modal = null)
```

| parameter | description |
| --- | --- |
| data |  |
| modal |  |

## See Also

* class [InteractionModalMessage](../../../Entities/Interactions/Response/InteractionModalMessage.md)
* class [PlaceholderData](../../Placeholders/PlaceholderData.md)
* class [DiscordModalTemplate](./DiscordModalTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Modals](./ModalsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# DiscordModalTemplate constructor (1 of 2)

Constructor

```csharp
public DiscordModalTemplate()
```

## See Also

* class [DiscordModalTemplate](./DiscordModalTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Modals](./ModalsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

---
   
   
# Title property

Title of the modal

```csharp
public string Title { get; set; }
```

## See Also

* class [DiscordModalTemplate](./DiscordModalTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Modals](./ModalsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# CustomId property

Title of the modal

```csharp
public string CustomId { get; set; }
```

## See Also

* class [DiscordModalTemplate](./DiscordModalTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Modals](./ModalsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Components property

Components of the Modal

```csharp
public List<BaseComponentTemplate> Components { get; set; }
```

## See Also

* class [BaseComponentTemplate](../Components/BaseComponentTemplate.md)
* class [DiscordModalTemplate](./DiscordModalTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.Modals](./ModalsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->