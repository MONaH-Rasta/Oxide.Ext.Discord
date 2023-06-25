# CommandPayload class

Represents a command payload

```csharp
public class CommandPayload : BasePoolable
```

## Public Members

| name | description |
| --- | --- |
| [CommandPayload](#CommandPayload-constructor)() | The default constructor. |
| static [CreatePayload](#CreatePayload-method)(…) | Creates a [`CommandPayload`](./CommandPayload.md) for the web socket |
| [OpCode](#OpCode-field) | Command Code for the payload |
| [Payload](#Payload-field) | Payload data |

## Protected Members

| name | description |
| --- | --- |
| override [EnterPool](#EnterPool-method)() |  |

## See Also

* class [BasePoolable](../../Pooling/BasePoolable.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway](./GatewayNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [CommandPayload.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Gateway/CommandPayload.cs)
   
   
# CreatePayload method

Creates a [`CommandPayload`](./CommandPayload.md) for the web socket

```csharp
public static CommandPayload CreatePayload(GatewayCommandCode code, object payload)
```

| parameter | description |
| --- | --- |
| code | OP Code for the command |
| payload | Payload for the command |

## See Also

* enum [GatewayCommandCode](./Commands/GatewayCommandCode.md)
* class [CommandPayload](./CommandPayload.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway](./GatewayNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EnterPool method

```csharp
protected override void EnterPool()
```

## See Also

* class [CommandPayload](./CommandPayload.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway](./GatewayNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CommandPayload constructor

The default constructor.

```csharp
public CommandPayload()
```

## See Also

* class [CommandPayload](./CommandPayload.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway](./GatewayNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# OpCode field

Command Code for the payload

```csharp
public GatewayCommandCode OpCode;
```

## See Also

* enum [GatewayCommandCode](./Commands/GatewayCommandCode.md)
* class [CommandPayload](./CommandPayload.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway](./GatewayNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Payload field

Payload data

```csharp
public object Payload;
```

## See Also

* class [CommandPayload](./CommandPayload.md)
* namespace [Oxide.Ext.Discord.Entities.Gateway](./GatewayNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->