namespace Mozu.Api.Sample.CustomerHandler
{
    partial class Customers
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
            this.btnGetCustomers = new System.Windows.Forms.Button();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.customerAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acceptsMarketingDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.companyOrOrganizationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAnonymousDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxExemptDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.taxIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerAccountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetCustomers
            // 
            this.btnGetCustomers.BackColor = System.Drawing.Color.Silver;
            this.btnGetCustomers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGetCustomers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGetCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGetCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetCustomers.Location = new System.Drawing.Point(5, 5);
            this.btnGetCustomers.Name = "btnGetCustomers";
            this.btnGetCustomers.Size = new System.Drawing.Size(212, 23);
            this.btnGetCustomers.TabIndex = 10;
            this.btnGetCustomers.Text = "Get Customers";
            this.btnGetCustomers.UseVisualStyleBackColor = false;
            this.btnGetCustomers.Click += new System.EventHandler(this.btnGetCustomers_Click);
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.AllowUserToAddRows = false;
            this.dataGridViewCustomers.AllowUserToDeleteRows = false;
            this.dataGridViewCustomers.AutoGenerateColumns = false;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acceptsMarketingDataGridViewCheckBoxColumn,
            this.companyOrOrganizationDataGridViewTextBoxColumn,
            this.emailAddressDataGridViewTextBoxColumn,
            this.externalIdDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.isAnonymousDataGridViewCheckBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.localeCodeDataGridViewTextBoxColumn,
            this.taxExemptDataGridViewCheckBoxColumn,
            this.taxIdDataGridViewTextBoxColumn,
            this.userIdDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.auditInfoDataGridViewTextBoxColumn});
            this.dataGridViewCustomers.DataSource = this.customerAccountBindingSource;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(2, 34);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.ReadOnly = true;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(937, 396);
            this.dataGridViewCustomers.TabIndex = 9;
            // 
            // customerAccountBindingSource
            // 
            this.customerAccountBindingSource.DataSource = typeof(Mozu.Api.Contracts.Customer.CustomerAccount);
            // 
            // acceptsMarketingDataGridViewCheckBoxColumn
            // 
            this.acceptsMarketingDataGridViewCheckBoxColumn.DataPropertyName = "AcceptsMarketing";
            this.acceptsMarketingDataGridViewCheckBoxColumn.HeaderText = "AcceptsMarketing";
            this.acceptsMarketingDataGridViewCheckBoxColumn.Name = "acceptsMarketingDataGridViewCheckBoxColumn";
            this.acceptsMarketingDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // companyOrOrganizationDataGridViewTextBoxColumn
            // 
            this.companyOrOrganizationDataGridViewTextBoxColumn.DataPropertyName = "CompanyOrOrganization";
            this.companyOrOrganizationDataGridViewTextBoxColumn.HeaderText = "CompanyOrOrganization";
            this.companyOrOrganizationDataGridViewTextBoxColumn.Name = "companyOrOrganizationDataGridViewTextBoxColumn";
            this.companyOrOrganizationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailAddressDataGridViewTextBoxColumn
            // 
            this.emailAddressDataGridViewTextBoxColumn.DataPropertyName = "EmailAddress";
            this.emailAddressDataGridViewTextBoxColumn.HeaderText = "EmailAddress";
            this.emailAddressDataGridViewTextBoxColumn.Name = "emailAddressDataGridViewTextBoxColumn";
            this.emailAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // externalIdDataGridViewTextBoxColumn
            // 
            this.externalIdDataGridViewTextBoxColumn.DataPropertyName = "ExternalId";
            this.externalIdDataGridViewTextBoxColumn.HeaderText = "ExternalId";
            this.externalIdDataGridViewTextBoxColumn.Name = "externalIdDataGridViewTextBoxColumn";
            this.externalIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isAnonymousDataGridViewCheckBoxColumn
            // 
            this.isAnonymousDataGridViewCheckBoxColumn.DataPropertyName = "IsAnonymous";
            this.isAnonymousDataGridViewCheckBoxColumn.HeaderText = "IsAnonymous";
            this.isAnonymousDataGridViewCheckBoxColumn.Name = "isAnonymousDataGridViewCheckBoxColumn";
            this.isAnonymousDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localeCodeDataGridViewTextBoxColumn
            // 
            this.localeCodeDataGridViewTextBoxColumn.DataPropertyName = "LocaleCode";
            this.localeCodeDataGridViewTextBoxColumn.HeaderText = "LocaleCode";
            this.localeCodeDataGridViewTextBoxColumn.Name = "localeCodeDataGridViewTextBoxColumn";
            this.localeCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxExemptDataGridViewCheckBoxColumn
            // 
            this.taxExemptDataGridViewCheckBoxColumn.DataPropertyName = "TaxExempt";
            this.taxExemptDataGridViewCheckBoxColumn.HeaderText = "TaxExempt";
            this.taxExemptDataGridViewCheckBoxColumn.Name = "taxExemptDataGridViewCheckBoxColumn";
            this.taxExemptDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // taxIdDataGridViewTextBoxColumn
            // 
            this.taxIdDataGridViewTextBoxColumn.DataPropertyName = "TaxId";
            this.taxIdDataGridViewTextBoxColumn.HeaderText = "TaxId";
            this.taxIdDataGridViewTextBoxColumn.Name = "taxIdDataGridViewTextBoxColumn";
            this.taxIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            this.userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            this.userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            this.userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            this.userIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // auditInfoDataGridViewTextBoxColumn
            // 
            this.auditInfoDataGridViewTextBoxColumn.DataPropertyName = "AuditInfo";
            this.auditInfoDataGridViewTextBoxColumn.HeaderText = "AuditInfo";
            this.auditInfoDataGridViewTextBoxColumn.Name = "auditInfoDataGridViewTextBoxColumn";
            this.auditInfoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(943, 433);
            this.Controls.Add(this.btnGetCustomers);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Name = "Customers";
            this.Text = "Customer API Window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerAccountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetCustomers;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn acceptsMarketingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyOrOrganizationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAnonymousDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localeCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn taxExemptDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource customerAccountBindingSource;

    }
}