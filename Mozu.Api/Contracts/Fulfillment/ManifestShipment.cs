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
  public class ManifestShipment {
    /// <summary>
    /// Gets or Sets Destination
    /// </summary>
    [DataMember(Name="destination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destination")]
    public Destination Destination { get; set; }

    /// <summary>
    /// Gets or Sets ExternalOrderId
    /// </summary>
    [DataMember(Name="externalOrderId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalOrderId")]
    public string ExternalOrderId { get; set; }

    /// <summary>
    /// Gets or Sets FulfillmentLocationCode
    /// </summary>
    [DataMember(Name="fulfillmentLocationCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fulfillmentLocationCode")]
    public string FulfillmentLocationCode { get; set; }

    /// <summary>
    /// Gets or Sets OrderNumber
    /// </summary>
    [DataMember(Name="orderNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "orderNumber")]
    public int? OrderNumber { get; set; }

    /// <summary>
    /// Gets or Sets Packages
    /// </summary>
    [DataMember(Name="packages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packages")]
    public List<Package> Packages { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentNumber
    /// </summary>
    [DataMember(Name="shipmentNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentNumber")]
    public int? ShipmentNumber { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentType
    /// </summary>
    [DataMember(Name="shipmentType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentType")]
    public string ShipmentType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ManifestShipment {\n");
      sb.Append("  Destination: ").Append(Destination).Append("\n");
      sb.Append("  ExternalOrderId: ").Append(ExternalOrderId).Append("\n");
      sb.Append("  FulfillmentLocationCode: ").Append(FulfillmentLocationCode).Append("\n");
      sb.Append("  OrderNumber: ").Append(OrderNumber).Append("\n");
      sb.Append("  Packages: ").Append(Packages).Append("\n");
      sb.Append("  ShipmentNumber: ").Append(ShipmentNumber).Append("\n");
      sb.Append("  ShipmentType: ").Append(ShipmentType).Append("\n");
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
