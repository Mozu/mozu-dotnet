using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// Fetch File Config Model
  /// </summary>
  [DataContract]
  public class MFetchFileConfig {
    /// <summary>
    /// Fetch File Config ID
    /// </summary>
    /// <value>Fetch File Config ID</value>
    [DataMember(Name="fetchFileConfigID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fetchFileConfigID")]
    public int? FetchFileConfigID { get; set; }

    /// <summary>
    /// Tenant ID
    /// </summary>
    /// <value>Tenant ID</value>
    [DataMember(Name="tenantID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantID")]
    public int? TenantID { get; set; }

    /// <summary>
    /// Active
    /// </summary>
    /// <value>Active</value>
    [DataMember(Name="active", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Time config was last modified
    /// </summary>
    /// <value>Time config was last modified</value>
    [DataMember(Name="lastModified", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastModified")]
    public string LastModified { get; set; }

    /// <summary>
    /// Email List
    /// </summary>
    /// <value>Email List</value>
    [DataMember(Name="emailList", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "emailList")]
    public string EmailList { get; set; }

    /// <summary>
    /// Flag for Refresh Enabled
    /// </summary>
    /// <value>Flag for Refresh Enabled</value>
    [DataMember(Name="refreshEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "refreshEnabled")]
    public bool? RefreshEnabled { get; set; }

    /// <summary>
    /// Description for the refresh file
    /// </summary>
    /// <value>Description for the refresh file</value>
    [DataMember(Name="refreshFileDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "refreshFileDescription")]
    public string RefreshFileDescription { get; set; }

    /// <summary>
    /// Flag for Update Enabled
    /// </summary>
    /// <value>Flag for Update Enabled</value>
    [DataMember(Name="updateEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updateEnabled")]
    public bool? UpdateEnabled { get; set; }

    /// <summary>
    /// Description for the update file
    /// </summary>
    /// <value>Description for the update file</value>
    [DataMember(Name="updateFileDescription", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updateFileDescription")]
    public string UpdateFileDescription { get; set; }

    /// <summary>
    /// FTP server address
    /// </summary>
    /// <value>FTP server address</value>
    [DataMember(Name="ftpServer", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpServer")]
    public string FtpServer { get; set; }

    /// <summary>
    /// FTP server username
    /// </summary>
    /// <value>FTP server username</value>
    [DataMember(Name="ftpUsername", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpUsername")]
    public string FtpUsername { get; set; }

    /// <summary>
    /// FTP server password
    /// </summary>
    /// <value>FTP server password</value>
    [DataMember(Name="ftpPassword", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpPassword")]
    public string FtpPassword { get; set; }

    /// <summary>
    /// FTP server port
    /// </summary>
    /// <value>FTP server port</value>
    [DataMember(Name="ftpPort", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpPort")]
    public int? FtpPort { get; set; }

    /// <summary>
    /// FTP server remote path
    /// </summary>
    /// <value>FTP server remote path</value>
    [DataMember(Name="ftpRemotePath", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpRemotePath")]
    public string FtpRemotePath { get; set; }

    /// <summary>
    /// FTP server remote path archive
    /// </summary>
    /// <value>FTP server remote path archive</value>
    [DataMember(Name="ftpRemotePathArchive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ftpRemotePathArchive")]
    public string FtpRemotePathArchive { get; set; }

    /// <summary>
    /// S3 Region
    /// </summary>
    /// <value>S3 Region</value>
    [DataMember(Name="region", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "region")]
    public string Region { get; set; }

    /// <summary>
    /// S3 Version
    /// </summary>
    /// <value>S3 Version</value>
    [DataMember(Name="version", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "version")]
    public string Version { get; set; }

    /// <summary>
    /// S3 Key
    /// </summary>
    /// <value>S3 Key</value>
    [DataMember(Name="s3Key", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "s3Key")]
    public string S3Key { get; set; }

    /// <summary>
    /// S3 Secret
    /// </summary>
    /// <value>S3 Secret</value>
    [DataMember(Name="secret", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "secret")]
    public string Secret { get; set; }

    /// <summary>
    /// S3 Bucket
    /// </summary>
    /// <value>S3 Bucket</value>
    [DataMember(Name="bucket", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// S3 Bucket Path (directory)
    /// </summary>
    /// <value>S3 Bucket Path (directory)</value>
    [DataMember(Name="s3Path", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "s3Path")]
    public string S3Path { get; set; }

    /// <summary>
    /// S3 Archive Bucket
    /// </summary>
    /// <value>S3 Archive Bucket</value>
    [DataMember(Name="archiveBucket", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "archiveBucket")]
    public string ArchiveBucket { get; set; }

    /// <summary>
    /// S3 Archive Bucket Path (directory)
    /// </summary>
    /// <value>S3 Archive Bucket Path (directory)</value>
    [DataMember(Name="s3ArchivePath", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "s3ArchivePath")]
    public string S3ArchivePath { get; set; }

    /// <summary>
    /// Lock name
    /// </summary>
    /// <value>Lock name</value>
    [DataMember(Name="lockName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lockName")]
    public string LockName { get; set; }

    /// <summary>
    /// Enum denoting action post processing
    /// </summary>
    /// <value>Enum denoting action post processing</value>
    [DataMember(Name="postProcessAction", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postProcessAction")]
    public int? PostProcessAction { get; set; }

    /// <summary>
    /// Flag for using control file
    /// </summary>
    /// <value>Flag for using control file</value>
    [DataMember(Name="useControlFile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "useControlFile")]
    public bool? UseControlFile { get; set; }

    /// <summary>
    /// Flag for using multiple files
    /// </summary>
    /// <value>Flag for using multiple files</value>
    [DataMember(Name="multipleFiles", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "multipleFiles")]
    public bool? MultipleFiles { get; set; }

    /// <summary>
    /// Flag for converting negatives to zero
    /// </summary>
    /// <value>Flag for converting negatives to zero</value>
    [DataMember(Name="zeroOutNegatives", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "zeroOutNegatives")]
    public bool? ZeroOutNegatives { get; set; }

    /// <summary>
    /// List of field names
    /// </summary>
    /// <value>List of field names</value>
    [DataMember(Name="fieldNameMap", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fieldNameMap")]
    public List<string> FieldNameMap { get; set; }

    /// <summary>
    /// Flag for ignoring extra fields
    /// </summary>
    /// <value>Flag for ignoring extra fields</value>
    [DataMember(Name="ignoreExtraFields", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ignoreExtraFields")]
    public bool? IgnoreExtraFields { get; set; }

    /// <summary>
    /// Flag to convert null quantities to zero
    /// </summary>
    /// <value>Flag to convert null quantities to zero</value>
    [DataMember(Name="blankQuantityIsZero", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "blankQuantityIsZero")]
    public bool? BlankQuantityIsZero { get; set; }

    /// <summary>
    /// CSV Delimiter
    /// </summary>
    /// <value>CSV Delimiter</value>
    [DataMember(Name="csvDelimiter", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "csvDelimiter")]
    public string CsvDelimiter { get; set; }

    /// <summary>
    /// Flag for exporting after refresh
    /// </summary>
    /// <value>Flag for exporting after refresh</value>
    [DataMember(Name="exportAfterRefresh", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "exportAfterRefresh")]
    public bool? ExportAfterRefresh { get; set; }

    /// <summary>
    /// Export id post import
    /// </summary>
    /// <value>Export id post import</value>
    [DataMember(Name="postImportExportId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postImportExportId")]
    public int? PostImportExportId { get; set; }

    /// <summary>
    /// FTP id post import
    /// </summary>
    /// <value>FTP id post import</value>
    [DataMember(Name="postImportFtpId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postImportFtpId")]
    public int? PostImportFtpId { get; set; }

    /// <summary>
    /// Enum for fetch file mapping
    /// </summary>
    /// <value>Enum for fetch file mapping</value>
    [DataMember(Name="productMapping", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "productMapping")]
    public string ProductMapping { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MFetchFileConfig {\n");
      sb.Append("  FetchFileConfigID: ").Append(FetchFileConfigID).Append("\n");
      sb.Append("  TenantID: ").Append(TenantID).Append("\n");
      sb.Append("  Active: ").Append(Active).Append("\n");
      sb.Append("  LastModified: ").Append(LastModified).Append("\n");
      sb.Append("  EmailList: ").Append(EmailList).Append("\n");
      sb.Append("  RefreshEnabled: ").Append(RefreshEnabled).Append("\n");
      sb.Append("  RefreshFileDescription: ").Append(RefreshFileDescription).Append("\n");
      sb.Append("  UpdateEnabled: ").Append(UpdateEnabled).Append("\n");
      sb.Append("  UpdateFileDescription: ").Append(UpdateFileDescription).Append("\n");
      sb.Append("  FtpServer: ").Append(FtpServer).Append("\n");
      sb.Append("  FtpUsername: ").Append(FtpUsername).Append("\n");
      sb.Append("  FtpPassword: ").Append(FtpPassword).Append("\n");
      sb.Append("  FtpPort: ").Append(FtpPort).Append("\n");
      sb.Append("  FtpRemotePath: ").Append(FtpRemotePath).Append("\n");
      sb.Append("  FtpRemotePathArchive: ").Append(FtpRemotePathArchive).Append("\n");
      sb.Append("  Region: ").Append(Region).Append("\n");
      sb.Append("  Version: ").Append(Version).Append("\n");
      sb.Append("  S3Key: ").Append(S3Key).Append("\n");
      sb.Append("  Secret: ").Append(Secret).Append("\n");
      sb.Append("  Bucket: ").Append(Bucket).Append("\n");
      sb.Append("  S3Path: ").Append(S3Path).Append("\n");
      sb.Append("  ArchiveBucket: ").Append(ArchiveBucket).Append("\n");
      sb.Append("  S3ArchivePath: ").Append(S3ArchivePath).Append("\n");
      sb.Append("  LockName: ").Append(LockName).Append("\n");
      sb.Append("  PostProcessAction: ").Append(PostProcessAction).Append("\n");
      sb.Append("  UseControlFile: ").Append(UseControlFile).Append("\n");
      sb.Append("  MultipleFiles: ").Append(MultipleFiles).Append("\n");
      sb.Append("  ZeroOutNegatives: ").Append(ZeroOutNegatives).Append("\n");
      sb.Append("  FieldNameMap: ").Append(FieldNameMap).Append("\n");
      sb.Append("  IgnoreExtraFields: ").Append(IgnoreExtraFields).Append("\n");
      sb.Append("  BlankQuantityIsZero: ").Append(BlankQuantityIsZero).Append("\n");
      sb.Append("  CsvDelimiter: ").Append(CsvDelimiter).Append("\n");
      sb.Append("  ExportAfterRefresh: ").Append(ExportAfterRefresh).Append("\n");
      sb.Append("  PostImportExportId: ").Append(PostImportExportId).Append("\n");
      sb.Append("  PostImportFtpId: ").Append(PostImportFtpId).Append("\n");
      sb.Append("  ProductMapping: ").Append(ProductMapping).Append("\n");
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
