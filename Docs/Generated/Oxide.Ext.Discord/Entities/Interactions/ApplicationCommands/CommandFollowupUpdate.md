# CommandFollowupUpdate class

Represents a [Command Followup]() within discord.

```csharp
public class CommandFollowupUpdate : WebhookEditMessage
```

## Public Members

| name | description |
| --- | --- |
| [CommandFollowupUpdate](#CommandFollowupUpdate-constructor)() | The default constructor. |
| [Flags](#Flags-property) { get; set; } | Callback data flags Set to 64 to make your response ephemeral |

## See Also

* class [WebhookEditMessage](../../Webhooks/WebhookEditMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands](./ApplicationCommandsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [CommandFollowupUpdate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Interactions/ApplicationCommands/CommandFollowupUpdate.cs)
   
   
# CommandFollowupUpdate constructor

The default constructor.

```csharp
public CommandFollowupUpdate()
```

## See Also

* class [CommandFollowupUpdate](./CommandFollowupUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands](./ApplicationCommandsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Flags property

Callback data flags Set to 64 to make your response ephemeral

```csharp
public MessageFlags? Flags { get; set; }
```

## See Also

* enum [MessageFlags](../../Messages/MessageFlags.md)
* class [CommandFollowupUpdate](./CommandFollowupUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Interactions.ApplicationCommands](./ApplicationCommandsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->