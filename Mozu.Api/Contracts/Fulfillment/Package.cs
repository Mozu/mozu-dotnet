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
  public class Package {
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
    /// Gets or Sets Carrier
    /// </summary>
    [DataMember(Name="carrier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "carrier")]
    public string Carrier { get; set; }

    /// <summary>
    /// Gets or Sets HasLabel
    /// </summary>
    [DataMember(Name="hasLabel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hasLabel")]
    public bool? HasLabel { get; set; }

    /// <summary>
    /// Gets or Sets IntegratorId
    /// </summary>
    [DataMember(Name="integratorId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "integratorId")]
    public string IntegratorId { get; set; }

    /// <summary>
    /// Gets or Sets ManifestId
    /// </summary>
    [DataMember(Name="manifestId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "manifestId")]
    public string ManifestId { get; set; }

    /// <summary>
    /// Gets or Sets Measurements
    /// </summary>
    [DataMember(Name="measurements", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "measurements")]
    public PackageMeasurements Measurements { get; set; }

    /// <summary>
    /// Gets or Sets PackageId
    /// </summary>
    [DataMember(Name="packageId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packageId")]
    public string PackageId { get; set; }

    /// <summary>
    /// Gets or Sets PackagingType
    /// </summary>
    [DataMember(Name="packagingType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packagingType")]
    public string PackagingType { get; set; }

    /// <summary>
    /// Gets or Sets ReturnCarrier
    /// </summary>
    [DataMember(Name="returnCarrier", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "returnCarrier")]
    public string ReturnCarrier { get; set; }

    /// <summary>
    /// Gets or Sets ReturnTrackingNumbers
    /// </summary>
    [DataMember(Name="returnTrackingNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "returnTrackingNumbers")]
    public List<string> ReturnTrackingNumbers { get; set; }

    /// <summary>
    /// Gets or Sets ReturnTrackings
    /// </summary>
    [DataMember(Name="returnTrackings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "returnTrackings")]
    public List<Tracking> ReturnTrackings { get; set; }

    /// <summary>
    /// Gets or Sets ShippingMethodCode
    /// </summary>
    [DataMember(Name="shippingMethodCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingMethodCode")]
    public string ShippingMethodCode { get; set; }

    /// <summary>
    /// Gets or Sets ShippingMethodName
    /// </summary>
    [DataMember(Name="shippingMethodName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingMethodName")]
    public string ShippingMethodName { get; set; }

    /// <summary>
    /// Gets or Sets SignatureRequired
    /// </summary>
    [DataMember(Name="signatureRequired", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "signatureRequired")]
    public bool? SignatureRequired { get; set; }

    /// <summary>
    /// Gets or Sets TrackingNumbers
    /// </summary>
    [DataMember(Name="trackingNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "trackingNumbers")]
    public List<string> TrackingNumbers { get; set; }

    /// <summary>
    /// Gets or Sets Trackings
    /// </summary>
    [DataMember(Name="trackings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "trackings")]
    public List<Tracking> Trackings { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Package {\n");
      sb.Append("  Attributes: ").Append(Attributes).Append("\n");
      sb.Append("  AuditInfo: ").Append(AuditInfo).Append("\n");
      sb.Append("  Carrier: ").Append(Carrier).Append("\n");
      sb.Append("  HasLabel: ").Append(HasLabel).Append("\n");
      sb.Append("  IntegratorId: ").Append(IntegratorId).Append("\n");
      sb.Append("  ManifestId: ").Append(ManifestId).Append("\n");
      sb.Append("  Measurements: ").Append(Measurements).Append("\n");
      sb.Append("  PackageId: ").Append(PackageId).Append("\n");
      sb.Append("  PackagingType: ").Append(PackagingType).Append("\n");
      sb.Append("  ReturnCarrier: ").Append(ReturnCarrier).Append("\n");
      sb.Append("  ReturnTrackingNumbers: ").Append(ReturnTrackingNumbers).Append("\n");
      sb.Append("  ReturnTrackings: ").Append(ReturnTrackings).Append("\n");
      sb.Append("  ShippingMethodCode: ").Append(ShippingMethodCode).Append("\n");
      sb.Append("  ShippingMethodName: ").Append(ShippingMethodName).Append("\n");
      sb.Append("  SignatureRequired: ").Append(SignatureRequired).Append("\n");
      sb.Append("  TrackingNumbers: ").Append(TrackingNumbers).Append("\n");
      sb.Append("  Trackings: ").Append(Trackings).Append("\n");
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
