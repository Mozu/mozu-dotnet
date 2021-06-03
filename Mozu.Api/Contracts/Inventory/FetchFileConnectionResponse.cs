using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// FetchFileConnectionResponse
  /// </summary>
  [DataContract]
  public class FetchFileConnectionResponse {
    /// <summary>
    /// List of files found on the specified sftp directory
    /// </summary>
    /// <value>List of files found on the specified sftp directory</value>
    [DataMember(Name="ftpFiles", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpFiles")]
    public List<string> FtpFiles { get; set; }

    /// <summary>
    /// List of files found on the specified sftp archive directory
    /// </summary>
    /// <value>List of files found on the specified sftp archive directory</value>
    [DataMember(Name="ftpArchiveFiles", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpArchiveFiles")]
    public List<string> FtpArchiveFiles { get; set; }

    /// <summary>
    /// List of files found on the specified s3 bucket/path
    /// </summary>
    /// <value>List of files found on the specified s3 bucket/path</value>
    [DataMember(Name="s3Files", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "s3Files")]
    public List<string> S3Files { get; set; }

    /// <summary>
    /// List of files found on the specified s3 archive bucket/path
    /// </summary>
    /// <value>List of files found on the specified s3 archive bucket/path</value>
    [DataMember(Name="s3ArchiveFiles", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "s3ArchiveFiles")]
    public List<string> S3ArchiveFiles { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class FetchFileConnectionResponse {\n");
      sb.Append("  FtpFiles: ").Append(FtpFiles).Append("\n");
      sb.Append("  FtpArchiveFiles: ").Append(FtpArchiveFiles).Append("\n");
      sb.Append("  S3Files: ").Append(S3Files).Append("\n");
      sb.Append("  S3ArchiveFiles: ").Append(S3ArchiveFiles).Append("\n");
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
