using Mozu.Api.ToolKit.Converters;
using Mozu.Api.ToolKit.Handlers;
using Newtonsoft.Json;

namespace Mozu.Api.ToolKit.Models
{
    public class SubnavLink
    {
        [JsonConverter(typeof(EnumLowerCaseConverter))]
        public Parent ParentId { get; set; }
        public string[] Path { get; set; }
        public string Href { get; set; }
        public string AppId { get; set; }
        public string WindowTitle { get; set; }
    }
}
