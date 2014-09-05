namespace Mozu.Api.Sample.ProductHandler
{
    partial class Home
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
            this.btnGetProducts = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseProductCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasConfigurableOptionsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasStandAloneOptionsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isPackagedStandAloneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRecurringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTaxableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isValidForProductTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVariationDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.masterCatalogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSequenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shippingClassIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standAlonePackageTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variationKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetProducts
            // 
            this.btnGetProducts.BackColor = System.Drawing.Color.Silver;
            this.btnGetProducts.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetProducts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGetProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGetProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetProducts.Location = new System.Drawing.Point(6, 7);
            this.btnGetProducts.Name = "btnGetProducts";
            this.btnGetProducts.Size = new System.Drawing.Size(212, 23);
            this.btnGetProducts.TabIndex = 8;
            this.btnGetProducts.Text = "Get Products";
            this.btnGetProducts.UseVisualStyleBackColor = false;
            this.btnGetProducts.Click += new System.EventHandler(this.btnGetProducts_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoGenerateColumns = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.baseProductCodeDataGridViewTextBoxColumn,
            this.hasConfigurableOptionsDataGridViewCheckBoxColumn,
            this.hasStandAloneOptionsDataGridViewCheckBoxColumn,
            this.isPackagedStandAloneDataGridViewTextBoxColumn,
            this.isRecurringDataGridViewTextBoxColumn,
            this.isTaxableDataGridViewTextBoxColumn,
            this.isValidForProductTypeDataGridViewTextBoxColumn,
            this.isVariationDataGridViewCheckBoxColumn,
            this.masterCatalogIdDataGridViewTextBoxColumn,
            this.productCodeDataGridViewTextBoxColumn,
            this.productSequenceDataGridViewTextBoxColumn,
            this.productTypeIdDataGridViewTextBoxColumn,
            this.productUsageDataGridViewTextBoxColumn,
            this.shippingClassIdDataGridViewTextBoxColumn,
            this.standAlonePackageTypeDataGridViewTextBoxColumn,
            this.upcDataGridViewTextBoxColumn,
            this.variationKeyDataGridViewTextBoxColumn,
            this.auditInfoDataGridViewTextBoxColumn,
            this.contentDataGridViewTextBoxColumn});
            this.dataGridViewProducts.DataSource = this.productBindingSource;
            this.dataGridViewProducts.Location = new System.Drawing.Point(3, 36);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.Size = new System.Drawing.Size(937, 396);
            this.dataGridViewProducts.TabIndex = 7;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(Mozu.Api.Contracts.ProductAdmin.Product);
            // 
            // baseProductCodeDataGridViewTextBoxColumn
            // 
            this.baseProductCodeDataGridViewTextBoxColumn.DataPropertyName = "BaseProductCode";
            this.baseProductCodeDataGridViewTextBoxColumn.HeaderText = "BaseProductCode";
            this.baseProductCodeDataGridViewTextBoxColumn.Name = "baseProductCodeDataGridViewTextBoxColumn";
            this.baseProductCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hasConfigurableOptionsDataGridViewCheckBoxColumn
            // 
            this.hasConfigurableOptionsDataGridViewCheckBoxColumn.DataPropertyName = "HasConfigurableOptions";
            this.hasConfigurableOptionsDataGridViewCheckBoxColumn.HeaderText = "HasConfigurableOptions";
            this.hasConfigurableOptionsDataGridViewCheckBoxColumn.Name = "hasConfigurableOptionsDataGridViewCheckBoxColumn";
            this.hasConfigurableOptionsDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // hasStandAloneOptionsDataGridViewCheckBoxColumn
            // 
            this.hasStandAloneOptionsDataGridViewCheckBoxColumn.DataPropertyName = "HasStandAloneOptions";
            this.hasStandAloneOptionsDataGridViewCheckBoxColumn.HeaderText = "HasStandAloneOptions";
            this.hasStandAloneOptionsDataGridViewCheckBoxColumn.Name = "hasStandAloneOptionsDataGridViewCheckBoxColumn";
            this.hasStandAloneOptionsDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // isPackagedStandAloneDataGridViewTextBoxColumn
            // 
            this.isPackagedStandAloneDataGridViewTextBoxColumn.DataPropertyName = "IsPackagedStandAlone";
            this.isPackagedStandAloneDataGridViewTextBoxColumn.HeaderText = "IsPackagedStandAlone";
            this.isPackagedStandAloneDataGridViewTextBoxColumn.Name = "isPackagedStandAloneDataGridViewTextBoxColumn";
            this.isPackagedStandAloneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isRecurringDataGridViewTextBoxColumn
            // 
            this.isRecurringDataGridViewTextBoxColumn.DataPropertyName = "IsRecurring";
            this.isRecurringDataGridViewTextBoxColumn.HeaderText = "IsRecurring";
            this.isRecurringDataGridViewTextBoxColumn.Name = "isRecurringDataGridViewTextBoxColumn";
            this.isRecurringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isTaxableDataGridViewTextBoxColumn
            // 
            this.isTaxableDataGridViewTextBoxColumn.DataPropertyName = "IsTaxable";
            this.isTaxableDataGridViewTextBoxColumn.HeaderText = "IsTaxable";
            this.isTaxableDataGridViewTextBoxColumn.Name = "isTaxableDataGridViewTextBoxColumn";
            this.isTaxableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isValidForProductTypeDataGridViewTextBoxColumn
            // 
            this.isValidForProductTypeDataGridViewTextBoxColumn.DataPropertyName = "IsValidForProductType";
            this.isValidForProductTypeDataGridViewTextBoxColumn.HeaderText = "IsValidForProductType";
            this.isValidForProductTypeDataGridViewTextBoxColumn.Name = "isValidForProductTypeDataGridViewTextBoxColumn";
            this.isValidForProductTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isVariationDataGridViewCheckBoxColumn
            // 
            this.isVariationDataGridViewCheckBoxColumn.DataPropertyName = "IsVariation";
            this.isVariationDataGridViewCheckBoxColumn.HeaderText = "IsVariation";
            this.isVariationDataGridViewCheckBoxColumn.Name = "isVariationDataGridViewCheckBoxColumn";
            this.isVariationDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // masterCatalogIdDataGridViewTextBoxColumn
            // 
            this.masterCatalogIdDataGridViewTextBoxColumn.DataPropertyName = "MasterCatalogId";
            this.masterCatalogIdDataGridViewTextBoxColumn.HeaderText = "MasterCatalogId";
            this.masterCatalogIdDataGridViewTextBoxColumn.Name = "masterCatalogIdDataGridViewTextBoxColumn";
            this.masterCatalogIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productCodeDataGridViewTextBoxColumn
            // 
            this.productCodeDataGridViewTextBoxColumn.DataPropertyName = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.HeaderText = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.Name = "productCodeDataGridViewTextBoxColumn";
            this.productCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productSequenceDataGridViewTextBoxColumn
            // 
            this.productSequenceDataGridViewTextBoxColumn.DataPropertyName = "ProductSequence";
            this.productSequenceDataGridViewTextBoxColumn.HeaderText = "ProductSequence";
            this.productSequenceDataGridViewTextBoxColumn.Name = "productSequenceDataGridViewTextBoxColumn";
            this.productSequenceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productTypeIdDataGridViewTextBoxColumn
            // 
            this.productTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ProductTypeId";
            this.productTypeIdDataGridViewTextBoxColumn.HeaderText = "ProductTypeId";
            this.productTypeIdDataGridViewTextBoxColumn.Name = "productTypeIdDataGridViewTextBoxColumn";
            this.productTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productUsageDataGridViewTextBoxColumn
            // 
            this.productUsageDataGridViewTextBoxColumn.DataPropertyName = "ProductUsage";
            this.productUsageDataGridViewTextBoxColumn.HeaderText = "ProductUsage";
            this.productUsageDataGridViewTextBoxColumn.Name = "productUsageDataGridViewTextBoxColumn";
            this.productUsageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shippingClassIdDataGridViewTextBoxColumn
            // 
            this.shippingClassIdDataGridViewTextBoxColumn.DataPropertyName = "ShippingClassId";
            this.shippingClassIdDataGridViewTextBoxColumn.HeaderText = "ShippingClassId";
            this.shippingClassIdDataGridViewTextBoxColumn.Name = "shippingClassIdDataGridViewTextBoxColumn";
            this.shippingClassIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // standAlonePackageTypeDataGridViewTextBoxColumn
            // 
            this.standAlonePackageTypeDataGridViewTextBoxColumn.DataPropertyName = "StandAlonePackageType";
            this.standAlonePackageTypeDataGridViewTextBoxColumn.HeaderText = "StandAlonePackageType";
            this.standAlonePackageTypeDataGridViewTextBoxColumn.Name = "standAlonePackageTypeDataGridViewTextBoxColumn";
            this.standAlonePackageTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // upcDataGridViewTextBoxColumn
            // 
            this.upcDataGridViewTextBoxColumn.DataPropertyName = "Upc";
            this.upcDataGridViewTextBoxColumn.HeaderText = "Upc";
            this.upcDataGridViewTextBoxColumn.Name = "upcDataGridViewTextBoxColumn";
            this.upcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // variationKeyDataGridViewTextBoxColumn
            // 
            this.variationKeyDataGridViewTextBoxColumn.DataPropertyName = "VariationKey";
            this.variationKeyDataGridViewTextBoxColumn.HeaderText = "VariationKey";
            this.variationKeyDataGridViewTextBoxColumn.Name = "variationKeyDataGridViewTextBoxColumn";
            this.variationKeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // auditInfoDataGridViewTextBoxColumn
            // 
            this.auditInfoDataGridViewTextBoxColumn.DataPropertyName = "AuditInfo";
            this.auditInfoDataGridViewTextBoxColumn.HeaderText = "AuditInfo";
            this.auditInfoDataGridViewTextBoxColumn.Name = "auditInfoDataGridViewTextBoxColumn";
            this.auditInfoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            this.contentDataGridViewTextBoxColumn.HeaderText = "Content";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(946, 440);
            this.Controls.Add(this.btnGetProducts);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "Home";
            this.Text = "Products API Window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetProducts;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseProductCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasConfigurableOptionsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasStandAloneOptionsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPackagedStandAloneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isRecurringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isTaxableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isValidForProductTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVariationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterCatalogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSequenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productUsageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shippingClassIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn standAlonePackageTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn upcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn variationKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productBindingSource;

    }
}