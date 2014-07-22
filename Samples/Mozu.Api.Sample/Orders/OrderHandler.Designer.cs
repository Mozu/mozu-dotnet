namespace Mozu.Api.Sample.OrderHandler
{
    partial class Orders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.btnGetOrders = new System.Windows.Forms.Button();
            this.btnGetOrderByGuid = new System.Windows.Forms.Button();
            this.txtOrderGuid = new System.Windows.Forms.TextBox();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acceptedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acceptsMarketingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountAvailableForRefundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountRemainingForPaymentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelledDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channelCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerAccountIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInteractionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerTaxIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountedSubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountedTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fulfillmentStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlingAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlingTaxTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlingTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasDraftDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDraftDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEligibleForReturnsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isImportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTaxExemptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTaxTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastValidationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalCartIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentReturnIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingSubTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingTaxTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDeviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submittedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenantIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCollectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webSessionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.AutoGenerateColumns = false;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acceptedDateDataGridViewTextBoxColumn,
            this.acceptsMarketingDataGridViewTextBoxColumn,
            this.amountAvailableForRefundDataGridViewTextBoxColumn,
            this.amountRemainingForPaymentDataGridViewTextBoxColumn,
            this.cancelledDateDataGridViewTextBoxColumn,
            this.channelCodeDataGridViewTextBoxColumn,
            this.closedDateDataGridViewTextBoxColumn,
            this.currencyCodeDataGridViewTextBoxColumn,
            this.customerAccountIdDataGridViewTextBoxColumn,
            this.customerInteractionTypeDataGridViewTextBoxColumn,
            this.customerTaxIdDataGridViewTextBoxColumn,
            this.discountedSubtotalDataGridViewTextBoxColumn,
            this.discountedTotalDataGridViewTextBoxColumn,
            this.discountTotalDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.externalIdDataGridViewTextBoxColumn,
            this.feeTotalDataGridViewTextBoxColumn,
            this.fulfillmentStatusDataGridViewTextBoxColumn,
            this.handlingAmountDataGridViewTextBoxColumn,
            this.handlingTaxTotalDataGridViewTextBoxColumn,
            this.handlingTotalDataGridViewTextBoxColumn,
            this.hasDraftDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.importDateDataGridViewTextBoxColumn,
            this.ipAddressDataGridViewTextBoxColumn,
            this.isDraftDataGridViewTextBoxColumn,
            this.isEligibleForReturnsDataGridViewCheckBoxColumn,
            this.isImportDataGridViewTextBoxColumn,
            this.isTaxExemptDataGridViewTextBoxColumn,
            this.itemTaxTotalDataGridViewTextBoxColumn,
            this.lastValidationDateDataGridViewTextBoxColumn,
            this.locationCodeDataGridViewTextBoxColumn,
            this.orderNumberDataGridViewTextBoxColumn,
            this.originalCartIdDataGridViewTextBoxColumn,
            this.parentReturnIdDataGridViewTextBoxColumn,
            this.paymentStatusDataGridViewTextBoxColumn,
            this.returnStatusDataGridViewTextBoxColumn,
            this.shippingSubTotalDataGridViewTextBoxColumn,
            this.shippingTaxTotalDataGridViewTextBoxColumn,
            this.shippingTotalDataGridViewTextBoxColumn,
            this.siteIdDataGridViewTextBoxColumn,
            this.sourceDeviceDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.submittedDateDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn,
            this.taxTotalDataGridViewTextBoxColumn,
            this.tenantIdDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.totalCollectedDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.visitIdDataGridViewTextBoxColumn,
            this.webSessionIdDataGridViewTextBoxColumn});
            this.dataGridViewOrders.DataSource = this.orderBindingSource;
            this.dataGridViewOrders.Location = new System.Drawing.Point(2, 35);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.Size = new System.Drawing.Size(937, 396);
            this.dataGridViewOrders.TabIndex = 2;
            this.dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellContentClick);
            // 
            // btnGetOrders
            // 
            this.btnGetOrders.BackColor = System.Drawing.Color.Silver;
            this.btnGetOrders.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGetOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGetOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetOrders.Location = new System.Drawing.Point(5, 6);
            this.btnGetOrders.Name = "btnGetOrders";
            this.btnGetOrders.Size = new System.Drawing.Size(212, 23);
            this.btnGetOrders.TabIndex = 6;
            this.btnGetOrders.Text = "Get Orders";
            this.btnGetOrders.UseVisualStyleBackColor = false;
            this.btnGetOrders.Click += new System.EventHandler(this.btnGetOrders_Click);
            // 
            // btnGetOrderByGuid
            // 
            this.btnGetOrderByGuid.BackColor = System.Drawing.Color.Silver;
            this.btnGetOrderByGuid.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetOrderByGuid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGetOrderByGuid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGetOrderByGuid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetOrderByGuid.Location = new System.Drawing.Point(795, 6);
            this.btnGetOrderByGuid.Name = "btnGetOrderByGuid";
            this.btnGetOrderByGuid.Size = new System.Drawing.Size(134, 23);
            this.btnGetOrderByGuid.TabIndex = 8;
            this.btnGetOrderByGuid.Text = "Get Order By Id GUID";
            this.btnGetOrderByGuid.UseVisualStyleBackColor = false;
            this.btnGetOrderByGuid.Click += new System.EventHandler(this.btnGetOrderByGuid_Click);
            // 
            // txtOrderGuid
            // 
            this.txtOrderGuid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtOrderGuid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderGuid.Location = new System.Drawing.Point(567, 8);
            this.txtOrderGuid.Name = "txtOrderGuid";
            this.txtOrderGuid.Size = new System.Drawing.Size(222, 20);
            this.txtOrderGuid.TabIndex = 7;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(Mozu.Api.Contracts.CommerceRuntime.Orders.Order);
            // 
            // acceptedDateDataGridViewTextBoxColumn
            // 
            this.acceptedDateDataGridViewTextBoxColumn.DataPropertyName = "AcceptedDate";
            this.acceptedDateDataGridViewTextBoxColumn.HeaderText = "AcceptedDate";
            this.acceptedDateDataGridViewTextBoxColumn.Name = "acceptedDateDataGridViewTextBoxColumn";
            this.acceptedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // acceptsMarketingDataGridViewTextBoxColumn
            // 
            this.acceptsMarketingDataGridViewTextBoxColumn.DataPropertyName = "AcceptsMarketing";
            this.acceptsMarketingDataGridViewTextBoxColumn.HeaderText = "AcceptsMarketing";
            this.acceptsMarketingDataGridViewTextBoxColumn.Name = "acceptsMarketingDataGridViewTextBoxColumn";
            this.acceptsMarketingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountAvailableForRefundDataGridViewTextBoxColumn
            // 
            this.amountAvailableForRefundDataGridViewTextBoxColumn.DataPropertyName = "AmountAvailableForRefund";
            this.amountAvailableForRefundDataGridViewTextBoxColumn.HeaderText = "AmountAvailableForRefund";
            this.amountAvailableForRefundDataGridViewTextBoxColumn.Name = "amountAvailableForRefundDataGridViewTextBoxColumn";
            this.amountAvailableForRefundDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountRemainingForPaymentDataGridViewTextBoxColumn
            // 
            this.amountRemainingForPaymentDataGridViewTextBoxColumn.DataPropertyName = "AmountRemainingForPayment";
            this.amountRemainingForPaymentDataGridViewTextBoxColumn.HeaderText = "AmountRemainingForPayment";
            this.amountRemainingForPaymentDataGridViewTextBoxColumn.Name = "amountRemainingForPaymentDataGridViewTextBoxColumn";
            this.amountRemainingForPaymentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cancelledDateDataGridViewTextBoxColumn
            // 
            this.cancelledDateDataGridViewTextBoxColumn.DataPropertyName = "CancelledDate";
            this.cancelledDateDataGridViewTextBoxColumn.HeaderText = "CancelledDate";
            this.cancelledDateDataGridViewTextBoxColumn.Name = "cancelledDateDataGridViewTextBoxColumn";
            this.cancelledDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // channelCodeDataGridViewTextBoxColumn
            // 
            this.channelCodeDataGridViewTextBoxColumn.DataPropertyName = "ChannelCode";
            this.channelCodeDataGridViewTextBoxColumn.HeaderText = "ChannelCode";
            this.channelCodeDataGridViewTextBoxColumn.Name = "channelCodeDataGridViewTextBoxColumn";
            this.channelCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // closedDateDataGridViewTextBoxColumn
            // 
            this.closedDateDataGridViewTextBoxColumn.DataPropertyName = "ClosedDate";
            this.closedDateDataGridViewTextBoxColumn.HeaderText = "ClosedDate";
            this.closedDateDataGridViewTextBoxColumn.Name = "closedDateDataGridViewTextBoxColumn";
            this.closedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currencyCodeDataGridViewTextBoxColumn
            // 
            this.currencyCodeDataGridViewTextBoxColumn.DataPropertyName = "CurrencyCode";
            this.currencyCodeDataGridViewTextBoxColumn.HeaderText = "CurrencyCode";
            this.currencyCodeDataGridViewTextBoxColumn.Name = "currencyCodeDataGridViewTextBoxColumn";
            this.currencyCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerAccountIdDataGridViewTextBoxColumn
            // 
            this.customerAccountIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerAccountId";
            this.customerAccountIdDataGridViewTextBoxColumn.HeaderText = "CustomerAccountId";
            this.customerAccountIdDataGridViewTextBoxColumn.Name = "customerAccountIdDataGridViewTextBoxColumn";
            this.customerAccountIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerInteractionTypeDataGridViewTextBoxColumn
            // 
            this.customerInteractionTypeDataGridViewTextBoxColumn.DataPropertyName = "CustomerInteractionType";
            this.customerInteractionTypeDataGridViewTextBoxColumn.HeaderText = "CustomerInteractionType";
            this.customerInteractionTypeDataGridViewTextBoxColumn.Name = "customerInteractionTypeDataGridViewTextBoxColumn";
            this.customerInteractionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerTaxIdDataGridViewTextBoxColumn
            // 
            this.customerTaxIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerTaxId";
            this.customerTaxIdDataGridViewTextBoxColumn.HeaderText = "CustomerTaxId";
            this.customerTaxIdDataGridViewTextBoxColumn.Name = "customerTaxIdDataGridViewTextBoxColumn";
            this.customerTaxIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discountedSubtotalDataGridViewTextBoxColumn
            // 
            this.discountedSubtotalDataGridViewTextBoxColumn.DataPropertyName = "DiscountedSubtotal";
            this.discountedSubtotalDataGridViewTextBoxColumn.HeaderText = "DiscountedSubtotal";
            this.discountedSubtotalDataGridViewTextBoxColumn.Name = "discountedSubtotalDataGridViewTextBoxColumn";
            this.discountedSubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discountedTotalDataGridViewTextBoxColumn
            // 
            this.discountedTotalDataGridViewTextBoxColumn.DataPropertyName = "DiscountedTotal";
            this.discountedTotalDataGridViewTextBoxColumn.HeaderText = "DiscountedTotal";
            this.discountedTotalDataGridViewTextBoxColumn.Name = "discountedTotalDataGridViewTextBoxColumn";
            this.discountedTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discountTotalDataGridViewTextBoxColumn
            // 
            this.discountTotalDataGridViewTextBoxColumn.DataPropertyName = "DiscountTotal";
            this.discountTotalDataGridViewTextBoxColumn.HeaderText = "DiscountTotal";
            this.discountTotalDataGridViewTextBoxColumn.Name = "discountTotalDataGridViewTextBoxColumn";
            this.discountTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // externalIdDataGridViewTextBoxColumn
            // 
            this.externalIdDataGridViewTextBoxColumn.DataPropertyName = "ExternalId";
            this.externalIdDataGridViewTextBoxColumn.HeaderText = "ExternalId";
            this.externalIdDataGridViewTextBoxColumn.Name = "externalIdDataGridViewTextBoxColumn";
            this.externalIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // feeTotalDataGridViewTextBoxColumn
            // 
            this.feeTotalDataGridViewTextBoxColumn.DataPropertyName = "FeeTotal";
            this.feeTotalDataGridViewTextBoxColumn.HeaderText = "FeeTotal";
            this.feeTotalDataGridViewTextBoxColumn.Name = "feeTotalDataGridViewTextBoxColumn";
            this.feeTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fulfillmentStatusDataGridViewTextBoxColumn
            // 
            this.fulfillmentStatusDataGridViewTextBoxColumn.DataPropertyName = "FulfillmentStatus";
            this.fulfillmentStatusDataGridViewTextBoxColumn.HeaderText = "FulfillmentStatus";
            this.fulfillmentStatusDataGridViewTextBoxColumn.Name = "fulfillmentStatusDataGridViewTextBoxColumn";
            this.fulfillmentStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // handlingAmountDataGridViewTextBoxColumn
            // 
            this.handlingAmountDataGridViewTextBoxColumn.DataPropertyName = "HandlingAmount";
            this.handlingAmountDataGridViewTextBoxColumn.HeaderText = "HandlingAmount";
            this.handlingAmountDataGridViewTextBoxColumn.Name = "handlingAmountDataGridViewTextBoxColumn";
            this.handlingAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // handlingTaxTotalDataGridViewTextBoxColumn
            // 
            this.handlingTaxTotalDataGridViewTextBoxColumn.DataPropertyName = "HandlingTaxTotal";
            this.handlingTaxTotalDataGridViewTextBoxColumn.HeaderText = "HandlingTaxTotal";
            this.handlingTaxTotalDataGridViewTextBoxColumn.Name = "handlingTaxTotalDataGridViewTextBoxColumn";
            this.handlingTaxTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // handlingTotalDataGridViewTextBoxColumn
            // 
            this.handlingTotalDataGridViewTextBoxColumn.DataPropertyName = "HandlingTotal";
            this.handlingTotalDataGridViewTextBoxColumn.HeaderText = "HandlingTotal";
            this.handlingTotalDataGridViewTextBoxColumn.Name = "handlingTotalDataGridViewTextBoxColumn";
            this.handlingTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hasDraftDataGridViewTextBoxColumn
            // 
            this.hasDraftDataGridViewTextBoxColumn.DataPropertyName = "HasDraft";
            this.hasDraftDataGridViewTextBoxColumn.HeaderText = "HasDraft";
            this.hasDraftDataGridViewTextBoxColumn.Name = "hasDraftDataGridViewTextBoxColumn";
            this.hasDraftDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importDateDataGridViewTextBoxColumn
            // 
            this.importDateDataGridViewTextBoxColumn.DataPropertyName = "ImportDate";
            this.importDateDataGridViewTextBoxColumn.HeaderText = "ImportDate";
            this.importDateDataGridViewTextBoxColumn.Name = "importDateDataGridViewTextBoxColumn";
            this.importDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ipAddressDataGridViewTextBoxColumn
            // 
            this.ipAddressDataGridViewTextBoxColumn.DataPropertyName = "IpAddress";
            this.ipAddressDataGridViewTextBoxColumn.HeaderText = "IpAddress";
            this.ipAddressDataGridViewTextBoxColumn.Name = "ipAddressDataGridViewTextBoxColumn";
            this.ipAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isDraftDataGridViewTextBoxColumn
            // 
            this.isDraftDataGridViewTextBoxColumn.DataPropertyName = "IsDraft";
            this.isDraftDataGridViewTextBoxColumn.HeaderText = "IsDraft";
            this.isDraftDataGridViewTextBoxColumn.Name = "isDraftDataGridViewTextBoxColumn";
            this.isDraftDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isEligibleForReturnsDataGridViewCheckBoxColumn
            // 
            this.isEligibleForReturnsDataGridViewCheckBoxColumn.DataPropertyName = "IsEligibleForReturns";
            this.isEligibleForReturnsDataGridViewCheckBoxColumn.HeaderText = "IsEligibleForReturns";
            this.isEligibleForReturnsDataGridViewCheckBoxColumn.Name = "isEligibleForReturnsDataGridViewCheckBoxColumn";
            this.isEligibleForReturnsDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // isImportDataGridViewTextBoxColumn
            // 
            this.isImportDataGridViewTextBoxColumn.DataPropertyName = "IsImport";
            this.isImportDataGridViewTextBoxColumn.HeaderText = "IsImport";
            this.isImportDataGridViewTextBoxColumn.Name = "isImportDataGridViewTextBoxColumn";
            this.isImportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isTaxExemptDataGridViewTextBoxColumn
            // 
            this.isTaxExemptDataGridViewTextBoxColumn.DataPropertyName = "IsTaxExempt";
            this.isTaxExemptDataGridViewTextBoxColumn.HeaderText = "IsTaxExempt";
            this.isTaxExemptDataGridViewTextBoxColumn.Name = "isTaxExemptDataGridViewTextBoxColumn";
            this.isTaxExemptDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemTaxTotalDataGridViewTextBoxColumn
            // 
            this.itemTaxTotalDataGridViewTextBoxColumn.DataPropertyName = "ItemTaxTotal";
            this.itemTaxTotalDataGridViewTextBoxColumn.HeaderText = "ItemTaxTotal";
            this.itemTaxTotalDataGridViewTextBoxColumn.Name = "itemTaxTotalDataGridViewTextBoxColumn";
            this.itemTaxTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastValidationDateDataGridViewTextBoxColumn
            // 
            this.lastValidationDateDataGridViewTextBoxColumn.DataPropertyName = "LastValidationDate";
            this.lastValidationDateDataGridViewTextBoxColumn.HeaderText = "LastValidationDate";
            this.lastValidationDateDataGridViewTextBoxColumn.Name = "lastValidationDateDataGridViewTextBoxColumn";
            this.lastValidationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationCodeDataGridViewTextBoxColumn
            // 
            this.locationCodeDataGridViewTextBoxColumn.DataPropertyName = "LocationCode";
            this.locationCodeDataGridViewTextBoxColumn.HeaderText = "LocationCode";
            this.locationCodeDataGridViewTextBoxColumn.Name = "locationCodeDataGridViewTextBoxColumn";
            this.locationCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "OrderNumber";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "OrderNumber";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // originalCartIdDataGridViewTextBoxColumn
            // 
            this.originalCartIdDataGridViewTextBoxColumn.DataPropertyName = "OriginalCartId";
            this.originalCartIdDataGridViewTextBoxColumn.HeaderText = "OriginalCartId";
            this.originalCartIdDataGridViewTextBoxColumn.Name = "originalCartIdDataGridViewTextBoxColumn";
            this.originalCartIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // parentReturnIdDataGridViewTextBoxColumn
            // 
            this.parentReturnIdDataGridViewTextBoxColumn.DataPropertyName = "ParentReturnId";
            this.parentReturnIdDataGridViewTextBoxColumn.HeaderText = "ParentReturnId";
            this.parentReturnIdDataGridViewTextBoxColumn.Name = "parentReturnIdDataGridViewTextBoxColumn";
            this.parentReturnIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentStatusDataGridViewTextBoxColumn
            // 
            this.paymentStatusDataGridViewTextBoxColumn.DataPropertyName = "PaymentStatus";
            this.paymentStatusDataGridViewTextBoxColumn.HeaderText = "PaymentStatus";
            this.paymentStatusDataGridViewTextBoxColumn.Name = "paymentStatusDataGridViewTextBoxColumn";
            this.paymentStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // returnStatusDataGridViewTextBoxColumn
            // 
            this.returnStatusDataGridViewTextBoxColumn.DataPropertyName = "ReturnStatus";
            this.returnStatusDataGridViewTextBoxColumn.HeaderText = "ReturnStatus";
            this.returnStatusDataGridViewTextBoxColumn.Name = "returnStatusDataGridViewTextBoxColumn";
            this.returnStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shippingSubTotalDataGridViewTextBoxColumn
            // 
            this.shippingSubTotalDataGridViewTextBoxColumn.DataPropertyName = "ShippingSubTotal";
            this.shippingSubTotalDataGridViewTextBoxColumn.HeaderText = "ShippingSubTotal";
            this.shippingSubTotalDataGridViewTextBoxColumn.Name = "shippingSubTotalDataGridViewTextBoxColumn";
            this.shippingSubTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shippingTaxTotalDataGridViewTextBoxColumn
            // 
            this.shippingTaxTotalDataGridViewTextBoxColumn.DataPropertyName = "ShippingTaxTotal";
            this.shippingTaxTotalDataGridViewTextBoxColumn.HeaderText = "ShippingTaxTotal";
            this.shippingTaxTotalDataGridViewTextBoxColumn.Name = "shippingTaxTotalDataGridViewTextBoxColumn";
            this.shippingTaxTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shippingTotalDataGridViewTextBoxColumn
            // 
            this.shippingTotalDataGridViewTextBoxColumn.DataPropertyName = "ShippingTotal";
            this.shippingTotalDataGridViewTextBoxColumn.HeaderText = "ShippingTotal";
            this.shippingTotalDataGridViewTextBoxColumn.Name = "shippingTotalDataGridViewTextBoxColumn";
            this.shippingTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siteIdDataGridViewTextBoxColumn
            // 
            this.siteIdDataGridViewTextBoxColumn.DataPropertyName = "SiteId";
            this.siteIdDataGridViewTextBoxColumn.HeaderText = "SiteId";
            this.siteIdDataGridViewTextBoxColumn.Name = "siteIdDataGridViewTextBoxColumn";
            this.siteIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sourceDeviceDataGridViewTextBoxColumn
            // 
            this.sourceDeviceDataGridViewTextBoxColumn.DataPropertyName = "SourceDevice";
            this.sourceDeviceDataGridViewTextBoxColumn.HeaderText = "SourceDevice";
            this.sourceDeviceDataGridViewTextBoxColumn.Name = "sourceDeviceDataGridViewTextBoxColumn";
            this.sourceDeviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // submittedDateDataGridViewTextBoxColumn
            // 
            this.submittedDateDataGridViewTextBoxColumn.DataPropertyName = "SubmittedDate";
            this.submittedDateDataGridViewTextBoxColumn.HeaderText = "SubmittedDate";
            this.submittedDateDataGridViewTextBoxColumn.Name = "submittedDateDataGridViewTextBoxColumn";
            this.submittedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxTotalDataGridViewTextBoxColumn
            // 
            this.taxTotalDataGridViewTextBoxColumn.DataPropertyName = "TaxTotal";
            this.taxTotalDataGridViewTextBoxColumn.HeaderText = "TaxTotal";
            this.taxTotalDataGridViewTextBoxColumn.Name = "taxTotalDataGridViewTextBoxColumn";
            this.taxTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tenantIdDataGridViewTextBoxColumn
            // 
            this.tenantIdDataGridViewTextBoxColumn.DataPropertyName = "TenantId";
            this.tenantIdDataGridViewTextBoxColumn.HeaderText = "TenantId";
            this.tenantIdDataGridViewTextBoxColumn.Name = "tenantIdDataGridViewTextBoxColumn";
            this.tenantIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalCollectedDataGridViewTextBoxColumn
            // 
            this.totalCollectedDataGridViewTextBoxColumn.DataPropertyName = "TotalCollected";
            this.totalCollectedDataGridViewTextBoxColumn.HeaderText = "TotalCollected";
            this.totalCollectedDataGridViewTextBoxColumn.Name = "totalCollectedDataGridViewTextBoxColumn";
            this.totalCollectedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // visitIdDataGridViewTextBoxColumn
            // 
            this.visitIdDataGridViewTextBoxColumn.DataPropertyName = "VisitId";
            this.visitIdDataGridViewTextBoxColumn.HeaderText = "VisitId";
            this.visitIdDataGridViewTextBoxColumn.Name = "visitIdDataGridViewTextBoxColumn";
            this.visitIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // webSessionIdDataGridViewTextBoxColumn
            // 
            this.webSessionIdDataGridViewTextBoxColumn.DataPropertyName = "WebSessionId";
            this.webSessionIdDataGridViewTextBoxColumn.HeaderText = "WebSessionId";
            this.webSessionIdDataGridViewTextBoxColumn.Name = "webSessionIdDataGridViewTextBoxColumn";
            this.webSessionIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(941, 434);
            this.Controls.Add(this.btnGetOrderByGuid);
            this.Controls.Add(this.txtOrderGuid);
            this.Controls.Add(this.btnGetOrders);
            this.Controls.Add(this.dataGridViewOrders);
            this.Name = "Orders";
            this.Text = "Order API Window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button btnGetOrders;
        private System.Windows.Forms.Button btnGetOrderByGuid;
        private System.Windows.Forms.TextBox txtOrderGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn acceptedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn acceptsMarketingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountAvailableForRefundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountRemainingForPaymentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancelledDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn channelCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerAccountIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerInteractionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerTaxIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountedSubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountedTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fulfillmentStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlingAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlingTaxTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlingTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasDraftDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDraftDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEligibleForReturnsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isImportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isTaxExemptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTaxTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastValidationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalCartIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentReturnIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingSubTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingTaxTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDeviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submittedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenantIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCollectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn webSessionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderBindingSource;
    }
}