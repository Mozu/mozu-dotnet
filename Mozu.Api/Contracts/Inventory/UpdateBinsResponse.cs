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
  public class UpdateBinsResponse : BaseResponse {
    /// <summary>
    /// Number of affected bins
    /// </summary>
    /// <value>Number of affected bins</value>
    [DataMember(Name="numberAffected", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numberAffected")]
    public int? NumberAffected { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateBinsResponse {\n");
      sb.Append("  NumberAffected: ").Append(NumberAffected).Append("\n");
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
