using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// Adjust Item
  /// </summary>
  [DataContract]
  public class AdjustItem {
    /// <summary>
    /// Part/Product Number
    /// </summary>
    /// <value>Part/Product Number</value>
    [DataMember(Name="partNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "partNumber")]
    public string PartNumber { get; set; }

    /// <summary>
    /// Universal Product Code
    /// </summary>
    /// <value>Universal Product Code</value>
    [DataMember(Name="upc", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "upc")]
    public string Upc { get; set; }

    /// <summary>
    /// Stock Keeping Unit
    /// </summary>
    /// <value>Stock Keeping Unit</value>
    [DataMember(Name="sku", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sku")]
    public string Sku { get; set; }

    /// <summary>
    /// Bin Location Identifier
    /// </summary>
    /// <value>Bin Location Identifier</value>
    [DataMember(Name="binID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "binID")]
    public int? BinID { get; set; }

    /// <summary>
    /// Current Quantity of Item
    /// </summary>
    /// <value>Current Quantity of Item</value>
    [DataMember(Name="quantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity")]
    public int? Quantity { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AdjustItem {\n");
      sb.Append("  PartNumber: ").Append(PartNumber).Append("\n");
      sb.Append("  Upc: ").Append(Upc).Append("\n");
      sb.Append("  Sku: ").Append(Sku).Append("\n");
      sb.Append("  BinID: ").Append(BinID).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
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
