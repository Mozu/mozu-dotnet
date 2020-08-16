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
  public class Shipment {
    /// <summary>
    /// Gets or Sets AcceptedDate
    /// </summary>
    [DataMember(Name="acceptedDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "acceptedDate")]
    public DateTime? AcceptedDate { get; set; }

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
    /// Gets or Sets CanceledItems
    /// </summary>
    [DataMember(Name="canceledItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "canceledItems")]
    public List<CanceledItem> CanceledItems { get; set; }

    /// <summary>
    /// Gets or Sets ChangeMessages
    /// </summary>
    [DataMember(Name="changeMessages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "changeMessages")]
    public List<ChangeMessage> ChangeMessages { get; set; }

    /// <summary>
    /// Gets or Sets ChildShipmentNumbers
    /// </summary>
    [DataMember(Name="childShipmentNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "childShipmentNumbers")]
    public List<int?> ChildShipmentNumbers { get; set; }

    /// <summary>
    /// Gets or Sets CurrencyCode
    /// </summary>
    [DataMember(Name="currencyCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "currencyCode")]
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or Sets CustomerAccountId
    /// </summary>
    [DataMember(Name="customerAccountId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customerAccountId")]
    public int? CustomerAccountId { get; set; }

    /// <summary>
    /// Gets or Sets CustomerAddressId
    /// </summary>
    [DataMember(Name="customerAddressId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customerAddressId")]
    public int? CustomerAddressId { get; set; }

    /// <summary>
    /// Gets or Sets CustomerTaxId
    /// </summary>
    [DataMember(Name="customerTaxId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "customerTaxId")]
    public string CustomerTaxId { get; set; }

    /// <summary>
    /// Gets or Sets Data
    /// </summary>
    [DataMember(Name="data", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "data")]
    public Dictionary<string, Object> Data { get; set; }

    /// <summary>
    /// Gets or Sets Destination
    /// </summary>
    [DataMember(Name="destination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "destination")]
    public Destination Destination { get; set; }

    /// <summary>
    /// Gets or Sets DutyAdjustment
    /// </summary>
    [DataMember(Name="dutyAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dutyAdjustment")]
    public Nullable<decimal> DutyAdjustment { get; set; }

    /// <summary>
    /// Gets or Sets DutyTotal
    /// </summary>
    [DataMember(Name="dutyTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dutyTotal")]
    public Nullable<decimal> DutyTotal { get; set; }

    /// <summary>
    /// Gets or Sets Email
    /// </summary>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or Sets ExternalOrderId
    /// </summary>
    [DataMember(Name="externalOrderId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalOrderId")]
    public string ExternalOrderId { get; set; }

    /// <summary>
    /// Gets or Sets FulfillmentDate
    /// </summary>
    [DataMember(Name="fulfillmentDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fulfillmentDate")]
    public DateTime? FulfillmentDate { get; set; }

    /// <summary>
    /// Gets or Sets FulfillmentLocationCode
    /// </summary>
    [DataMember(Name="fulfillmentLocationCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fulfillmentLocationCode")]
    public string FulfillmentLocationCode { get; set; }

    /// <summary>
    /// Gets or Sets FulfillmentStatus
    /// </summary>
    [DataMember(Name="fulfillmentStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fulfillmentStatus")]
    public string FulfillmentStatus { get; set; }

    /// <summary>
    /// Gets or Sets HandlingAdjustment
    /// </summary>
    [DataMember(Name="handlingAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "handlingAdjustment")]
    public Nullable<decimal> HandlingAdjustment { get; set; }

    /// <summary>
    /// Gets or Sets HandlingSubtotal
    /// </summary>
    [DataMember(Name="handlingSubtotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "handlingSubtotal")]
    public Nullable<decimal> HandlingSubtotal { get; set; }

    /// <summary>
    /// Gets or Sets HandlingTaxAdjustment
    /// </summary>
    [DataMember(Name="handlingTaxAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "handlingTaxAdjustment")]
    public Nullable<decimal> HandlingTaxAdjustment { get; set; }

    /// <summary>
    /// Gets or Sets HandlingTaxTotal
    /// </summary>
    [DataMember(Name="handlingTaxTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "handlingTaxTotal")]
    public Nullable<decimal> HandlingTaxTotal { get; set; }

    /// <summary>
    /// Gets or Sets HandlingTotal
    /// </summary>
    [DataMember(Name="handlingTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "handlingTotal")]
    public Nullable<decimal> HandlingTotal { get; set; }

    /// <summary>
    /// Gets or Sets IsExpress
    /// </summary>
    [DataMember(Name="isExpress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isExpress")]
    public bool? IsExpress { get; set; }

    /// <summary>
    /// Gets or Sets Items
    /// </summary>
    [DataMember(Name="items", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "items")]
    public List<Item> Items { get; set; }

    /// <summary>
    /// Gets or Sets LineItemSubtotal
    /// </summary>
    [DataMember(Name="lineItemSubtotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineItemSubtotal")]
    public Nullable<decimal> LineItemSubtotal { get; set; }

    /// <summary>
    /// Gets or Sets LineItemTaxAdjustment
    /// </summary>
    [DataMember(Name="lineItemTaxAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineItemTaxAdjustment")]
    public Nullable<decimal> LineItemTaxAdjustment { get; set; }

    /// <summary>
    /// Gets or Sets LineItemTaxTotal
    /// </summary>
    [DataMember(Name="lineItemTaxTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineItemTaxTotal")]
    public Nullable<decimal> LineItemTaxTotal { get; set; }

    /// <summary>
    /// Gets or Sets LineItemTotal
    /// </summary>
    [DataMember(Name="lineItemTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lineItemTotal")]
    public Nullable<decimal> LineItemTotal { get; set; }

    /// <summary>
    /// Gets or Sets OrderId
    /// </summary>
    [DataMember(Name="orderId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// Gets or Sets OrderNumber
    /// </summary>
    [DataMember(Name="orderNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "orderNumber")]
    public int? OrderNumber { get; set; }

    /// <summary>
    /// Gets or Sets OrderSubmitDate
    /// </summary>
    [DataMember(Name="orderSubmitDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "orderSubmitDate")]
    public DateTime? OrderSubmitDate { get; set; }

    /// <summary>
    /// Gets or Sets OriginalShipmentNumber
    /// </summary>
    [DataMember(Name="originalShipmentNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "originalShipmentNumber")]
    public int? OriginalShipmentNumber { get; set; }

    /// <summary>
    /// Gets or Sets Packages
    /// </summary>
    [DataMember(Name="packages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "packages")]
    public List<Package> Packages { get; set; }

    /// <summary>
    /// Gets or Sets ParentShipmentNumber
    /// </summary>
    [DataMember(Name="parentShipmentNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parentShipmentNumber")]
    public int? ParentShipmentNumber { get; set; }

    /// <summary>
    /// Gets or Sets PickStatus
    /// </summary>
    [DataMember(Name="pickStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pickStatus")]
    public string PickStatus { get; set; }

    /// <summary>
    /// Gets or Sets PickType
    /// </summary>
    [DataMember(Name="pickType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pickType")]
    public string PickType { get; set; }

    /// <summary>
    /// Gets or Sets PickWaveNumber
    /// </summary>
    [DataMember(Name="pickWaveNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pickWaveNumber")]
    public int? PickWaveNumber { get; set; }

    /// <summary>
    /// Gets or Sets ReadyForPickup
    /// </summary>
    [DataMember(Name="readyForPickup", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "readyForPickup")]
    public bool? ReadyForPickup { get; set; }

    /// <summary>
    /// Gets or Sets ReadyForPickupDate
    /// </summary>
    [DataMember(Name="readyForPickupDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "readyForPickupDate")]
    public DateTime? ReadyForPickupDate { get; set; }

    /// <summary>
    /// Gets or Sets ReassignedItems
    /// </summary>
    [DataMember(Name="reassignedItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "reassignedItems")]
    public List<ReassignItem> ReassignedItems { get; set; }

    /// <summary>
    /// Gets or Sets ReceivedDate
    /// </summary>
    [DataMember(Name="receivedDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "receivedDate")]
    public DateTime? ReceivedDate { get; set; }

    /// <summary>
    /// Gets or Sets RejectedItems
    /// </summary>
    [DataMember(Name="rejectedItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rejectedItems")]
    public List<RejectedItem> RejectedItems { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentAdjustment
    /// </summary>
    [DataMember(Name="shipmentAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentAdjustment")]
    public Nullable<decimal> ShipmentAdjustment { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentNumber
    /// </summary>
    [DataMember(Name="shipmentNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentNumber")]
    public int? ShipmentNumber { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentStatus
    /// </summary>
    [DataMember(Name="shipmentStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentStatus")]
    public string ShipmentStatus { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentStatusReason
    /// </summary>
    [DataMember(Name="shipmentStatusReason", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentStatusReason")]
    public ShipmentStatusReason ShipmentStatusReason { get; set; }

    /// <summary>
    /// Gets or Sets ShipmentType
    /// </summary>
    [DataMember(Name="shipmentType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shipmentType")]
    public string ShipmentType { get; set; }

    /// <summary>
    /// Gets or Sets ShippingAdjustment
    /// </summary>
    [DataMember(Name="shippingAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingAdjustment")]
    public Nullable<decimal> ShippingAdjustment { get; set; }

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
    /// Gets or Sets ShippingSubtotal
    /// </summary>
    [DataMember(Name="shippingSubtotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingSubtotal")]
    public Nullable<decimal> ShippingSubtotal { get; set; }

    /// <summary>
    /// Gets or Sets ShippingTaxAdjustment
    /// </summary>
    [DataMember(Name="shippingTaxAdjustment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingTaxAdjustment")]
    public Nullable<decimal> ShippingTaxAdjustment { get; set; }

    /// <summary>
    /// Gets or Sets ShippingTaxTotal
    /// </summary>
    [DataMember(Name="shippingTaxTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingTaxTotal")]
    public Nullable<decimal> ShippingTaxTotal { get; set; }

    /// <summary>
    /// Gets or Sets ShippingTotal
    /// </summary>
    [DataMember(Name="shippingTotal", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "shippingTotal")]
    public Nullable<decimal> ShippingTotal { get; set; }

    /// <summary>
    /// Gets or Sets SiteId
    /// </summary>
    [DataMember(Name="siteId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "siteId")]
    public int? SiteId { get; set; }

    /// <summary>
    /// Gets or Sets TaxData
    /// </summary>
    [DataMember(Name="taxData", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "taxData")]
    public Object TaxData { get; set; }

    /// <summary>
    /// Gets or Sets TenantId
    /// </summary>
    [DataMember(Name="tenantId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tenantId")]
    public int? TenantId { get; set; }

    /// <summary>
    /// Gets or Sets Total
    /// </summary>
    [DataMember(Name="total", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total")]
    public Nullable<decimal> Total { get; set; }

    /// <summary>
    /// Gets or Sets TransferShipmentNumbers
    /// </summary>
    [DataMember(Name="transferShipmentNumbers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transferShipmentNumbers")]
    public List<int?> TransferShipmentNumbers { get; set; }

    /// <summary>
    /// Gets or Sets TransitTime
    /// </summary>
    [DataMember(Name="transitTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "transitTime")]
    public string TransitTime { get; set; }

    /// <summary>
    /// Gets or Sets UserId
    /// </summary>
    [DataMember(Name="userId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userId")]
    public string UserId { get; set; }

    /// <summary>
    /// Gets or Sets WorkflowProcessContainerId
    /// </summary>
    [DataMember(Name="workflowProcessContainerId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workflowProcessContainerId")]
    public string WorkflowProcessContainerId { get; set; }

    /// <summary>
    /// Gets or Sets WorkflowProcessId
    /// </summary>
    [DataMember(Name="workflowProcessId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workflowProcessId")]
    public string WorkflowProcessId { get; set; }

    /// <summary>
    /// Gets or Sets WorkflowState
    /// </summary>
    [DataMember(Name="workflowState", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workflowState")]
    public WorkflowState WorkflowState { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Shipment {\n");
      sb.Append("  AcceptedDate: ").Append(AcceptedDate).Append("\n");
      sb.Append("  Attributes: ").Append(Attributes).Append("\n");
      sb.Append("  AuditInfo: ").Append(AuditInfo).Append("\n");
      sb.Append("  CanceledItems: ").Append(CanceledItems).Append("\n");
      sb.Append("  ChangeMessages: ").Append(ChangeMessages).Append("\n");
      sb.Append("  ChildShipmentNumbers: ").Append(ChildShipmentNumbers).Append("\n");
      sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
      sb.Append("  CustomerAccountId: ").Append(CustomerAccountId).Append("\n");
      sb.Append("  CustomerAddressId: ").Append(CustomerAddressId).Append("\n");
      sb.Append("  CustomerTaxId: ").Append(CustomerTaxId).Append("\n");
      sb.Append("  Data: ").Append(Data).Append("\n");
      sb.Append("  Destination: ").Append(Destination).Append("\n");
      sb.Append("  DutyAdjustment: ").Append(DutyAdjustment).Append("\n");
      sb.Append("  DutyTotal: ").Append(DutyTotal).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  ExternalOrderId: ").Append(ExternalOrderId).Append("\n");
      sb.Append("  FulfillmentDate: ").Append(FulfillmentDate).Append("\n");
      sb.Append("  FulfillmentLocationCode: ").Append(FulfillmentLocationCode).Append("\n");
      sb.Append("  FulfillmentStatus: ").Append(FulfillmentStatus).Append("\n");
      sb.Append("  HandlingAdjustment: ").Append(HandlingAdjustment).Append("\n");
      sb.Append("  HandlingSubtotal: ").Append(HandlingSubtotal).Append("\n");
      sb.Append("  HandlingTaxAdjustment: ").Append(HandlingTaxAdjustment).Append("\n");
      sb.Append("  HandlingTaxTotal: ").Append(HandlingTaxTotal).Append("\n");
      sb.Append("  HandlingTotal: ").Append(HandlingTotal).Append("\n");
      sb.Append("  IsExpress: ").Append(IsExpress).Append("\n");
      sb.Append("  Items: ").Append(Items).Append("\n");
      sb.Append("  LineItemSubtotal: ").Append(LineItemSubtotal).Append("\n");
      sb.Append("  LineItemTaxAdjustment: ").Append(LineItemTaxAdjustment).Append("\n");
      sb.Append("  LineItemTaxTotal: ").Append(LineItemTaxTotal).Append("\n");
      sb.Append("  LineItemTotal: ").Append(LineItemTotal).Append("\n");
      sb.Append("  OrderId: ").Append(OrderId).Append("\n");
      sb.Append("  OrderNumber: ").Append(OrderNumber).Append("\n");
      sb.Append("  OrderSubmitDate: ").Append(OrderSubmitDate).Append("\n");
      sb.Append("  OriginalShipmentNumber: ").Append(OriginalShipmentNumber).Append("\n");
      sb.Append("  Packages: ").Append(Packages).Append("\n");
      sb.Append("  ParentShipmentNumber: ").Append(ParentShipmentNumber).Append("\n");
      sb.Append("  PickStatus: ").Append(PickStatus).Append("\n");
      sb.Append("  PickType: ").Append(PickType).Append("\n");
      sb.Append("  PickWaveNumber: ").Append(PickWaveNumber).Append("\n");
      sb.Append("  ReadyForPickup: ").Append(ReadyForPickup).Append("\n");
      sb.Append("  ReadyForPickupDate: ").Append(ReadyForPickupDate).Append("\n");
      sb.Append("  ReassignedItems: ").Append(ReassignedItems).Append("\n");
      sb.Append("  ReceivedDate: ").Append(ReceivedDate).Append("\n");
      sb.Append("  RejectedItems: ").Append(RejectedItems).Append("\n");
      sb.Append("  ShipmentAdjustment: ").Append(ShipmentAdjustment).Append("\n");
      sb.Append("  ShipmentNumber: ").Append(ShipmentNumber).Append("\n");
      sb.Append("  ShipmentStatus: ").Append(ShipmentStatus).Append("\n");
      sb.Append("  ShipmentStatusReason: ").Append(ShipmentStatusReason).Append("\n");
      sb.Append("  ShipmentType: ").Append(ShipmentType).Append("\n");
      sb.Append("  ShippingAdjustment: ").Append(ShippingAdjustment).Append("\n");
      sb.Append("  ShippingMethodCode: ").Append(ShippingMethodCode).Append("\n");
      sb.Append("  ShippingMethodName: ").Append(ShippingMethodName).Append("\n");
      sb.Append("  ShippingSubtotal: ").Append(ShippingSubtotal).Append("\n");
      sb.Append("  ShippingTaxAdjustment: ").Append(ShippingTaxAdjustment).Append("\n");
      sb.Append("  ShippingTaxTotal: ").Append(ShippingTaxTotal).Append("\n");
      sb.Append("  ShippingTotal: ").Append(ShippingTotal).Append("\n");
      sb.Append("  SiteId: ").Append(SiteId).Append("\n");
      sb.Append("  TaxData: ").Append(TaxData).Append("\n");
      sb.Append("  TenantId: ").Append(TenantId).Append("\n");
      sb.Append("  Total: ").Append(Total).Append("\n");
      sb.Append("  TransferShipmentNumbers: ").Append(TransferShipmentNumbers).Append("\n");
      sb.Append("  TransitTime: ").Append(TransitTime).Append("\n");
      sb.Append("  UserId: ").Append(UserId).Append("\n");
      sb.Append("  WorkflowProcessContainerId: ").Append(WorkflowProcessContainerId).Append("\n");
      sb.Append("  WorkflowProcessId: ").Append(WorkflowProcessId).Append("\n");
      sb.Append("  WorkflowState: ").Append(WorkflowState).Append("\n");
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
