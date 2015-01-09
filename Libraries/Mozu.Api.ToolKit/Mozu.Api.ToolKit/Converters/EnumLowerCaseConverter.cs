using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.ToolKit.Handlers;
using Newtonsoft.Json;

namespace Mozu.Api.ToolKit.Converters
{
    public class EnumLowerCaseConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            value = value.ToString().First().ToString().ToLower() + String.Join("", value.ToString().Skip(1));
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            value = value.First().ToString().ToUpper() + String.Join("", value.Skip(1));
            return Enum.Parse(objectType, value);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
