# RoleSubscription class

Represents [Role Subscription Structure](https://discord.com/developers/docs/resources/channel#role-subscription-data-object-role-subscription-data-object-structure)

```csharp
public class RoleSubscription
```

## Public Members

| name | description |
| --- | --- |
| [RoleSubscription](#rolesubscription-constructor)() | The default constructor. |
| [IsRenewal](#isrenewal-property) { get; set; } | Whether this notification is for a renewal rather than a new purchase |
| [RoleSubscriptionListingId](#rolesubscriptionlistingid-property) { get; set; } | The id of the sku and listing that the user is subscribed to |
| [TierName](#tiername-property) { get; set; } | The name of the tier that the user is subscribed to |
| [TotalMonthsSubscribed](#totalmonthssubscribed-property) { get; set; } | The cumulative number of months that the user has been subscribed for |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RoleSubscription.cs](../../../../Oxide.Ext.Discord/Entities/RoleSubscription.cs)
   
   
# RoleSubscription constructor

The default constructor.

```csharp
public RoleSubscription()
```

## See Also

* class [RoleSubscription](./RoleSubscription.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RoleSubscriptionListingId property

The id of the sku and listing that the user is subscribed to

```csharp
public Snowflake RoleSubscriptionListingId { get; set; }
```

## See Also

* struct [Snowflake](./Snowflake.md)
* class [RoleSubscription](./RoleSubscription.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TierName property

The name of the tier that the user is subscribed to

```csharp
public string TierName { get; set; }
```

## See Also

* class [RoleSubscription](./RoleSubscription.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# TotalMonthsSubscribed property

The cumulative number of months that the user has been subscribed for

```csharp
public int TotalMonthsSubscribed { get; set; }
```

## See Also

* class [RoleSubscription](./RoleSubscription.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsRenewal property

Whether this notification is for a renewal rather than a new purchase

```csharp
public bool IsRenewal { get; set; }
```

## See Also

* class [RoleSubscription](./RoleSubscription.md)
* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->