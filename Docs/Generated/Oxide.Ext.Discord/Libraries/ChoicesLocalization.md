# ChoicesLocalization class

Localization for Select Menu Choices

```csharp
public class ChoicesLocalization
```

## Public Members

| name | description |
| --- | --- |
| [ChoicesLocalization](#choiceslocalization-constructor)() | Constructor |
| [ChoicesLocalization](#choiceslocalization-constructor-1-of-2)(…) | Constructor for command option choice localization (2 constructors) |
| [Name](#name-property) { get; set; } | Localization for [`Name`](../Entities/CommandOptionChoice.md#name-property) |
| [ApplyChoiceLocalization](#applychoicelocalization-method)(…) | Apply Choice Localizations |

## See Also

* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ChoicesLocalization.cs](../../../../Oxide.Ext.Discord/Libraries/ChoicesLocalization.cs)
   
   
# ApplyChoiceLocalization method

Apply Choice Localizations

```csharp
public void ApplyChoiceLocalization(CommandOptionChoice choice, DiscordLocale locale)
```

| parameter | description |
| --- | --- |
| choice |  |
| locale |  |

## See Also

* class [CommandOptionChoice](../Entities/CommandOptionChoice.md)
* struct [DiscordLocale](./DiscordLocale.md)
* class [ChoicesLocalization](./ChoicesLocalization.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ChoicesLocalization constructor (1 of 3)

Constructor

```csharp
public ChoicesLocalization()
```

## See Also

* class [ChoicesLocalization](./ChoicesLocalization.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ChoicesLocalization constructor (2 of 3)

Constructor for command option choice localization

```csharp
public ChoicesLocalization(string name)
```

| parameter | description |
| --- | --- |
| name | Localized choice name |

## See Also

* class [ChoicesLocalization](./ChoicesLocalization.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---

# ChoicesLocalization constructor (3 of 3)

Constructor

```csharp
public ChoicesLocalization(CommandOption option, string lang)
```

| parameter | description |
| --- | --- |
| option | Option to localize |
| lang | Oxide lang of the localization |

## See Also

* class [CommandOption](../Entities/CommandOption.md)
* class [ChoicesLocalization](./ChoicesLocalization.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Name property

Localization for [`Name`](../Entities/CommandOptionChoice.md#name-property)

```csharp
public string Name { get; set; }
```

## See Also

* class [ChoicesLocalization](./ChoicesLocalization.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->