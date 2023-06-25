# RateLimitResponse class

Represents a rate limit response from an API request

```csharp
public class RateLimitResponse : BasePoolable
```

## Public Members

| name | description |
| --- | --- |
| [RateLimitResponse](#RateLimitResponse-constructor)() | The default constructor. |
| [BucketId](#BucketId-field) | The Bucket ID of the rate limit |
| [Code](#Code-field) | Rate Limit Code |
| [IsGlobalRateLimit](#IsGlobalRateLimit-field) | If we hit the global rate limit with this request |
| [Limit](#Limit-field) | The number of request for this bucket |
| [Message](#Message-field) | Rate Limit Message |
| [Remaining](#Remaining-field) | The number of remaining requests for this bucket |
| [ResetAt](#ResetAt-field) | The date time when this bucket will reset |
| [Scope](#Scope-field) | The scope the rate limit is for |
| [Init](#Init-method)(…) | Initialize the RateLimitResponse |

## Protected Members

| name | description |
| --- | --- |
| override [EnterPool](#EnterPool-method)() |  |

## See Also

* class [BasePoolable](../../Pooling/BasePoolable.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [RateLimitResponse.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Entities/Api/RateLimitResponse.cs)
   
   
# Init method

Initialize the RateLimitResponse

```csharp
public void Init(DiscordClient client, HttpResponseHeaders headers, DiscordHttpStatusCode code, 
    string content)
```

| parameter | description |
| --- | --- |
| client | Client for the rate limit |
| headers | Headers for the rate limit |
| code | Http code for the request |
| content | Request response content |

## See Also

* class [DiscordClient](../../Clients/DiscordClient.md)
* enum [DiscordHttpStatusCode](./DiscordHttpStatusCode.md)
* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# EnterPool method

```csharp
protected override void EnterPool()
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# RateLimitResponse constructor

The default constructor.

```csharp
public RateLimitResponse()
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# BucketId field

The Bucket ID of the rate limit

```csharp
public BucketId BucketId;
```

## See Also

* struct [BucketId](../../Rest/Buckets/BucketId.md)
* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# IsGlobalRateLimit field

If we hit the global rate limit with this request

```csharp
public bool IsGlobalRateLimit;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# ResetAt field

The date time when this bucket will reset

```csharp
public DateTimeOffset ResetAt;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Limit field

The number of request for this bucket

```csharp
public int Limit;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Remaining field

The number of remaining requests for this bucket

```csharp
public int Remaining;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Scope field

The scope the rate limit is for

```csharp
public string Scope;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Message field

Rate Limit Message

```csharp
public string Message;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
   
   
# Code field

Rate Limit Code

```csharp
public int? Code;
```

## See Also

* class [RateLimitResponse](./RateLimitResponse.md)
* namespace [Oxide.Ext.Discord.Entities.Api](./ApiNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->