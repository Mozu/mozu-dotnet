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
  public class ProductMappingResponse : BaseResponse {
    /// <summary>
    /// Gets or Sets ProductMappings
    /// </summary>
    [DataMember(Name="productMappings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "productMappings")]
    public ProductMapping ProductMappings { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ProductMappingResponse {\n");
      sb.Append("  ProductMappings: ").Append(ProductMappings).Append("\n");
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
