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
  public class CreateBinRequest : BaseRequest {
    /// <summary>
    /// Bin Type Identifier
    /// </summary>
    /// <value>Bin Type Identifier</value>
    [DataMember(Name="binTypeID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "binTypeID")]
    public int? BinTypeID { get; set; }

    /// <summary>
    /// Bin Status Identifier
    /// </summary>
    /// <value>Bin Status Identifier</value>
    [DataMember(Name="binStatusID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "binStatusID")]
    public int? BinStatusID { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    /// <value>Name</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateBinRequest {\n");
      sb.Append("  BinTypeID: ").Append(BinTypeID).Append("\n");
      sb.Append("  BinStatusID: ").Append(BinStatusID).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
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
