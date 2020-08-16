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
  public class TransferItem {
    /// <summary>
    /// Gets or Sets BlockAssignment
    /// </summary>
    [DataMember(Name="blockAssignment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blockAssignment")]
    public bool? BlockAssignment { get; set; }

    /// <summary>
    /// Gets or Sets FulfillmentLocationCode
    /// </summary>
    [DataMember(Name="fulfillmentLocationCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fulfillmentLocationCode")]
    public string FulfillmentLocationCode { get; set; }

    /// <summary>
    /// Gets or Sets LineId
    /// </summary>
    [DataMember(Name="lineId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineId")]
    public int? LineId { get; set; }

    /// <summary>
    /// Gets or Sets Quantity
    /// </summary>
    [DataMember(Name="quantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "quantity")]
    public int? Quantity { get; set; }

    /// <summary>
    /// Gets or Sets TransferredReason
    /// </summary>
    [DataMember(Name="transferredReason", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transferredReason")]
    public TransferredReason TransferredReason { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TransferItem {\n");
      sb.Append("  BlockAssignment: ").Append(BlockAssignment).Append("\n");
      sb.Append("  FulfillmentLocationCode: ").Append(FulfillmentLocationCode).Append("\n");
      sb.Append("  LineId: ").Append(LineId).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
      sb.Append("  TransferredReason: ").Append(TransferredReason).Append("\n");
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
