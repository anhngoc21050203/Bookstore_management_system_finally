using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Bookstore_management_system.Print
{
    public partial class PrintImport : Form
    {
        private int selectedImportId;
        private BindingSource importproductBindingSource;

        public PrintImport(int selectedImportId)
        {
            InitializeComponent();
            this.selectedImportId = selectedImportId;
            importproductBindingSource = new BindingSource();
        }

        private void PrintImport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSet3.importproduct' table. You can move, or remove it, as needed.
            this.importproductTableAdapter.Fill(this.bookShopDataSet3.importproduct);
            LoadReportData(selectedImportId);
            this.reportViewer1.RefreshReport();
        }

        private void LoadReportData(int selectedImportId)
        {
            using (var context = new BookShopEntities3())
            {
                var importData = (from i in context.importproducts
                                  join p in context.products on i.productid equals p.productid
                                  where i.importid == selectedImportId
                                  select new
                                  {
                                      i.importid,
                                      i.productid,
                                      i.importdate,
                                      i.quantity,
                                      i.importer,
                                      
                                  }).ToList();

                importproductBindingSource.DataSource = importData;
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetImport", importproductBindingSource));
            }
        }
    }
}
