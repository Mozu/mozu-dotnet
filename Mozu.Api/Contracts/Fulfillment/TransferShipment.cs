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
  public class TransferShipment {
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
    /// Gets or Sets IsUserAction
    /// </summary>
    [DataMember(Name="isUserAction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isUserAction")]
    public bool? IsUserAction { get; set; }

    /// <summary>
    /// Gets or Sets Items
    /// </summary>
    [DataMember(Name="items", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "items")]
    public List<TransferItem> Items { get; set; }

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
      sb.Append("class TransferShipment {\n");
      sb.Append("  BlockAssignment: ").Append(BlockAssignment).Append("\n");
      sb.Append("  FulfillmentLocationCode: ").Append(FulfillmentLocationCode).Append("\n");
      sb.Append("  IsUserAction: ").Append(IsUserAction).Append("\n");
      sb.Append("  Items: ").Append(Items).Append("\n");
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
