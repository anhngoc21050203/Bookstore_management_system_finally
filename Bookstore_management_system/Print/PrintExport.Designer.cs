namespace Bookstore_management_system.Print
{
    partial class PrintExport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bookShopDataSet2 = new Bookstore_management_system.BookShopDataSet2();
            this.bookShopDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSet2BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSetProduct = new Bookstore_management_system.BookShopDataSetProduct();
            this.bookShopDataSetProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.exportproductTableAdapter = new Bookstore_management_system.BookShopDataSet2TableAdapters.exportproductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet2BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetExport";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bookstore_management_system.Print.ReportExport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // bookShopDataSet2
            // 
            this.bookShopDataSet2.DataSetName = "BookShopDataSet2";
            this.bookShopDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookShopDataSet2BindingSource
            // 
            this.bookShopDataSet2BindingSource.DataSource = this.bookShopDataSet2;
            this.bookShopDataSet2BindingSource.Position = 0;
            // 
            // bookShopDataSet2BindingSource1
            // 
            this.bookShopDataSet2BindingSource1.DataSource = this.bookShopDataSet2;
            this.bookShopDataSet2BindingSource1.Position = 0;
            // 
            // bookShopDataSetProduct
            // 
            this.bookShopDataSetProduct.DataSetName = "BookShopDataSetProduct";
            this.bookShopDataSetProduct.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookShopDataSetProductBindingSource
            // 
            this.bookShopDataSetProductBindingSource.DataSource = this.bookShopDataSetProduct;
            this.bookShopDataSetProductBindingSource.Position = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "exportproduct";
            this.bindingSource1.DataSource = this.bookShopDataSet2BindingSource1;
            // 
            // exportproductTableAdapter
            // 
            this.exportproductTableAdapter.ClearBeforeFill = true;
            // 
            // PrintExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintExport";
            this.Text = "PrinExport";
            this.Load += new System.EventHandler(this.PrintExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet2BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bookShopDataSet2BindingSource;
        private BookShopDataSet2 bookShopDataSet2;
        private System.Windows.Forms.BindingSource bookShopDataSet2BindingSource1;
        private System.Windows.Forms.BindingSource bookShopDataSetProductBindingSource;
        private BookShopDataSetProduct bookShopDataSetProduct;
        private System.Windows.Forms.BindingSource bindingSource1;
        private BookShopDataSet2TableAdapters.exportproductTableAdapter exportproductTableAdapter;
    }
}