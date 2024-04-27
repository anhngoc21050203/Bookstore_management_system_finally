using Bookstore_management_system.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.InputProduct
{
    public partial class Import_Product : Form
    {
        private BookShopEntities3 context;
        public Import_Product()
        {
            context = new BookShopEntities3();
            InitializeComponent();
            dataGridViewNhapSP.CellDoubleClick += dataGridViewNhapSP_CellDoubleClick;
            dtpDateNhapSP.Value = DateTime.Now;
            txtNguoiNhapSP.Text = Properties.Settings.Default.NameStaff;
        }

       

        private async void Import_Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSetProduct.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.bookShopDataSetProduct.product);

            txtMaNhapSP.Enabled = false;
            txtNguoiNhapSP.Enabled = false;
            
            try
            {
                // Lấy ID của nhân viên đăng nhập từ cài đặt
               

                using (var context = new BookShopEntities3())
                {


                    var importt = await Task.Run(() =>
                    {
                        return (from i in context.importproducts
                                join p in context.products on i.productid equals p.productid
                                /*join s in context.staffs on i.importer equals s.username
                                where i.importer = s.username*/
                                select new
                                {
                                    i.importid,
                                    i.importdate,
                                    ProductName = p.productname,
                                    i.quantity,
                                    i.importer,
                                }).ToList();

                    });
                    dataGridViewNhapSP.Rows.Clear();

                    foreach (var item in importt)
                    {
                        dataGridViewNhapSP.Rows.Add(
                            item.importid,
                            item.ProductName,
                            item.importdate,
                            item.quantity,
                            item.importer
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi");
            }

        }

        private void dataGridViewNhapSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewNhapSP.Rows[e.RowIndex];

                String importID = row.Cells["importid"].Value.ToString();
                String productID = row.Cells["productid"].Value.ToString();
                String dateImport = row.Cells["importdate"].Value.ToString();
                String quantity = row.Cells["quantity"].Value.ToString();
                String importer = row.Cells["importer"].Value.ToString();

                txtMaNhapSP.Text = importID;
                cbMaSanPham.Text = productID;
                dtpDateNhapSP.Value = DateTime.Parse(dateImport);
                txtSoLuongNhapSP.Text = quantity;
                txtNguoiNhapSP.Text = importer;
            }
        }

        private void LoadDtp()
        {
            using (var context = new BookShopEntities3())
            {

                var import = (from i in context.importproducts
                              join p in context.products on i.productid equals p.productid

                              select new
                              {
                                  i.importid,
                                  ProductName = p.productname,
                                  i.importdate,
                                  i.quantity,
                                  i.importer,
                              }).ToList();
                dataGridViewNhapSP.Rows.Clear();

                foreach (var item in import)
                {
                    dataGridViewNhapSP.Rows.Add(
                        item.importid,
                        item.ProductName,
                        item.importdate,
                        item.quantity,
                        item.importer
                    ); ;
                }
            }
        }

        private void ResetTextBoxes()
        {
            txtMaNhapSP.Text = null;
            cbMaSanPham.SelectedIndex = 0;
            dtpDateNhapSP.Value = DateTime.Now;
            txtSoLuongNhapSP.Text = null;
            /*txtNguoiNhapSP.Text = null;*/


        }

        private string RandomImportId()
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
                    product.quantityinstock += quantity;
                    context.SaveChanges();
                }
            }
        }

        private void AddNewImport()
        {
            DataRowView selectRow = (DataRowView)cbMaSanPham.SelectedItem;
            int productID = Convert.ToInt32(selectRow["productid"]);
            DateTime importDate = DateTime.Now;

            // Kiểm tra xem người dùng đã nhập một giá trị hợp lệ vào ô nhập liệu số lượng sản phẩm chưa
            if (!int.TryParse(txtSoLuongNhapSP.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Vui lòng nhập một số lượng sản phẩm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string importer = txtNguoiNhapSP.Text;
            string source = "";
            int importid = int.Parse(RandomImportId());
            var newImport = createImport.CreateObjectImport(importid, productID, importDate, quantity, importer, source);

            AddImportToDatabase(newImport);

            //Cap Nhat so luong ton kho
            UpdateProductStock(productID, quantity);
        }


        //
        private void AddImportToDatabase(importproduct newImport)
        {
            using (var context = new BookShopEntities3())
            {
                context.importproducts.Add(newImport);
                context.SaveChanges();
            }
        }

        private void btnThemNhapSP_Click(object sender, EventArgs e)
        {
            string updateid = txtMaNhapSP.Text;
            if (string.IsNullOrEmpty(updateid))
            {
                AddNewImport();
                ResetTextBoxes();
            }
            else
            {
                UpdateImportt();
            }
            LoadDtp();
        }

        private void UpdateProductStockEdit(int productId, int oldQuantity, int newQuantity)
        {
            using (var context = new BookShopEntities3())
            {
                var product = context.products.FirstOrDefault(p => p.productid == productId);
                if (product != null)
                {
                    int quantityChange = newQuantity - oldQuantity;
                    product.quantityinstock += quantityChange;
                    context.SaveChanges();
                }
            }
        }

        private void UpdateImportt()
        {

            int importid = int.Parse(txtMaNhapSP.Text);
            DataRowView selectRow = (DataRowView)cbMaSanPham.SelectedItem;
            int productid = Convert.ToInt32(selectRow["productid"]);

            // Kiểm tra xem người dùng đã nhập một giá trị hợp lệ vào ô nhập liệu số lượng sản phẩm chưa
            if (!int.TryParse(txtSoLuongNhapSP.Text, out int newQuantity) || newQuantity <= 0)
            {
                MessageBox.Show("Vui lòng nhập một số lượng sản phẩm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime importdate = DateTime.Now;
            string importer = txtNguoiNhapSP.Text;
            string source = "";

            // Lấy thông tin cũ của sản phẩm nhập
            using (var context = new BookShopEntities3())
            {
                var oldImport = context.importproducts.FirstOrDefault(i => i.importid == importid);
                if (oldImport != null)
                {
                    int oldQuantity = (int)oldImport.quantity;

                    // Cập nhật thông tin mới của sản phẩm nhập
                    UpdateImport.UpdateImportInDatabase(importid, productid, importdate, newQuantity, importer, source);

                    // Cập nhật số lượng tồn kho khi chỉnh sửa
                    UpdateProductStockEdit(productid, oldQuantity, newQuantity);
                }
            }
        }

        private void btnSuaNhapSP_Click(object sender, EventArgs e)
        {
            string updateImportid = txtMaNhapSP.Text;
            if (string.IsNullOrEmpty(updateImportid))
            {
                AddNewImport();
                ResetTextBoxes();

            }
            else { UpdateImportt(); }
            LoadDtp();
        }

        private void btnXoaNhapSP_Click(object sender, EventArgs e)
        {
            int importId = int.Parse(txtMaNhapSP.Text);
            bool del = DeleteImport.DeleteImportProductById(importId);
            if (del)
            {
                MessageBox.Show("Del thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
            LoadDtp();
            ResetTextBoxes() ;
        }


        private void btnPrintImport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNhapSP.Text) && int.TryParse(txtMaNhapSP.Text, out int selectedImportId))
            {
                PrintImport prImport = new PrintImport(selectedImportId);
                prImport.ShowDialog();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một mã xuất sản phẩm hợp lệ.");
            }
        }

        private void txtSearchNhapSP_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchNhapSP.Text.Trim();

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                int importId;
                if (!int.TryParse(searchKeyword, out importId))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên để tìm kiếm theo mã ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var context = new BookShopEntities3())
                {
                    var import = (from i in context.importproducts
                                  join p in context.products on i.productid equals p.productid
                                  where i.importid == importId
                                  select new
                                  {
                                      i.importid,
                                      ProductName = p.productname,
                                      i.importdate,
                                      i.quantity,
                                      i.importer,
                                  }).ToList();

                    dataGridViewNhapSP.Rows.Clear();

                    foreach (var item in import)
                    {
                        dataGridViewNhapSP.Rows.Add(
                            item.importid,
                            item.ProductName,
                            item.importdate,
                            item.quantity,
                            item.importer
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
