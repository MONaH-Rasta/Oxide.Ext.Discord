# IPendingPromise&lt;TPromised&gt; interface

Represents a promise waiting to be resolved

```csharp
public interface IPendingPromise<TPromised> : IPromise<TPromised>, IRejectable
```

| parameter | description |
| --- | --- |
| TPromised | Type of the resolved value |

## Members

| name | description |
| --- | --- |
| [Resolve](#Resolve-method)(…) | Resolves the promise with the given value |

## See Also

* interface [IPromise&lt;TPromised&gt;](./IPromise%7BTPromised%7D.md)
* interface [IRejectable](./IRejectable.md)
* namespace [Oxide.Ext.Discord.Interfaces.Promises](./PromisesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)
* [IPendingPromise.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Interfaces/Promises/IPendingPromise.cs)
   
   
# Resolve method

Resolves the promise with the given value

```csharp
public void Resolve(TPromised value)
```

| parameter | description |
| --- | --- |
| value |  |

## See Also

* interface [IPendingPromise&lt;TPromised&gt;](./IPendingPromise%7BTPromised%7D.md)
* namespace [Oxide.Ext.Discord.Interfaces.Promises](./PromisesNamespace.md)
* assembly [Oxide.Ext.Discord](../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->