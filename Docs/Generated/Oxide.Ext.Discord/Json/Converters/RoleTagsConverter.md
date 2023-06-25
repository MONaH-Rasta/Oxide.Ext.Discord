# RoleTagsConverter class

Handles converting [`RoleTags`](../../Entities/Permissions/RoleTags.md) This type contains special deserialization types

```csharp
public class RoleTagsConverter : JsonConverter
```

## Public Members

| name | description |
| --- | --- |
| [RoleTagsConverter](#RoleTagsConverter-constructor)() | The default constructor. |
| override [CanWrite](#CanWrite-property) { get; } | Cannot write |
| override [CanConvert](#CanConvert-method)(…) | Returns if the type can be converter |
| override [ReadJson](#ReadJson-method)(…) | Converts the JSON to a [`RoleTags`](../../Entities/Permissions/RoleTags.md) |
| override [WriteJson](#WriteJson-method)(…) | Cannot Write |

## See Also

* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [RoleTagsConverter.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Json/Converters/RoleTagsConverter.cs)
   
   
# WriteJson method

Cannot Write

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
| JsonSerializationException |  |

## See Also

* class [RoleTagsConverter](./RoleTagsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ReadJson method

Converts the JSON to a [`RoleTags`](../../Entities/Permissions/RoleTags.md)

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

## See Also

* class [RoleTagsConverter](./RoleTagsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CanConvert method

Returns if the type can be converter

```csharp
public override bool CanConvert(Type objectType)
```

| parameter | description |
| --- | --- |
| objectType |  |

## See Also

* class [RoleTagsConverter](./RoleTagsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# RoleTagsConverter constructor

The default constructor.

```csharp
public RoleTagsConverter()
```

## See Also

* class [RoleTagsConverter](./RoleTagsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# CanWrite property

Cannot write

```csharp
public override bool CanWrite { get; }
```

## See Also

* class [RoleTagsConverter](./RoleTagsConverter.md)
* namespace [Oxide.Ext.Discord.Json.Converters](./ConvertersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->