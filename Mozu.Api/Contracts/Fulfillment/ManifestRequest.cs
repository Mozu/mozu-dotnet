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
  public class ManifestRequest {
    /// <summary>
    /// Gets or Sets CarrierId
    /// </summary>
    [DataMember(Name="carrierId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrierId")]
    public string CarrierId { get; set; }

    /// <summary>
    /// Gets or Sets IncludedShipments
    /// </summary>
    [DataMember(Name="includedShipments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "includedShipments")]
    public List<ManifestRequestShipment> IncludedShipments { get; set; }

    /// <summary>
    /// Gets or Sets LocationCode
    /// </summary>
    [DataMember(Name="locationCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locationCode")]
    public string LocationCode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ManifestRequest {\n");
      sb.Append("  CarrierId: ").Append(CarrierId).Append("\n");
      sb.Append("  IncludedShipments: ").Append(IncludedShipments).Append("\n");
      sb.Append("  LocationCode: ").Append(LocationCode).Append("\n");
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
