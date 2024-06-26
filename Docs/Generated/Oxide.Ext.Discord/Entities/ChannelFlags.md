# ChannelFlags enumeration

Represents [Channel Flags](https://discord.com/developers/docs/resources/channel#channel-object-channel-flags)

```csharp
[Flags]
public enum ChannelFlags
```

## Values

| name | value | description |
| --- | --- | --- |
| None | `0` | Represents no channel flags |
| Pinned | `1 << 1` | This thread is pinned to the top of its parent GUILD_FORUM channel |
| RequireTag | `1 << 4` | Whether a tag is required to be specified when creating a thread in a GUILD_FORUM channel. Tags are specified in the applied_tags field. |
| HideMediaDownloadOptions | `1 << 15` | When set hides the embedded media download options. Available only for media channels |

## See Also

* namespace [Oxide.Ext.Discord.Entities](./EntitiesNamespace.md)
* assembly [Oxide.Ext.Discord](../../Oxide.Ext.Discord.md)
* [ChannelFlags.cs](../../../../Oxide.Ext.Discord/Entities/ChannelFlags.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
