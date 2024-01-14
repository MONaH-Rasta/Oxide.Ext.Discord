# DiscordSubscription class

Represents a channel subscription for a plugin

```csharp
public class DiscordSubscription : IDebugLoggable
```

## Public Members

| name | description |
| --- | --- |
| [DiscordSubscription](#discordsubscription-constructor)(…) | Constructor |
| [CanRun](#canrun-method)(…) | Returns if a subscription can run. They can only run for the client that they were created for. |
| [Invoke](#invoke-method)(…) | Invokes the callback with the message |
| [IsForChannel](#isforchannel-method)(…) | Returns if this subscription is for the given channel |
| [IsForPlugin](#isforplugin-method)(…) | Returns if this subscription is for this plugin |
| [LogDebug](#logdebug-method)(…) |  |

## See Also

* interface [IDebugLoggable](../Interfaces/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordSubscription.cs](../../../../Oxide.Ext.Discord/Libraries/DiscordSubscription.cs)
   
   
# CanRun method

Returns if a subscription can run. They can only run for the client that they were created for.

```csharp
public bool CanRun(BotClient client)
```

| parameter | description |
| --- | --- |
| client | Client to compare against |

## Return Value

True if same bot client; false otherwise

## See Also

* class [BotClient](../Clients/BotClient.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsForPlugin method

Returns if this subscription is for this plugin

```csharp
public bool IsForPlugin(Plugin plugin)
```

| parameter | description |
| --- | --- |
| plugin | Plugin to check |

## Return Value

True if the subscription is for this plugin; False otherwise

## See Also

* class [DiscordSubscription](./DiscordSubscription.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# IsForChannel method

Returns if this subscription is for the given channel

```csharp
public bool IsForChannel(Snowflake channelId)
```

| parameter | description |
| --- | --- |
| channelId | Channel ID to check |

## Return Value

True if the subscription is for this channel; False otherwise

## See Also

* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Invoke method

Invokes the callback with the message

```csharp
public void Invoke(DiscordMessage message)
```

| parameter | description |
| --- | --- |
| message | Message that was sent in the given channel |

## See Also

* class [DiscordMessage](../Entities/DiscordMessage.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../Logging/DebugLogger.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# DiscordSubscription constructor

Constructor

```csharp
public DiscordSubscription(DiscordClient client, Snowflake channelId, 
    Action<DiscordMessage> callback)
```

| parameter | description |
| --- | --- |
| client | Discord Client for the subscription |
| channelId | ID of the channel |
| callback | Callback when the channel message is sent |

## See Also

* class [DiscordClient](../Clients/DiscordClient.md)
* struct [Snowflake](../Entities/Snowflake.md)
* class [DiscordMessage](../Entities/DiscordMessage.md)
* class [DiscordSubscription](./DiscordSubscription.md)
* namespace [Oxide.Ext.Discord.Libraries](./LibrariesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->