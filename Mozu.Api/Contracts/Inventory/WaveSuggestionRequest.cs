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
  public class WaveSuggestionRequest : BaseRequest {
    /// <summary>
    /// Flag for including zero inventory items
    /// </summary>
    /// <value>Flag for including zero inventory items</value>
    [DataMember(Name="includeZeroInventory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "includeZeroInventory")]
    public bool? IncludeZeroInventory { get; set; }

    /// <summary>
    /// List of Bin Ranges
    /// </summary>
    /// <value>List of Bin Ranges</value>
    [DataMember(Name="binRanges", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "binRanges")]
    public List<BinRange> BinRanges { get; set; }

    /// <summary>
    /// List of Wave Shipments
    /// </summary>
    /// <value>List of Wave Shipments</value>
    [DataMember(Name="shipments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipments")]
    public List<WaveShipment> Shipments { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class WaveSuggestionRequest {\n");
      sb.Append("  IncludeZeroInventory: ").Append(IncludeZeroInventory).Append("\n");
      sb.Append("  BinRanges: ").Append(BinRanges).Append("\n");
      sb.Append("  Shipments: ").Append(Shipments).Append("\n");
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
