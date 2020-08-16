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
  public class ManifestRequestShipment {
    /// <summary>
    /// Gets or Sets IntegratorIds
    /// </summary>
    [DataMember(Name="integratorIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "integratorIds")]
    public List<string> IntegratorIds { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentNumber
    /// </summary>
    [DataMember(Name="shipmentNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentNumber")]
    public int? ShipmentNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ManifestRequestShipment {\n");
      sb.Append("  IntegratorIds: ").Append(IntegratorIds).Append("\n");
      sb.Append("  ShipmentNumber: ").Append(ShipmentNumber).Append("\n");
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
