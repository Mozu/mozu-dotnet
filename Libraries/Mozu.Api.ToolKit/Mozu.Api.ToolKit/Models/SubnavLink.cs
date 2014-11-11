using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.ToolKit.Converters;
using Mozu.Api.ToolKit.Handlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
