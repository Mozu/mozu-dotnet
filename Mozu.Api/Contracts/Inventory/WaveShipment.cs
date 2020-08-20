using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// A shipment (used in getting wave suggestions)
  /// </summary>
  [DataContract]
  public class WaveShipment {
    /// <summary>
    /// Order Identifier
    /// </summary>
    /// <value>Order Identifier</value>
    [DataMember(Name="orderID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "orderID")]
    public int? OrderID { get; set; }

    /// <summary>
    /// Shipment Identifier
    /// </summary>
    /// <value>Shipment Identifier</value>
    [DataMember(Name="shipmentID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentID")]
    public int? ShipmentID { get; set; }

    /// <summary>
    /// List of Items in the shipment
    /// </summary>
    /// <value>List of Items in the shipment</value>
    [DataMember(Name="items", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "items")]
    public List<WaveItem> Items { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class WaveShipment {\n");
      sb.Append("  OrderID: ").Append(OrderID).Append("\n");
      sb.Append("  ShipmentID: ").Append(ShipmentID).Append("\n");
      sb.Append("  Items: ").Append(Items).Append("\n");
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
