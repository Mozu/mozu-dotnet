using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.ToolKit.Models
{
    public class SubnavLink
    {
        public string ParentId { get; set; }
        public string[] Path { get; set; }
        public string Href { get; set; }
        public string AppId { get; set; }
        public string WindowTitle { get; set; }
    }
}
