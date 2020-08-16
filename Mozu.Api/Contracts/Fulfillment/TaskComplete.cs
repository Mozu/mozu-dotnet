using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Fulfillment {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class TaskComplete {
    /// <summary>
    /// Gets or Sets HandleOption
    /// </summary>
    [DataMember(Name="handleOption", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "handleOption")]
    public HandleOption HandleOption { get; set; }

    /// <summary>
    /// Gets or Sets TaskBody
    /// </summary>
    [DataMember(Name="taskBody", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "taskBody")]
    public Dictionary<string, Object> TaskBody { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TaskComplete {\n");
      sb.Append("  HandleOption: ").Append(HandleOption).Append("\n");
      sb.Append("  TaskBody: ").Append(TaskBody).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
