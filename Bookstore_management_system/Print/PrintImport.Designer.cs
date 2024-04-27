namespace Bookstore_management_system.Print
{
    partial class PrintImport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bookShopDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSet3 = new Bookstore_management_system.BookShopDataSet3();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.importproductTableAdapter = new Bookstore_management_system.BookShopDataSet3TableAdapters.importproductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bookShopDataSet3BindingSource
            // 
            this.bookShopDataSet3BindingSource.DataSource = this.bookShopDataSet3;
            this.bookShopDataSet3BindingSource.Position = 0;
            // 
            // bookShopDataSet3
            // 
            this.bookShopDataSet3.DataSetName = "BookShopDataSet3";
            this.bookShopDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetImport";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Bookstore_management_system.Print.ReportImport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(770, 409);
            this.reportViewer2.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "importproduct";
            this.bindingSource1.DataSource = this.bookShopDataSet3BindingSource;
            // 
            // importproductTableAdapter
            // 
            this.importproductTableAdapter.ClearBeforeFill = true;
            // 
            // PrintImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 409);
            this.Controls.Add(this.reportViewer2);
            this.Name = "PrintImport";
            this.Text = "PrintImport";
            this.Load += new System.EventHandler(this.PrintImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource bookShopDataSet3BindingSource;
        private BookShopDataSet3 bookShopDataSet3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private BookShopDataSet3TableAdapters.importproductTableAdapter importproductTableAdapter;
    }
}