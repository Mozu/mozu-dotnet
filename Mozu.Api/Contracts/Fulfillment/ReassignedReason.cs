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
  public class ReassignedReason {
    /// <summary>
    /// Gets or Sets MoreInfo
    /// </summary>
    [DataMember(Name="moreInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "moreInfo")]
    public string MoreInfo { get; set; }

    /// <summary>
    /// Gets or Sets ReasonCode
    /// </summary>
    [DataMember(Name="reasonCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reasonCode")]
    public string ReasonCode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ReassignedReason {\n");
      sb.Append("  MoreInfo: ").Append(MoreInfo).Append("\n");
      sb.Append("  ReasonCode: ").Append(ReasonCode).Append("\n");
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
