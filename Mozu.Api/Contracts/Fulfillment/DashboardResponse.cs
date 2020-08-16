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
  public class DashboardResponse {
    /// <summary>
    /// Gets or Sets ShipmentType
    /// </summary>
    [DataMember(Name="shipmentType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentType")]
    public string ShipmentType { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentTypeDisplayName
    /// </summary>
    [DataMember(Name="shipmentTypeDisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentTypeDisplayName")]
    public string ShipmentTypeDisplayName { get; set; }

    /// <summary>
    /// Gets or Sets Steps
    /// </summary>
    [DataMember(Name="steps", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "steps")]
    public List<DashboardStep> Steps { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DashboardResponse {\n");
      sb.Append("  ShipmentType: ").Append(ShipmentType).Append("\n");
      sb.Append("  ShipmentTypeDisplayName: ").Append(ShipmentTypeDisplayName).Append("\n");
      sb.Append("  Steps: ").Append(Steps).Append("\n");
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
