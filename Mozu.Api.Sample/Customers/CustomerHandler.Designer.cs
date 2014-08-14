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
            this.btnGetCustomers = new System.Windows.Forms.Button();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
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
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(2, 34);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.ReadOnly = true;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(937, 396);
            this.dataGridViewCustomers.TabIndex = 9;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetCustomers;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;

    }
}