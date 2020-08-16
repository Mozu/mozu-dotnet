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
  public class EntityModelOfManifest {
    /// <summary>
    /// Gets or Sets Links
    /// </summary>
    [DataMember(Name="_links", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "_links")]
    public Links Links { get; set; }

    /// <summary>
    /// Gets or Sets Attributes
    /// </summary>
    [DataMember(Name="attributes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "attributes")]
    public Dictionary<string, Object> Attributes { get; set; }

    /// <summary>
    /// Gets or Sets AuditInfo
    /// </summary>
    [DataMember(Name="auditInfo", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auditInfo")]
    public AuditInfo AuditInfo { get; set; }

    /// <summary>
    /// Gets or Sets CarrierId
    /// </summary>
    [DataMember(Name="carrierId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrierId")]
    public string CarrierId { get; set; }

    /// <summary>
    /// Gets or Sets InternalId
    /// </summary>
    [DataMember(Name="internalId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "internalId")]
    public string InternalId { get; set; }

    /// <summary>
    /// Gets or Sets LocationCode
    /// </summary>
    [DataMember(Name="locationCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locationCode")]
    public string LocationCode { get; set; }

    /// <summary>
    /// Gets or Sets ManifestId
    /// </summary>
    [DataMember(Name="manifestId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "manifestId")]
    public string ManifestId { get; set; }

    /// <summary>
    /// Gets or Sets ManifestUrl
    /// </summary>
    [DataMember(Name="manifestUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "manifestUrl")]
    public string ManifestUrl { get; set; }

    /// <summary>
    /// Gets or Sets NumberOfPackages
    /// </summary>
    [DataMember(Name="numberOfPackages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numberOfPackages")]
    public int? NumberOfPackages { get; set; }

    /// <summary>
    /// Gets or Sets NumberOfShipments
    /// </summary>
    [DataMember(Name="numberOfShipments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numberOfShipments")]
    public int? NumberOfShipments { get; set; }

    /// <summary>
    /// Gets or Sets Shipments
    /// </summary>
    [DataMember(Name="shipments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipments")]
    public List<ManifestShipment> Shipments { get; set; }

    /// <summary>
    /// Gets or Sets TenantId
    /// </summary>
    [DataMember(Name="tenantId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantId")]
    public int? TenantId { get; set; }

    /// <summary>
    /// Gets or Sets UserDisplayName
    /// </summary>
    [DataMember(Name="userDisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userDisplayName")]
    public string UserDisplayName { get; set; }

    /// <summary>
    /// Gets or Sets UserId
    /// </summary>
    [DataMember(Name="userId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userId")]
    public string UserId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EntityModelOfManifest {\n");
      sb.Append("  Links: ").Append(Links).Append("\n");
      sb.Append("  Attributes: ").Append(Attributes).Append("\n");
      sb.Append("  AuditInfo: ").Append(AuditInfo).Append("\n");
      sb.Append("  CarrierId: ").Append(CarrierId).Append("\n");
      sb.Append("  InternalId: ").Append(InternalId).Append("\n");
      sb.Append("  LocationCode: ").Append(LocationCode).Append("\n");
      sb.Append("  ManifestId: ").Append(ManifestId).Append("\n");
      sb.Append("  ManifestUrl: ").Append(ManifestUrl).Append("\n");
      sb.Append("  NumberOfPackages: ").Append(NumberOfPackages).Append("\n");
      sb.Append("  NumberOfShipments: ").Append(NumberOfShipments).Append("\n");
      sb.Append("  Shipments: ").Append(Shipments).Append("\n");
      sb.Append("  TenantId: ").Append(TenantId).Append("\n");
      sb.Append("  UserDisplayName: ").Append(UserDisplayName).Append("\n");
      sb.Append("  UserId: ").Append(UserId).Append("\n");
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
