# IntegrationUpdate class

Represents [Integration Update Structure](https://discord.com/developers/docs/resources/guild#modify-guild-integration-json-params)

```csharp
public class IntegrationUpdate
```

## Public Members

| name | description |
| --- | --- |
| [IntegrationUpdate](#IntegrationUpdate-constructor)() | The default constructor. |
| [EnableEmoticons](#EnableEmoticons-property) { get; set; } | Whether emoticons should be synced for this integration (twitch only currently) |
| [ExpireBehaviour](#ExpireBehaviour-property) { get; set; } | The behavior when an integration subscription lapses |
| [ExpireGracePeriod](#ExpireGracePeriod-property) { get; set; } | Period (in days) where the integration will ignore lapsed subscriptions |

## See Also

* namespace [Oxide.Ext.Discord.Entities.Integrations](./IntegrationsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [IntegrationUpdate.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Integrations/IntegrationUpdate.cs)
   
   
# IntegrationUpdate constructor

The default constructor.

```csharp
public IntegrationUpdate()
```

## See Also

* class [IntegrationUpdate](./IntegrationUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Integrations](./IntegrationsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EnableEmoticons property

Whether emoticons should be synced for this integration (twitch only currently)

```csharp
public bool? EnableEmoticons { get; set; }
```

## See Also

* class [IntegrationUpdate](./IntegrationUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Integrations](./IntegrationsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ExpireBehaviour property

The behavior when an integration subscription lapses

```csharp
public IntegrationExpireBehaviors? ExpireBehaviour { get; set; }
```

## See Also

* enum [IntegrationExpireBehaviors](./IntegrationExpireBehaviors.md)
* class [IntegrationUpdate](./IntegrationUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Integrations](./IntegrationsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ExpireGracePeriod property

Period (in days) where the integration will ignore lapsed subscriptions

```csharp
public int? ExpireGracePeriod { get; set; }
```

## See Also

* class [IntegrationUpdate](./IntegrationUpdate.md)
* namespace [Oxide.Ext.Discord.Entities.Integrations](./IntegrationsNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->