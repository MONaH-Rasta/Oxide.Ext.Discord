# WebhookCreateMessage class

Represents [Webhook Create Message](https://discord.com/developers/docs/resources/webhook#execute-webhook-jsonform-params)

```csharp
public class WebhookCreateMessage : MessageCreate
```

## Public Members

| name | description |
| --- | --- |
| [WebhookCreateMessage](#WebhookCreateMessage-constructor)() | The default constructor. |
| [AvatarUrl](#AvatarUrl-property) { get; set; } | Override the default avatar of the webhook |
| [ThreadName](#ThreadName-property) { get; set; } | Name of thread to create Requires the webhook channel to be a forum channel |
| [Username](#Username-property) { get; set; } | Override the default username of the webhook |

## Protected Members

| name | description |
| --- | --- |
| override [ValidateFlags](#ValidateFlags-method)() |  |

## See Also

* class [MessageCreate](../Messages/MessageCreate.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](./WebhooksNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [WebhookCreateMessage.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Webhooks/WebhookCreateMessage.cs)
   
   
# ValidateFlags method

```csharp
protected override void ValidateFlags()
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](./WebhooksNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# WebhookCreateMessage constructor

The default constructor.

```csharp
public WebhookCreateMessage()
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](./WebhooksNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Username property

Override the default username of the webhook

```csharp
public string Username { get; set; }
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](./WebhooksNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# AvatarUrl property

Override the default avatar of the webhook

```csharp
public string AvatarUrl { get; set; }
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](./WebhooksNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ThreadName property

Name of thread to create Requires the webhook channel to be a forum channel

```csharp
public string ThreadName { get; set; }
```

## See Also

* class [WebhookCreateMessage](./WebhookCreateMessage.md)
* namespace [Oxide.Ext.Discord.Entities.Webhooks](./WebhooksNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->