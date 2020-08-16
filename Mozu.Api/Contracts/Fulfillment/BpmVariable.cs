using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Fulfillment.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class BpmVariable {
    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets OldValue
    /// </summary>
    [DataMember(Name="oldValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "oldValue")]
    public string OldValue { get; set; }

    /// <summary>
    /// Gets or Sets UpdateDate
    /// </summary>
    [DataMember(Name="updateDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updateDate")]
    public DateTime? UpdateDate { get; set; }

    /// <summary>
    /// Gets or Sets Value
    /// </summary>
    [DataMember(Name="value", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "value")]
    public string Value { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BpmVariable {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  OldValue: ").Append(OldValue).Append("\n");
      sb.Append("  UpdateDate: ").Append(UpdateDate).Append("\n");
      sb.Append("  Value: ").Append(Value).Append("\n");
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
