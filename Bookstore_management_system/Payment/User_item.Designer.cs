namespace Bookstore_management_system.DashBoard_v2
{
    partial class User_item
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label1_customerid = new System.Windows.Forms.Label();
            this.label_phone = new System.Windows.Forms.Label();
            this.label_namecustom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 12;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Salmon;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Location = new System.Drawing.Point(204, 2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(111, 45);
            this.guna2Button2.TabIndex = 1;
            this.guna2Button2.Text = "Lấy mã giảm giá";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label1_customerid
            // 
            this.label1_customerid.AutoSize = true;
            this.label1_customerid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_customerid.Location = new System.Drawing.Point(2, 2);
            this.label1_customerid.Name = "label1_customerid";
            this.label1_customerid.Size = new System.Drawing.Size(135, 20);
            this.label1_customerid.TabIndex = 2;
            this.label1_customerid.Text = "Mã khách hàng";
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Location = new System.Drawing.Point(107, 31);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(44, 16);
            this.label_phone.TabIndex = 3;
            this.label_phone.Text = "label2";
            // 
            // label_namecustom
            // 
            this.label_namecustom.AutoSize = true;
            this.label_namecustom.Location = new System.Drawing.Point(3, 31);
            this.label_namecustom.Name = "label_namecustom";
            this.label_namecustom.Size = new System.Drawing.Size(44, 16);
            this.label_namecustom.TabIndex = 4;
            this.label_namecustom.Text = "label2";
            // 
            // User_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_namecustom);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.label1_customerid);
            this.Controls.Add(this.guna2Button2);
            this.Name = "User_item";
            this.Size = new System.Drawing.Size(316, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label label1_customerid;
        private System.Windows.Forms.Label label_phone;
        private System.Windows.Forms.Label label_namecustom;
    }
}
