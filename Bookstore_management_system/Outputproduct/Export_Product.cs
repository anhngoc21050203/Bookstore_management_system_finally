using Bookstore_management_system.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Outputproduct
{
    public partial class Export_Product : Form
    {
        private BookShopEntities3 context;
        public Export_Product()
        {
            InitializeComponent();
            context = new BookShopEntities3();
            dataGridViewXuatSP.CellDoubleClick += dataGridViewXuatSP_CellDoubleClick;
            txtNguoiXuatSP.Text = Properties.Settings.Default.NameStaff;
        }

        private void dataGridViewXuatSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewXuatSP.Rows[e.RowIndex];

                String exportID = row.Cells["exportid"].Value.ToString();
                String productID = row.Cells["productid"].Value.ToString();
                String dateExport = row.Cells["exportdate"].Value.ToString();
                String quantity = row.Cells["quantity"].Value.ToString();
                String exporter = row.Cells["exporter"].Value.ToString();

                txtMaXuatSP.Text = exportID;
                cbMaSanPham.Text = productID;
                dtpDateXuatSP.Value = DateTime.Parse(dateExport);
                txtSoLuongXuatSP.Text = quantity;
                txtNguoiXuatSP.Text = exporter;
            }
        }

        private async void Export_Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSetProduct.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.bookShopDataSetProduct.product);
            // TODO: This line of code loads data into the 'bookShopDataSetProduct.product' table. You can move, or remove it, as needed.

            txtMaXuatSP.Enabled = false;
            txtNguoiXuatSP.Enabled = false;
            try
            {
                // Lấy ID của nhân viên đăng nhập từ cài đặt
                int loggedInStaffID = (int)Properties.Settings.Default.LoggedInStaffID;
                // Lấy thông tin của nhân viên từ cơ sở dữ liệu bằng ID
                var staff = context.staffs.FirstOrDefault(s => s.id == loggedInStaffID);

                // Kiểm tra nếu nhân viên tồn tại
                if (staff != null)
                {
                    // Gán tên nhân viên vào txtNguoiNhapSP
                    txtNguoiXuatSP.Text = staff.username;
                }
                else
                {
                    // Hiển thị thông báo nếu không tìm thấy thông tin của nhân viên
                    MessageBox.Show("Không tìm thấy thông tin của nhân viên đăng nhập.");
                }
                using (var context = new BookShopEntities3())
                {
                    var importt = await Task.Run(() =>
                    {
                        return (from ep in context.exportproducts
                                join p in context.products on ep.productid equals p.productid
                                select new
                                {
                                    ep.exportid,
                                    ep.exportdate,
                                    ProductName = p.productname,
                                    ep.quantity,
                                    ep.exporter,
                                }).ToList();

                    });
                    dataGridViewXuatSP.Rows.Clear();

                    foreach (var item in importt)
                    {
                        dataGridViewXuatSP.Rows.Add(
                            item.exportid,
                            item.ProductName,
                            item.exportdate,
                            item.quantity,
                            item.exporter
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadDtp()
        {
            using (var context = new BookShopEntities3())
            {
                var import = (from ep in context.exportproducts
                              join p in context.products on ep.productid equals p.productid

                              select new
                              {
                                  ep.exportid,
                                  ProductName = p.productname,
                                  ep.exportdate,
                                  ep.quantity,
                                  ep.exporter,
                              }).ToList();
                dataGridViewXuatSP.Rows.Clear();

                foreach (var item in import)
                {
                    dataGridViewXuatSP.Rows.Add(
                        item.exportid,
                        item.ProductName,
                        item.exportdate,
                        item.quantity,
                        item.exporter
                    ); ;
                }
            }
        }

        private void ResetTextBoxes()
        {
            txtMaXuatSP.Text = null;
            cbMaSanPham.SelectedIndex = 0;
            dtpDateXuatSP.Value = DateTime.Now;
            txtSoLuongXuatSP.Text = null;
            /* txtNguoiXuatSP.Text = null;*/


        }

        private string RandomExportId()
        {
            Random random = new Random();
            String randomnumber = random.Next(1, 1000).ToString();

            return randomnumber;

        }

        private void UpdateProductStock(int productId, int quantity)
        {
            using (var context = new BookShopEntities3())
            {
                var product = context.products.FirstOrDefault(p => p.productid == productId);
                if (product != null)
                {
                    product.quantityinstock -= quantity;
                    context.SaveChanges();
                }
            }
        }

        private void AddExportToDatabase(exportproduct newImport)
        {
            using (var context = new BookShopEntities3())
            {
                context.exportproducts.Add(newImport);
                context.SaveChanges();
            }
        }

        private void AddNewExport()
        {
            DataRowView selectRow = (DataRowView)cbMaSanPham.SelectedItem;
            int productID = Convert.ToInt32(selectRow["productid"]);
            DateTime exportDate = DateTime.Now;
            int quantity = int.Parse(txtSoLuongXuatSP.Text);
            string exporter = txtNguoiXuatSP.Text;
            string destination = "";
            int exportid = int.Parse(RandomExportId());
            var newExport = CreateExport.CreateObjectExport(exportid, productID, exportDate, quantity, exporter, destination);

            // Kiểm tra số lượng sản phẩm muốn xuất có lớn hơn số lượng hiện có trong kho không
            var product = context.products.FirstOrDefault(p => p.productid == productID);
            if (product != null)
            {
                if (quantity > product.quantityinstock)
                {
                    MessageBox.Show("Số lượng sản phẩm muốn xuất lớn hơn số lượng hiện có trong kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            AddExportToDatabase(newExport);

            //Cap Nhat so luong ton kho
            UpdateProductStock(productID, quantity);
        }


        private void btnThemXuatSP_Click(object sender, EventArgs e)
        {
            string updateid = txtMaXuatSP.Text;
            if (string.IsNullOrEmpty(updateid))
            {
                AddNewExport();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Error");
            }
            LoadDtp();
        }

        /*private void btnXoaXuatSP_Click(object sender, EventArgs e)
        {
            int exportID = int.Parse(txtMaXuatSP.Text);
            bool del = DeleteExport.DeleteExportProductById(exportID);
            if (del)
            {
                MessageBox.Show("Del thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
            LoadDtp();
            ResetTextBoxes();
        }*/

        private void btnPrintExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaXuatSP.Text) && int.TryParse(txtMaXuatSP.Text, out int selectedExportId))
            {
                PrintExport printExport = new PrintExport(selectedExportId);
                printExport.ShowDialog();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một mã xuất sản phẩm hợp lệ.");
            }
        }


        private void txtSearchXuatSP_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchXuatSP.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                using (var context = new BookShopEntities3())
                {
                    var import = (from ep in context.exportproducts
                                  join p in context.products on ep.productid equals p.productid
                                  where SqlFunctions.StringConvert((double)ep.exportid).Contains(searchKeyword)
                                  select new
                                  {
                                      ep.exportid,
                                      ProductName = p.productname,
                                      ep.exportdate,
                                      ep.quantity,
                                      ep.exporter,
                                  }).ToList();

                    dataGridViewXuatSP.Rows.Clear();

                    foreach (var item in import)
                    {
                        dataGridViewXuatSP.Rows.Add(
                            item.exportid,
                            item.ProductName,
                            item.exportdate,
                            item.quantity,
                            item.exporter
                        );
                    }
                }
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, load lại toàn bộ dữ liệu
                LoadDtp();
            }
        }

    }
}
