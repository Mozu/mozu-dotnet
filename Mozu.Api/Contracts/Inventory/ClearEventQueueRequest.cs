using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ClearEventQueueRequest : BaseRequest {
    /// <summary>
    /// Clear events queued before this date. Date format looks like: 2010-01-30
    /// </summary>
    /// <value>Clear events queued before this date. Date format looks like: 2010-01-30</value>
    [DataMember(Name="before", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "before")]
    public string Before { get; set; }

    /// <summary>
    /// Clear events queued after this date. Date format looks like: 2010-01-30
    /// </summary>
    /// <value>Clear events queued after this date. Date format looks like: 2010-01-30</value>
    [DataMember(Name="after", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "after")]
    public string After { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ClearEventQueueRequest {\n");
      sb.Append("  Before: ").Append(Before).Append("\n");
      sb.Append("  After: ").Append(After).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public  new string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
