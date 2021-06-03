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
  public class Destination {
    /// <summary>
    /// Gets or Sets Data
    /// </summary>
    [DataMember(Name="data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "data")]
    public Object Data { get; set; }

    /// <summary>
    /// Gets or Sets DestinationContact
    /// </summary>
    [DataMember(Name="destinationContact", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destinationContact")]
    public Contact DestinationContact { get; set; }

    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets IsDestinationCommercial
    /// </summary>
    [DataMember(Name="isDestinationCommercial", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isDestinationCommercial")]
    public bool? IsDestinationCommercial { get; set; }

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
      sb.Append("class Destination {\n");
      sb.Append("  Data: ").Append(Data).Append("\n");
      sb.Append("  DestinationContact: ").Append(DestinationContact).Append("\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  IsDestinationCommercial: ").Append(IsDestinationCommercial).Append("\n");
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
