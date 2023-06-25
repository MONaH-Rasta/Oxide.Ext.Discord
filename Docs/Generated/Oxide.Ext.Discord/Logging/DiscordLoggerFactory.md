# DiscordLoggerFactory class

Factory for creating DiscordLoggers

```csharp
public class DiscordLoggerFactory : Singleton<DiscordLoggerFactory>
```

## Public Members

| name | description |
| --- | --- |
| [CreateLogger](#CreateLogger-method)(…) | Returns a newly created [`DiscordLogger`](./DiscordLogger.md) for a given plugin |

## See Also

* class [Singleton&lt;T&gt;](../Singleton/Singleton%7BT%7D.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [DiscordLoggerFactory.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Logging/DiscordLoggerFactory.cs)
   
   
# CreateLogger method

Returns a newly created [`DiscordLogger`](./DiscordLogger.md) for a given plugin

```csharp
public DiscordLogger CreateLogger(Plugin plugin, DiscordLogLevel logLevel, 
    IDiscordLoggingConfig config)
```

| parameter | description |
| --- | --- |
| plugin | Plugin the logger is for |
| logLevel | The current LogLevel for the logger |
| config | The config for the logger |

## Return Value

[`DiscordLogger`](./DiscordLogger.md)

## See Also

* class [DiscordLogger](./DiscordLogger.md)
* enum [DiscordLogLevel](./DiscordLogLevel.md)
* interface [IDiscordLoggingConfig](./IDiscordLoggingConfig.md)
* class [DiscordLoggerFactory](./DiscordLoggerFactory.md)
* namespace [Oxide.Ext.Discord.Logging](./LoggingNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->