# RestHandler class

Represents a REST handler for a bot

```csharp
public class RestHandler : IDebugLoggable
```

## Public Members

| name | description |
| --- | --- |
| [RestHandler](#RestHandler-constructor)(…) | Creates a new REST handler for a bot client |
| readonly [Buckets](#Buckets-field) | Buckets with Routes we don't know the Hash of yet |
| readonly [Client](#Client-field) | HttpClient for API Requests |
| readonly [RateLimit](#RateLimit-field) | Global Rate Limit for the bot |
| readonly [RouteToBucketId](#RouteToBucketId-field) | Route to Bucket ID |
| [Delete](#Delete-method)(…) | Performs a HTTP Delete Request |
| [Delete&lt;TResult&gt;](#Delete-method)(…) | Performs a HTTP Delete Request with TResult response |
| [Get&lt;TResult&gt;](#Get-method)(…) | Performs a HTTP Get Request with TResult response |
| [GetBucket](#GetBucket-method)(…) | Returns the bucket with the given ID |
| [LogDebug](#LogDebug-method)(…) |  |
| [Patch](#Patch-method)(…) | Performs a HTTP Patch Request |
| [Patch&lt;TResult&gt;](#Patch-method)(…) | Performs a HTTP Patch Request with TResult response |
| [Post](#Post-method)(…) | Performs a HTTP Post Request |
| [Post&lt;TResult&gt;](#Post-method)(…) | Performs a HTTP Post Request with TResult response |
| [Put](#Put-method)(…) | Performs a HTTP Put Request |
| [Put&lt;TResult&gt;](#Put-method)(…) | Performs a HTTP Put Request with TResult response |
| [QueueBucket](#QueueBucket-method)(…) | Queues the request for the bucket |
| [Shutdown](#Shutdown-method)() | Shutdown the REST handler |
| [StartRequest](#StartRequest-method)(…) | Starts the request |

## See Also

* interface [IDebugLoggable](../Interfaces/Logging/IDebugLoggable.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [RestHandler.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Rest/RestHandler.cs)
   
   
# Get&lt;TResult&gt; method

Performs a HTTP Get Request with TResult response

```csharp
public IPromise<TResult> Get<TResult>(DiscordClient client, string url)
```

| parameter | description |
| --- | --- |
| TResult | Result to be returned from the request |
| client | Client for the request |
| url | Url for the request |

## See Also

* interface [IPromise&lt;TPromised&gt;](../Interfaces/Promises/IPromise%7BTPromised%7D.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Post method (1 of 2)

Performs a HTTP Post Request

```csharp
public IPromise Post(DiscordClient client, string url, object data)
```

| parameter | description |
| --- | --- |
| client | Client for the request |
| url | Url for the request |
| data | Data to post |

## See Also

* interface [IPromise](../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---
   
   
# Put method (1 of 2)

Performs a HTTP Put Request

```csharp
public IPromise Put(DiscordClient client, string url, object data)
```

| parameter | description |
| --- | --- |
| client | Client for the request |
| url | Url for the request |
| data | Data to put |

## See Also

* interface [IPromise](../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---
   
   
# Patch method (1 of 2)

Performs a HTTP Patch Request

```csharp
public IPromise Patch(DiscordClient client, string url, object data)
```

| parameter | description |
| --- | --- |
| client | Client for the request |
| url | Url for the request |
| data | Data to patch |

## See Also

* interface [IPromise](../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---
   
   
# Delete method (1 of 2)

Performs a HTTP Delete Request

```csharp
public IPromise Delete(DiscordClient client, string url)
```

| parameter | description |
| --- | --- |
| client | Client for the request |
| url | Url for the request |

## See Also

* interface [IPromise](../Interfaces/Promises/IPromise.md)
* class [DiscordClient](../Clients/DiscordClient.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

---
   
   
# StartRequest method

Starts the request

```csharp
public void StartRequest(BaseRequest request)
```

| parameter | description |
| --- | --- |
| request | Request to be started |

## See Also

* class [BaseRequest](./Requests/BaseRequest.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# QueueBucket method

Queues the request for the bucket

```csharp
public Bucket QueueBucket(RequestHandler handler, BaseRequest request)
```

## See Also

* class [Bucket](./Buckets/Bucket.md)
* class [RequestHandler](./Requests/RequestHandler.md)
* class [BaseRequest](./Requests/BaseRequest.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# GetBucket method

Returns the bucket with the given ID

```csharp
public Bucket GetBucket(BucketId bucketId)
```

| parameter | description |
| --- | --- |
| bucketId |  |

## See Also

* class [Bucket](./Buckets/Bucket.md)
* struct [BucketId](./Buckets/BucketId.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Shutdown method

Shutdown the REST handler

```csharp
public void Shutdown()
```

## See Also

* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LogDebug method

```csharp
public void LogDebug(DebugLogger logger)
```

## See Also

* class [DebugLogger](../Logging/DebugLogger.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RestHandler constructor

Creates a new REST handler for a bot client

```csharp
public RestHandler(BotClient client, ILogger logger)
```

| parameter | description |
| --- | --- |
| client | Client the request is for |
| logger | Logger from the client |

## See Also

* class [BotClient](../Clients/BotClient.md)
* interface [ILogger](../Logging/ILogger.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Client field

HttpClient for API Requests

```csharp
public readonly HttpClient Client;
```

## See Also

* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RateLimit field

Global Rate Limit for the bot

```csharp
public readonly RestRateLimit RateLimit;
```

## See Also

* class [RestRateLimit](../RateLimits/RestRateLimit.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Buckets field

Buckets with Routes we don't know the Hash of yet

```csharp
public readonly ConcurrentDictionary<BucketId, Bucket> Buckets;
```

## See Also

* struct [BucketId](./Buckets/BucketId.md)
* class [Bucket](./Buckets/Bucket.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# RouteToBucketId field

Route to Bucket ID

```csharp
public readonly ConcurrentDictionary<BucketId, BucketId> RouteToBucketId;
```

## See Also

* struct [BucketId](./Buckets/BucketId.md)
* class [RestHandler](./RestHandler.md)
* namespace [Oxide.Ext.Discord.Rest](./RestNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->