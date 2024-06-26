# WebhookCreateMessage class

Represents [Webhook Create Message](https://discord.com/developers/docs/resources/webhook#execute-webhook-jsonform-params)

```csharp
public class WebhookCreateMessage : MessageCreate
```

## Public Members

| name | description |
| --- | --- |
| [WebhookCreateMessage](#webhookcreatemessage-constructor)() | The default constructor. |
| [AppliedTags](#appliedtags-property) { get; set; } | Array of tag ids to apply to the thread requires the webhook channel to be a forum or media channel |
| [AvatarUrl](#avatarurl-property) { get; set; } | Override the default avatar of the webhook |
| [ThreadName](#threadname-property) { get; set; } | Name of thread to create Requires the webhook channel to be a forum channel |
| [Username](#username-property) { get; set; } | Override the default username of the webhook |

## Protected Members

| name | description |
| --- | --- |
| override [ValidateFlags](#validateflags-method)() |  |

## See Also

* class [MessageCreate](./MessageCreate.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [WebhookCreateMessage.cs](../../../../Oxide.Ext.Discord/Entities/WebhookCreateMessage.cs)
   
   
# ValidateFlags method

```csharp
protected override void ValidateFlags()
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# WebhookCreateMessage constructor

The default constructor.

```csharp
public WebhookCreateMessage()
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Username property

Override the default username of the webhook

```csharp
public string Username { get; set; }
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AvatarUrl property

Override the default avatar of the webhook

```csharp
public string AvatarUrl { get; set; }
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# ThreadName property

Name of thread to create Requires the webhook channel to be a forum channel

```csharp
public string ThreadName { get; set; }
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# AppliedTags property

Array of tag ids to apply to the thread requires the webhook channel to be a forum or media channel

```csharp
public List<Snowflake> AppliedTags { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
