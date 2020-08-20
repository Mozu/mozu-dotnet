using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mozu.Api.Contracts.Inventory {

  /// <summary>
  /// Model of a tenant config.
  /// </summary>
  [DataContract]
  public class TenantConfigModel {
    /// <summary>
    /// A Tenant ID
    /// </summary>
    /// <value>A Tenant ID</value>
    [DataMember(Name="tenantID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantID")]
    public int? TenantID { get; set; }

    /// <summary>
    /// Number of Event Sender Workers to run for this tenant.
    /// </summary>
    /// <value>Number of Event Sender Workers to run for this tenant.</value>
    [DataMember(Name="numEventSenderWorkers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numEventSenderWorkers")]
    public int? NumEventSenderWorkers { get; set; }

    /// <summary>
    /// Config IDs of Fetch Worker Configs to regularly run. Set this to [0] to run all configs.
    /// </summary>
    /// <value>Config IDs of Fetch Worker Configs to regularly run. Set this to [0] to run all configs.</value>
    [DataMember(Name="fetchWorkerConfigIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fetchWorkerConfigIds")]
    public List<string> FetchWorkerConfigIds { get; set; }

    /// <summary>
    /// What level of events to send. Must be one of: NO_REFRESH_LOGS, WITH_REFRESH_LOGS, WITH_BASIC_EVENTS, ALL
    /// </summary>
    /// <value>What level of events to send. Must be one of: NO_REFRESH_LOGS, WITH_REFRESH_LOGS, WITH_BASIC_EVENTS, ALL</value>
    [DataMember(Name="eventsToSend", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "eventsToSend")]
    public string EventsToSend { get; set; }

    /// <summary>
    /// Whether our secret sync api is enabled for this tenant.
    /// </summary>
    /// <value>Whether our secret sync api is enabled for this tenant.</value>
    [DataMember(Name="enableSyncApi", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "enableSyncApi")]
    public bool? EnableSyncApi { get; set; }

    /// <summary>
    /// Which identifiers to ignore. Must be null or one of: IGNORE_IDENTIFIERS_SKU, IGNORE_IDENTIFIERS_PART_NUMBER, IGNORE_IDENTIFIERS_SKU_AND_PART_NUMBER
    /// </summary>
    /// <value>Which identifiers to ignore. Must be null or one of: IGNORE_IDENTIFIERS_SKU, IGNORE_IDENTIFIERS_PART_NUMBER, IGNORE_IDENTIFIERS_SKU_AND_PART_NUMBER</value>
    [DataMember(Name="ignoreIdentifiers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ignoreIdentifiers")]
    public string IgnoreIdentifiers { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TenantConfigModel {\n");
      sb.Append("  TenantID: ").Append(TenantID).Append("\n");
      sb.Append("  NumEventSenderWorkers: ").Append(NumEventSenderWorkers).Append("\n");
      sb.Append("  FetchWorkerConfigIds: ").Append(FetchWorkerConfigIds).Append("\n");
      sb.Append("  EventsToSend: ").Append(EventsToSend).Append("\n");
      sb.Append("  EnableSyncApi: ").Append(EnableSyncApi).Append("\n");
      sb.Append("  IgnoreIdentifiers: ").Append(IgnoreIdentifiers).Append("\n");
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
