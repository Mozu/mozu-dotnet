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
            serializer.Serialize(writer, value.ToString().ToLower());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType.GetType()== typeof(Enum))
            {
                return Enum.Parse(objectType, existingValue.ToString());
            }
            else
            {
                return existingValue;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
