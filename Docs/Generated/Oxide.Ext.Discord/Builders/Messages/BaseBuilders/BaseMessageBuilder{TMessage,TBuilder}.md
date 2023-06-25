# BaseMessageBuilder&lt;TMessage,TBuilder&gt; class

Represents a builder for [`BaseMessageCreate`](../../../Entities/Messages/BaseMessageCreate.md)

```csharp
public abstract class BaseMessageBuilder<TMessage, TBuilder>
    where TMessage : BaseMessageCreate
    where TBuilder : BaseMessageBuilder
```

| parameter | description |
| --- | --- |
| TMessage |  |
| TBuilder |  |

## Public Members

| name | description |
| --- | --- |
| virtual [AddActionRow](#AddActionRow-method)(…) | Adds a single [`ActionRowComponent`](../../../Entities/Interactions/MessageComponents/ActionRowComponent.md) |
| virtual [AddAllowedMentions](#AddAllowedMentions-method)(…) | Adds [`AllowedMention`](../../../Entities/Messages/AllowedMentions/AllowedMention.md) to the response |
| virtual [AddAttachment](#AddAttachment-method)(…) | Adds an attachment to the message |
| virtual [AddComponents](#AddComponents-method)(…) | Adds a collection MessageComponents/&gt; (2 methods) |
| virtual [AddContent](#AddContent-method)(…) | Adds message text |
| virtual [AddEmbed](#AddEmbed-method)(…) | Adds a [`DiscordEmbed`](../../../Entities/Messages/Embeds/DiscordEmbed.md) (2 methods) |
| virtual [AddEmbeds](#AddEmbeds-method)(…) | Adds a collection of [`DiscordEmbed`](../../../Entities/Messages/Embeds/DiscordEmbed.md) to the response |
| virtual [AsTts](#AsTts-method)(…) | Marks the message As Text-To-Speech |
| [Build](#Build-method)() | Returns the built message |
| virtual [SuppressEmbeds](#SuppressEmbeds-method)() | Suppresses embeds on this response |

## Protected Members

| name | description |
| --- | --- |
| [BaseMessageBuilder](#BaseMessageBuilder-constructor)(…) | Constructor |
| readonly [Builder](#Builder-field) | This builder |
| readonly [Message](#Message-field) | Message the builder is for |

## See Also

* class [BaseMessageCreate](../../../Entities/Messages/BaseMessageCreate.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
* [BaseMessageBuilder.cs](https://github.com/dassjosh/Oxide.Ext.Discord/blob/develop/Oxide.Ext.Discord/Builders/Messages/BaseBuilders/BaseMessageBuilder.cs)
   
   
# AddContent method

Adds message text

```csharp
public virtual TBuilder AddContent(string content)
```

| parameter | description |
| --- | --- |
| content | Text to be added |

## Return Value

This

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# AsTts method

Marks the message As Text-To-Speech

```csharp
public virtual TBuilder AsTts(bool enabled = true)
```

| parameter | description |
| --- | --- |
| enabled | Should TTS be enabled (Default true) |

## Return Value

this

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# AddEmbed method (1 of 2)

Adds a [`DiscordEmbed`](../../../Entities/Messages/Embeds/DiscordEmbed.md)

```csharp
public virtual TBuilder AddEmbed(DiscordEmbed embed)
```

| parameter | description |
| --- | --- |
| embed | Embed to be added |

## Return Value

This

## See Also

* class [DiscordEmbed](../../../Entities/Messages/Embeds/DiscordEmbed.md)
* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

---
   
   
# AddEmbeds method

Adds a collection of [`DiscordEmbed`](../../../Entities/Messages/Embeds/DiscordEmbed.md) to the response

```csharp
public virtual TBuilder AddEmbeds(ICollection<DiscordEmbed> embeds)
```

| parameter | description |
| --- | --- |
| embeds | Embeds to be added |

## Return Value

This

## See Also

* class [DiscordEmbed](../../../Entities/Messages/Embeds/DiscordEmbed.md)
* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# AddAllowedMentions method

Adds [`AllowedMention`](../../../Entities/Messages/AllowedMentions/AllowedMention.md) to the response

```csharp
public virtual TBuilder AddAllowedMentions(AllowedMention mention)
```

| parameter | description |
| --- | --- |
| mention | Mentions to be added |

## Return Value

This

## See Also

* class [AllowedMention](../../../Entities/Messages/AllowedMentions/AllowedMention.md)
* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# SuppressEmbeds method

Suppresses embeds on this response

```csharp
public virtual TBuilder SuppressEmbeds()
```

## Return Value

This

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# AddActionRow method

Adds a single [`ActionRowComponent`](../../../Entities/Interactions/MessageComponents/ActionRowComponent.md)

```csharp
public virtual TBuilder AddActionRow(ActionRowComponent component)
```

| parameter | description |
| --- | --- |
| component | Component to be added |

## Return Value

This

## See Also

* class [ActionRowComponent](../../../Entities/Interactions/MessageComponents/ActionRowComponent.md)
* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# AddComponents method (1 of 2)

Adds a collection MessageComponents/&gt;

```csharp
public virtual TBuilder AddComponents(ICollection<ActionRowComponent> components)
```

| parameter | description |
| --- | --- |
| components | Components to be added |

## Return Value

This

## See Also

* class [ActionRowComponent](../../../Entities/Interactions/MessageComponents/ActionRowComponent.md)
* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

---
   
   
# AddAttachment method

Adds an attachment to the message

```csharp
public virtual TBuilder AddAttachment(string filename, byte[] data, string contentType, 
    string description = null)
```

| parameter | description |
| --- | --- |
| filename | Name of the file |
| data | byte[] of the attachment |
| contentType | Attachment content type |
| description | Description for the attachment |

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Build method

Returns the built message

```csharp
public TMessage Build()
```

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# BaseMessageBuilder&lt;TMessage,TBuilder&gt; constructor

Constructor

```csharp
protected BaseMessageBuilder(TMessage message)
```

| parameter | description |
| --- | --- |
| message | Message being created |

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Message field

Message the builder is for

```csharp
protected readonly TMessage Message;
```

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)
   
   
# Builder field

This builder

```csharp
protected readonly TBuilder Builder;
```

## See Also

* class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./BaseMessageBuilder%7BTMessage,TBuilder%7D.md)
* namespace [Oxide.Ext.Discord.Builders.Messages.BaseBuilders](./BaseBuildersNamespace.md)
* assembly [Oxide.Ext.Discord](../../../../Oxide.Ext.Discord.md)

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->