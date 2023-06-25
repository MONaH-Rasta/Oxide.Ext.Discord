# MessageComponentsConverter class

Converter for list of message components

```csharp
public class MessageComponentsConverter : JsonConverter
```

## Public Members

| name | description |
| --- | --- |
| [MessageComponentsConverter](#MessageComponentsConverter-constructor)() | The default constructor. |
| override [CanWrite](#CanWrite-property) { get; } | Message Component Convert does not write JSON |
| override [CanConvert](#CanConvert-method)(…) | Returns if this can convert the value |
| override [ReadJson](#ReadJson-method)(…) | Populate the correct types in components instead of just the BaseComponent |
| override [WriteJson](#WriteJson-method)(…) | Ignored as we don't write JSON |

## See Also

* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [MessageComponentsConverter.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Json/Converters/MessageComponentsConverter.cs)
   
   
# WriteJson method

Ignored as we don't write JSON

```csharp
public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
```

| parameter | description |
| --- | --- |
| writer |  |
| value |  |
| serializer |  |

## Exceptions

| exception | condition |
| --- | --- |
| NotSupportedException |  |

## See Also

* class [MessageComponentsConverter](./MessageComponentsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ReadJson method

Populate the correct types in components instead of just the BaseComponent

```csharp
public override object ReadJson(JsonReader reader, Type objectType, object existingValue, 
    JsonSerializer serializer)
```

| parameter | description |
| --- | --- |
| reader |  |
| objectType |  |
| existingValue |  |
| serializer |  |

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentOutOfRangeException |  |

## See Also

* class [MessageComponentsConverter](./MessageComponentsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CanConvert method

Returns if this can convert the value

```csharp
public override bool CanConvert(Type objectType)
```

| parameter | description |
| --- | --- |
| objectType |  |

## See Also

* class [MessageComponentsConverter](./MessageComponentsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# MessageComponentsConverter constructor

The default constructor.

```csharp
public MessageComponentsConverter()
```

## See Also

* class [MessageComponentsConverter](./MessageComponentsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CanWrite property

Message Component Convert does not write JSON

```csharp
public override bool CanWrite { get; }
```

## See Also

* class [MessageComponentsConverter](./MessageComponentsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->