# BasePoolable class

Represents a poolable object

```csharp
public abstract class BasePoolable : IDisposable
```

## Public Members

| name | description |
| --- | --- |
| [Dispose](#dispose-method)() | Disposes the object when used in a using statement |

## Protected Members

| name | description |
| --- | --- |
| [BasePoolable](#basepoolable-constructor)() | The default constructor. |
| virtual [EnterPool](#enterpool-method)() | Called when the object is returned to the pool. Can be overriden in child classes to cleanup used data |
| virtual [LeavePool](#leavepool-method)() | Called when the object leaves the pool. Can be overriden in child classes to set the initial object state |

## See Also

* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [BasePoolable.cs](../../../../Oxide.Ext.Discord/Types/BasePoolable.cs)
   
   
# EnterPool method

Called when the object is returned to the pool. Can be overriden in child classes to cleanup used data

```csharp
protected virtual void EnterPool()
```

## See Also

* class [BasePoolable](./BasePoolable.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# LeavePool method

Called when the object leaves the pool. Can be overriden in child classes to set the initial object state

```csharp
protected virtual void LeavePool()
```

## See Also

* class [BasePoolable](./BasePoolable.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# Dispose method

Disposes the object when used in a using statement

```csharp
public void Dispose()
```

## See Also

* class [BasePoolable](./BasePoolable.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
   
   
# BasePoolable constructor

The default constructor.

```csharp
protected BasePoolable()
```

## See Also

* class [BasePoolable](./BasePoolable.md)
* namespace [Oxide.Ext.Discord.Types](./TypesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
