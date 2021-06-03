using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// Product Mapping
  /// </summary>
  [DataContract]
  public class ProductMapping {
    /// <summary>
    /// Tenant Identifier
    /// </summary>
    /// <value>Tenant Identifier</value>
    [DataMember(Name="tenantID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantID")]
    public int? TenantID { get; set; }

    /// <summary>
    /// Enum for direction of the mapping
    /// </summary>
    /// <value>Enum for direction of the mapping</value>
    [DataMember(Name="direction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "direction")]
    public string Direction { get; set; }

    /// <summary>
    /// Enum for mapping rule
    /// </summary>
    /// <value>Enum for mapping rule</value>
    [DataMember(Name="mapping", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mapping")]
    public string Mapping { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ProductMapping {\n");
      sb.Append("  TenantID: ").Append(TenantID).Append("\n");
      sb.Append("  Direction: ").Append(Direction).Append("\n");
      sb.Append("  Mapping: ").Append(Mapping).Append("\n");
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
