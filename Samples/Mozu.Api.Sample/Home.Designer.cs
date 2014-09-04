namespace Mozu.Api.Sample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.lblAppId = new System.Windows.Forms.Label();
            this.lblSharedSecret = new System.Windows.Forms.Label();
            this.environmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtApplicationID = new System.Windows.Forms.TextBox();
            this.txtSharedSecret = new System.Windows.Forms.TextBox();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.siteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelAPI = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTenant = new System.Windows.Forms.Panel();
            this.lblTenantScope = new System.Windows.Forms.Label();
            this.cbTenant = new System.Windows.Forms.ComboBox();
            this.tenantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.pnlApplicationsCredentials = new System.Windows.Forms.Panel();
            this.lblApplicationCredentials = new System.Windows.Forms.Label();
            this.pnlUserScopeCredentials = new System.Windows.Forms.Panel();
            this.lblUserScopeCredentials = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMessages = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.environmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteBindingSource)).BeginInit();
            this.panelAPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTenant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenantBindingSource)).BeginInit();
            this.pnlApplicationsCredentials.SuspendLayout();
            this.pnlUserScopeCredentials.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblAppId.Location = new System.Drawing.Point(24, 19);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(74, 13);
            this.lblAppId.TabIndex = 0;
            this.lblAppId.Text = "Application Id:";
            // 
            // lblSharedSecret
            // 
            this.lblSharedSecret.AutoSize = true;
            this.lblSharedSecret.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSharedSecret.Location = new System.Drawing.Point(20, 41);
            this.lblSharedSecret.Name = "lblSharedSecret";
            this.lblSharedSecret.Size = new System.Drawing.Size(78, 13);
            this.lblSharedSecret.TabIndex = 1;
            this.lblSharedSecret.Text = "Shared Secret:";
            // 
            // environmentBindingSource
            // 
            this.environmentBindingSource.DataSource = typeof(Mozu.Api.Sample.Models.Environment);
            // 
            // txtApplicationID
            // 
            this.txtApplicationID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtApplicationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplicationID.Location = new System.Drawing.Point(108, 16);
            this.txtApplicationID.Name = "txtApplicationID";
            this.txtApplicationID.Size = new System.Drawing.Size(211, 20);
            this.txtApplicationID.TabIndex = 1;
            this.txtApplicationID.TextChanged += new System.EventHandler(this.AuthValuesChanged);
            // 
            // txtSharedSecret
            // 
            this.txtSharedSecret.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSharedSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSharedSecret.Location = new System.Drawing.Point(108, 38);
            this.txtSharedSecret.Name = "txtSharedSecret";
            this.txtSharedSecret.PasswordChar = '*';
            this.txtSharedSecret.Size = new System.Drawing.Size(211, 20);
            this.txtSharedSecret.TabIndex = 2;
            this.txtSharedSecret.TextChanged += new System.EventHandler(this.AuthValuesChanged);
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.BackColor = System.Drawing.Color.Silver;
            this.btnAuthenticate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAuthenticate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAuthenticate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAuthenticate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthenticate.Location = new System.Drawing.Point(122, 148);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(212, 23);
            this.btnAuthenticate.TabIndex = 5;
            this.btnAuthenticate.Text = "Authenticate";
            this.btnAuthenticate.UseVisualStyleBackColor = false;
            this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
            // 
            // siteBindingSource
            // 
            this.siteBindingSource.DataSource = typeof(Mozu.Api.Contracts.Tenant.Site);
            // 
            // panelAPI
            // 
            this.panelAPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAPI.Controls.Add(this.label1);
            this.panelAPI.Controls.Add(this.btnCustomer);
            this.panelAPI.Controls.Add(this.btnOrder);
            this.panelAPI.Controls.Add(this.btnProduct);
            this.panelAPI.Location = new System.Drawing.Point(12, 308);
            this.panelAPI.Name = "panelAPI";
            this.panelAPI.Size = new System.Drawing.Size(335, 57);
            this.panelAPI.TabIndex = 14;
            this.panelAPI.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "{Get} Data Samples";
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Location = new System.Drawing.Point(119, 26);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(99, 23);
            this.btnCustomer.TabIndex = 10;
            this.btnCustomer.Text = "Customers";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.DarkGray;
            this.btnOrder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Location = new System.Drawing.Point(221, 26);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(99, 23);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.Text = "Orders";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.DarkGray;
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Location = new System.Drawing.Point(17, 26);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(99, 23);
            this.btnProduct.TabIndex = 8;
            this.btnProduct.Text = "Products";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 50);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // cbSite
            // 
            this.cbSite.DataSource = this.siteBindingSource;
            this.cbSite.DisplayMember = "Name";
            this.cbSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Location = new System.Drawing.Point(107, 42);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(213, 21);
            this.cbSite.TabIndex = 7;
            this.cbSite.ValueMember = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(43, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tenant ID:";
            // 
            // panelTenant
            // 
            this.panelTenant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTenant.Controls.Add(this.lblTenantScope);
            this.panelTenant.Controls.Add(this.cbTenant);
            this.panelTenant.Controls.Add(this.label6);
            this.panelTenant.Controls.Add(this.label4);
            this.panelTenant.Controls.Add(this.cbSite);
            this.panelTenant.Location = new System.Drawing.Point(12, 234);
            this.panelTenant.Name = "panelTenant";
            this.panelTenant.Size = new System.Drawing.Size(335, 69);
            this.panelTenant.TabIndex = 13;
            this.panelTenant.Visible = false;
            // 
            // lblTenantScope
            // 
            this.lblTenantScope.AutoSize = true;
            this.lblTenantScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenantScope.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTenantScope.Location = new System.Drawing.Point(2, 1);
            this.lblTenantScope.Name = "lblTenantScope";
            this.lblTenantScope.Size = new System.Drawing.Size(148, 15);
            this.lblTenantScope.TabIndex = 18;
            this.lblTenantScope.Text = "Tenant Scope Credentials";
            // 
            // cbTenant
            // 
            this.cbTenant.DataSource = this.tenantBindingSource;
            this.cbTenant.DisplayMember = "Name";
            this.cbTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTenant.FormattingEnabled = true;
            this.cbTenant.Location = new System.Drawing.Point(107, 18);
            this.cbTenant.Name = "cbTenant";
            this.cbTenant.Size = new System.Drawing.Size(213, 21);
            this.cbTenant.TabIndex = 6;
            this.cbTenant.ValueMember = "Id";
            this.cbTenant.SelectedIndexChanged += new System.EventHandler(this.cbTenant_changed);
            // 
            // tenantBindingSource
            // 
            this.tenantBindingSource.DataSource = typeof(Mozu.Api.Contracts.Tenant.Tenant);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(73, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Site:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(107, 39);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(212, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(107, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(212, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPassword.Location = new System.Drawing.Point(41, 42);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblEmail.Location = new System.Drawing.Point(62, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Tag = "Email";
            this.lblEmail.Text = "Email:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 380);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(335, 125);
            this.txtLog.TabIndex = 20;
            this.txtLog.Text = "";
            // 
            // pnlApplicationsCredentials
            // 
            this.pnlApplicationsCredentials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlApplicationsCredentials.Controls.Add(this.lblApplicationCredentials);
            this.pnlApplicationsCredentials.Controls.Add(this.txtSharedSecret);
            this.pnlApplicationsCredentials.Controls.Add(this.lblAppId);
            this.pnlApplicationsCredentials.Controls.Add(this.lblSharedSecret);
            this.pnlApplicationsCredentials.Controls.Add(this.txtApplicationID);
            this.pnlApplicationsCredentials.Location = new System.Drawing.Point(14, 6);
            this.pnlApplicationsCredentials.Name = "pnlApplicationsCredentials";
            this.pnlApplicationsCredentials.Size = new System.Drawing.Size(335, 64);
            this.pnlApplicationsCredentials.TabIndex = 21;
            // 
            // lblApplicationCredentials
            // 
            this.lblApplicationCredentials.AutoSize = true;
            this.lblApplicationCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationCredentials.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblApplicationCredentials.Location = new System.Drawing.Point(0, -1);
            this.lblApplicationCredentials.Name = "lblApplicationCredentials";
            this.lblApplicationCredentials.Size = new System.Drawing.Size(132, 15);
            this.lblApplicationCredentials.TabIndex = 6;
            this.lblApplicationCredentials.Text = "Application Credentials";
            // 
            // pnlUserScopeCredentials
            // 
            this.pnlUserScopeCredentials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserScopeCredentials.Controls.Add(this.lblUserScopeCredentials);
            this.pnlUserScopeCredentials.Controls.Add(this.txtPassword);
            this.pnlUserScopeCredentials.Controls.Add(this.lblEmail);
            this.pnlUserScopeCredentials.Controls.Add(this.lblPassword);
            this.pnlUserScopeCredentials.Controls.Add(this.txtEmail);
            this.pnlUserScopeCredentials.Location = new System.Drawing.Point(14, 80);
            this.pnlUserScopeCredentials.Name = "pnlUserScopeCredentials";
            this.pnlUserScopeCredentials.Size = new System.Drawing.Size(335, 64);
            this.pnlUserScopeCredentials.TabIndex = 22;
            // 
            // lblUserScopeCredentials
            // 
            this.lblUserScopeCredentials.AutoSize = true;
            this.lblUserScopeCredentials.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserScopeCredentials.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblUserScopeCredentials.Location = new System.Drawing.Point(0, 0);
            this.lblUserScopeCredentials.Name = "lblUserScopeCredentials";
            this.lblUserScopeCredentials.Size = new System.Drawing.Size(136, 15);
            this.lblUserScopeCredentials.TabIndex = 7;
            this.lblUserScopeCredentials.Text = "User Scope Credentials";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Controls.Add(this.btnAuthenticate);
            this.panel3.Controls.Add(this.pnlUserScopeCredentials);
            this.panel3.Controls.Add(this.pnlApplicationsCredentials);
            this.panel3.Location = new System.Drawing.Point(-2, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 179);
            this.panel3.TabIndex = 23;
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMessages.Location = new System.Drawing.Point(15, 367);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(89, 13);
            this.lblMessages.TabIndex = 24;
            this.lblMessages.Text = "Messages \\ Logs";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(359, 514);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelTenant);
            this.Controls.Add(this.panelAPI);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "Mozu SDK Sample";
            ((System.ComponentModel.ISupportInitialize)(this.environmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteBindingSource)).EndInit();
            this.panelAPI.ResumeLayout(false);
            this.panelAPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTenant.ResumeLayout(false);
            this.panelTenant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenantBindingSource)).EndInit();
            this.pnlApplicationsCredentials.ResumeLayout(false);
            this.pnlApplicationsCredentials.PerformLayout();
            this.pnlUserScopeCredentials.ResumeLayout(false);
            this.pnlUserScopeCredentials.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Label lblSharedSecret;
        private System.Windows.Forms.TextBox txtApplicationID;
        private System.Windows.Forms.TextBox txtSharedSecret;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.BindingSource environmentBindingSource;
        private System.Windows.Forms.Panel panelAPI;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.BindingSource siteBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelTenant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ComboBox cbTenant;
        private System.Windows.Forms.BindingSource tenantBindingSource;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Panel pnlApplicationsCredentials;
        private System.Windows.Forms.Label lblApplicationCredentials;
        private System.Windows.Forms.Panel pnlUserScopeCredentials;
        private System.Windows.Forms.Label lblUserScopeCredentials;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Label lblTenantScope;
    }
}

