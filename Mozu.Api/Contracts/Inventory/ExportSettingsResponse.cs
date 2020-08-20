using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// Job ID Response
  /// </summary>
  [DataContract]
  public class ExportSettingsResponse {
    /// <summary>
    /// Created Export Settings Name
    /// </summary>
    /// <value>Created Export Settings Name</value>
    [DataMember(Name="exportSettingsName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "exportSettingsName")]
    public string ExportSettingsName { get; set; }

    /// <summary>
    /// Created Export Settings FTP Name
    /// </summary>
    /// <value>Created Export Settings FTP Name</value>
    [DataMember(Name="exportSettingsFTPName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "exportSettingsFTPName")]
    public string ExportSettingsFTPName { get; set; }

    /// <summary>
    /// Created Export Settings S3 Name
    /// </summary>
    /// <value>Created Export Settings S3 Name</value>
    [DataMember(Name="exportSettingsS3Name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "exportSettingsS3Name")]
    public string ExportSettingsS3Name { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ExportSettingsResponse {\n");
      sb.Append("  ExportSettingsName: ").Append(ExportSettingsName).Append("\n");
      sb.Append("  ExportSettingsFTPName: ").Append(ExportSettingsFTPName).Append("\n");
      sb.Append("  ExportSettingsS3Name: ").Append(ExportSettingsS3Name).Append("\n");
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
