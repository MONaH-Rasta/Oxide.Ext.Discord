# DiscordAutoCompleteChoiceTemplate class

Template for Discord Auto Completes

```csharp
public class DiscordAutoCompleteChoiceTemplate
```

## Public Members

| name | description |
| --- | --- |
| [DiscordAutoCompleteChoiceTemplate](#DiscordAutoCompleteChoiceTemplate-constructor)() | The default constructor. |
| [Name](#Name-property) { get; set; } | Choice Text (1-100 characters) |
| [ApplyLocalization](#ApplyLocalization-method)(…) | Apply localizations to the auto complete choice |
| [ApplyName](#ApplyName-method)(…) | Apply the name to the auto complete choice |

## See Also

* namespace [Oxide.Ext.Discord.Libraries.Templates.AutoComplete](./AutoCompleteNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [DiscordAutoCompleteChoiceTemplate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Libraries/Templates/AutoComplete/DiscordAutoCompleteChoiceTemplate.cs)
   
   
# ApplyLocalization method

Apply localizations to the auto complete choice

```csharp
public void ApplyLocalization(DiscordLocale locale, CommandOptionChoice choice, 
    PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| locale | DiscordLocale being applied |
| choice | Choice to apply the template to |
| placeholders | Placeholders for be applied |

## See Also

* struct [DiscordLocale](../../Locale/DiscordLocale.md)
* class [CommandOptionChoice](../../../Entities/Interactions/ApplicationCommands/CommandOptionChoice.md)
* class [PlaceholderData](../../Placeholders/PlaceholderData.md)
* class [DiscordAutoCompleteChoiceTemplate](./DiscordAutoCompleteChoiceTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.AutoComplete](./AutoCompleteNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# ApplyName method

Apply the name to the auto complete choice

```csharp
public void ApplyName(CommandOptionChoice choice, PlaceholderData placeholders = null)
```

| parameter | description |
| --- | --- |
| choice | Choice to apply the template to |
| placeholders | Placeholders for be applied |

## See Also

* class [CommandOptionChoice](../../../Entities/Interactions/ApplicationCommands/CommandOptionChoice.md)
* class [PlaceholderData](../../Placeholders/PlaceholderData.md)
* class [DiscordAutoCompleteChoiceTemplate](./DiscordAutoCompleteChoiceTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.AutoComplete](./AutoCompleteNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# DiscordAutoCompleteChoiceTemplate constructor

The default constructor.

```csharp
public DiscordAutoCompleteChoiceTemplate()
```

## See Also

* class [DiscordAutoCompleteChoiceTemplate](./DiscordAutoCompleteChoiceTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.AutoComplete](./AutoCompleteNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Name property

Choice Text (1-100 characters)

```csharp
public string Name { get; set; }
```

## See Also

* class [DiscordAutoCompleteChoiceTemplate](./DiscordAutoCompleteChoiceTemplate.md)
* namespace [Oxide.Ext.Discord.Libraries.Templates.AutoComplete](./AutoCompleteNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->