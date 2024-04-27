using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Print
{
    public partial class PrintExport : Form
    {
        private int selectedExportId;
        private BindingSource exportproductBindingSource;

        // Thêm constructor nhận mã xuất sản phẩm
        public PrintExport(int selectedExportId)
        {
            InitializeComponent();
            this.selectedExportId = selectedExportId;
            exportproductBindingSource = new BindingSource();
        }

        private void PrintExport_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'bookShopDataSet2.exportproduct' table. You can move, or remove it, as needed.
            this.exportproductTableAdapter.Fill(this.bookShopDataSet2.exportproduct);
            
            LoadReportData(this.selectedExportId);
            this.reportViewer1.RefreshReport();
        }

        private void LoadReportData(int selectedExportId)
        {
            using (var context = new BookShopEntities3())
            {
                var exportData = (from ep in context.exportproducts
                                  join p in context.products on ep.productid equals p.productid
                                  where ep.exportid == selectedExportId
                                  select new
                                  {
                                      ep.exportid,
                                      ep.exportdate,
                                      ep.productid,
                                      ep.quantity,
                                      ep.exporter,
                                  }).ToList();

                exportproductBindingSource.DataSource = exportData;
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetExport", exportproductBindingSource));
            }
        }
    }
}
