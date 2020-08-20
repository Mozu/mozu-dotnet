using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// Bin ID Response
  /// </summary>
  [DataContract]
  public class BinIDResponse {
    /// <summary>
    /// Bin ID
    /// </summary>
    /// <value>Bin ID</value>
    [DataMember(Name="binID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "binID")]
    public int? BinID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BinIDResponse {\n");
      sb.Append("  BinID: ").Append(BinID).Append("\n");
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
