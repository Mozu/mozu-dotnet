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
  public class BinSearchResponse : BaseResponse {
    /// <summary>
    /// Gets or Sets BinQuantities
    /// </summary>
    [DataMember(Name="binQuantities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "binQuantities")]
    public BinProductQuantities BinQuantities { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BinSearchResponse {\n");
      sb.Append("  BinQuantities: ").Append(BinQuantities).Append("\n");
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
