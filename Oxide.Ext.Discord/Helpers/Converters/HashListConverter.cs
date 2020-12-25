using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Ext.Discord.Helpers.Interfaces;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Helpers.Converters
{
    public class HashListConverter<TValue> : JsonConverter where TValue : IGetEntityId
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Hash<string, TValue> data = (Hash<string, TValue>) value;
            
            writer.WriteStartArray();
            foreach (TValue tValue in data.Values)
            {
                serializer.Serialize(writer, tValue);
            }
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);

            Hash<string, TValue> data = new Hash<string, TValue>();
            foreach (JToken token in array)
            {
                TValue value = token.ToObject<TValue>();
                data[value.GetEntityId()] = value;
            }

            return data;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<TValue>) || objectType == typeof(Hash<string, TValue>);
        }
    }
}