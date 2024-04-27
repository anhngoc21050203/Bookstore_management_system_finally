using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ZXing.Common;
using ZXing;
using Bookstore_management_system.Print;
using static System.Windows.Forms.Design.AxImporter;
using Bookstore_management_system.Image_processing;
using System.IO;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.Data.Objects.SqlClient;

namespace Bookstore_management_system.Product
{
    public partial class Product_Managerment : Form
    {
        private BookShopEntities3 context;
        public Product_Managerment()
        {

            InitializeComponent();
            context = new BookShopEntities3();
            dataGridViewProduct.CellDoubleClick += dataGridViewProduct_CellDoubleClick;
            guna2Panel1_form.Visible = false;
            dataGridViewProduct.Enabled = false;
            label9_tb.Text = "Danh sách sản phẩm";
        }

        private async void Product_Managerment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSet1.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.bookShopDataSet1.category);

            try
            {

                using (var context = new BookShopEntities3())
                {
                    var product = await Task.Run(() =>
                    {
                    return (from p in context.products
                            join cate in context.categories on p.categoryid equals cate.category_id
                            select new
                            {
                                p.productid,
                                p.barcode,
                                p.imgpath,
                                p.productname,
                                p.unitprice,
                                CategoryName = cate.category_name,
                                p.quantityinstock
                            }).ToList();
                               
                    });

                    dataGridViewProduct.Rows.Clear();



                    foreach (var item in product)
                    {
                        Image barcodePro = null;
                        Image imagePro = null;
                        if(item.barcode != null)
                        {
                            barcodePro = ImageProcessor.DecodeImageFromVarbinary(item.barcode);
                        }
                        if(item.imgpath != null)
                        {
                            imagePro = ImageProcessor.DecodeImageFromVarbinary(item.imgpath);
                        }
                        
                        dataGridViewProduct.Rows.Add(
                            item.productid,                      
                            barcodePro,
                            imagePro,
                            item.productname,
                            item.unitprice,
                            item.CategoryName,
                            item.quantityinstock
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadDataGirdViewProduct()
        {
            using (var context = new BookShopEntities3())
            {
                var product = await Task.Run(() =>
                {
                    return (from p in context.products
                            join cate in context.categories on p.categoryid equals cate.category_id
                            select new
                            {
                                p.productid,
                                p.barcode,
                                p.imgpath,
                                p.productname,
                                p.unitprice,
                                CategoryName = cate.category_name,
                                p.quantityinstock
                            }).ToList();

                });

                dataGridViewProduct.Rows.Clear();

                foreach (var item in product)
                {
                    Image barcodePro = null;
                    Image imagePro = null;
                    if (item.barcode != null)
                    {
                        barcodePro = ImageProcessor.DecodeImageFromVarbinary(item.barcode);
                    }
                    if (item.imgpath != null)
                    {
                        imagePro = ImageProcessor.DecodeImageFromVarbinary(item.imgpath);
                    }

                    dataGridViewProduct.Rows.Add(
                        item.productid,
                        barcodePro,
                        imagePro,
                        item.productname,
                        item.unitprice,
                        item.CategoryName,
                        item.quantityinstock
                        );
                }
            }
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewProduct.Rows[e.RowIndex];
                String idsp = row.Cells[0].Value?.ToString();
                if (idsp != null)
                {
                    int productId = int.Parse(idsp); // Chuyển đổi ID sản phẩm thành kiểu int

                    using (var context = new BookShopEntities3())
                    {
                        var product = (from p in context.products
                                       where p.productid == productId // Lọc sản phẩm theo ID
                                       select p).FirstOrDefault(); // Lấy sản phẩm đầu tiên hoặc null nếu không tìm thấy

                        int cateid = Convert.ToInt32(product.categoryid);


                        if (product != null)
                        {
                            // Sử dụng sản phẩm đã lấy được ở đây
                            // Ví dụ: Hiển thị thông tin sản phẩm trong các điều khiển trên giao diện
                            guna2TextBox1_msp.Text = product.productid.ToString();
                            txtNameBook_namesp.Text = product.productname.ToString();
                            guna2ComboBox1_cate.SelectedValue = cateid;
                            txtPriceBook_price.Text = product.unitprice.ToString();
                            txtDescriptionBook_desc.Text = product.description.ToString();
                            txtQuantityBook.Text = product.quantityinstock.ToString();
                            guna2TextBox2_nxb.Text = product.publishing_company.ToString();
                            guna2PictureBox2_barcode.Image = ImageProcessor.DecodeImageFromVarbinary(product.barcode);
                            if (row.Cells["imgpro"].Value is Image avatarPro)
                            {
                                // Gán ảnh từ ô "avatar" vào PictureBox
                                guna2PictureBox1.Image = avatarPro;
                            }
                        }
                        else
                        {
                            // Xử lý khi không tìm thấy sản phẩm
                        }
                    }
                }
            }
        }

        private void guna2Button1_barcode_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)guna2ComboBox1_cate.SelectedItem;
            int cateID = Convert.ToInt32(selectedRow["category_id"]);

            string msp = GenerateProductCode(cateID); ; // Lấy MSP từ TextBox

            // Tạo mã barcode dựa trên MSP
            Bitmap barcode = GenerateBarcode(msp, BarcodeFormat.CODE_128);

            // Hiển thị mã barcode trong PictureBox hoặc thực hiện các thao tác khác với nó
            guna2PictureBox2_barcode.Image = barcode;
        }
        private void guna2Button1_add_Click(object sender, EventArgs e)
        {
            label9_tb.Text = "Bạn đang ở chế độ thêm mới";
            guna2Panel1_form.Visible = true;
            guna2Button1_add.Enabled = false;
            guna2Button1_delete.Enabled = false;
            guna2Button_update.Enabled = false;
            dataGridViewProduct.Enabled = false;
            guna2Button1_barcode.Enabled = true;
        }

        private void guna2Button_update_Click(object sender, EventArgs e)
        {
            guna2Panel1_form.Visible = true;
            label9_tb.Text = "Bạn đang ở chế độ sửa";
            guna2Button1_add.Enabled = false;
            guna2Button_update.Enabled = false;
            dataGridViewProduct.Enabled = true;
            guna2Button1_barcode.Enabled = false;
        }
        private Bitmap GenerateBarcode(string content, BarcodeFormat format)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = format,
                Options = new EncodingOptions
                {
                    Height = guna2PictureBox2_barcode.Height,
                    Width = guna2PictureBox2_barcode.Width,
                    PureBarcode = false
                }
            };

            return barcodeWriter.Write(content);
        }

        private string DecodeBarcode(Bitmap barcodeImage)
        {
            var barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(barcodeImage);
            return result?.Text;
        }

        public string GenerateProductCode(int categoryId)
        {
            // Lấy năm hiện tại
            int currentYear = DateTime.Now.Year % 100;

            // Chuyển đổi mã thể loại thành chuỗi 2 ký tự
            string categoryCode = categoryId.ToString("D2");

            // Tạo mã thứ tự tự sinh ngẫu nhiên từ 1000 đến 9999
            Random random = new Random();
            int sequenceNumber = random.Next(1000, 10000);

            // Kết hợp các thành phần để tạo mã sản phẩm
            string productCode = $"{currentYear}{categoryCode}{sequenceNumber}";

            return productCode;
        }

        private void guna2Button1_upload_Click(object sender, EventArgs e)
        {
            byte[] imageData = ImageProcessor.UploadImage();
            if (imageData != null)
            {
                // Hiển thị ảnh trên PictureBox
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    guna2PictureBox1.Image = image;
                }
            }
        }

        private void guna2Button1_delete_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(guna2TextBox1_msp.Text))
    {
                // Kiểm tra xem giá trị có phải là số nguyên không
                if (int.TryParse(guna2TextBox1_msp.Text, out int productId))
                {
                    bool deleteProduct = DeleteProduct.DeleteProductById(productId);
                    if (deleteProduct)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadDataGirdViewProduct();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một giá trị số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID sản phẩm để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button_print_Click(object sender, EventArgs e)
        {
            OptionPrintProduct optionPrintProduct = new OptionPrintProduct();
            optionPrintProduct.ShowDialog();
        }

        private bool AddNewProduct()
        {
            try
            {
                Bitmap productIdBarCode = new Bitmap(guna2PictureBox2_barcode.Image);
                int productId = int.Parse(DecodeBarcode(productIdBarCode));


                string productName = txtNameBook_namesp.Text;
                DataRowView selectedRow = (DataRowView)guna2ComboBox1_cate.SelectedItem;
                int categoryId = Convert.ToInt32(selectedRow["category_id"]);
                byte[] barcode = ImageProcessor.EncodeImageToVarbinaryv2(guna2PictureBox2_barcode.Image);
                string description = txtDescriptionBook_desc.Text;
                byte[] imagePath = ImageProcessor.EncodeImageToVarbinary(guna2PictureBox1.Image);
                decimal unitPrice = decimal.Parse(txtPriceBook_price.Text);
                int quantityInStock = int.Parse(txtQuantityBook.Text);
                string publishingCompany = guna2TextBox2_nxb.Text;
                DateTime createdAt = DateTime.Now;
                string createdBy = "Admin";

                using (var context = new BookShopEntities3())
                {
                    // Tạo một đối tượng sản phẩm mới
                    product newProduct = new product
                    {
                        productid = productId,
                        productname = productName,
                        categoryid = categoryId,
                        barcode = barcode,
                        description = description,
                        imgpath = imagePath,
                        unitprice = unitPrice,
                        quantityinstock = quantityInStock,
                        publishing_company = publishingCompany,
                        created_at = createdAt,
                        created_by = createdBy
                    };

                    // Thêm sản phẩm mới vào cơ sở dữ liệu
                    context.products.Add(newProduct);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool UpdateProductDB()
        {
            try
            {
                int productId = int.Parse(guna2TextBox1_msp.Text);

                string productName = txtNameBook_namesp.Text;
                DataRowView selectedRow = (DataRowView)guna2ComboBox1_cate.SelectedItem;
                int categoryId = Convert.ToInt32(selectedRow["category_id"]);
                byte[] barcode = ImageProcessor.EncodeImageToVarbinaryv2(guna2PictureBox2_barcode.Image);
                string description = txtDescriptionBook_desc.Text;
                byte[] imagePath = ImageProcessor.EncodeImageToVarbinary(guna2PictureBox1.Image);
                decimal unitPrice = decimal.Parse(txtPriceBook_price.Text);
                int quantityInStock = int.Parse(txtQuantityBook.Text);
                string publishingCompany = guna2TextBox2_nxb.Text;
                DateTime updateAt = DateTime.Now;
                string updateBy = "Admin";

                UpdateProduct.UpdateProductInDatabase(productId, productName, categoryId, barcode, description, imagePath, unitPrice, quantityInStock, publishingCompany, updateAt, updateBy);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void guna2Button_save_Click(object sender, EventArgs e)
        {
            bool success = false;
            string message = "";

            string masp = guna2TextBox1_msp.Text;
            if (string.IsNullOrEmpty(masp))
            {
                success = AddNewProduct();
                message = success ? "Thêm sản phẩm mới thành công!" : "Thêm sản phẩm mới không thành công!";
            }
            else
            {
                success = UpdateProductDB();
                message = success ? "Cập nhật sản phẩm thành công!" : "Cập nhật sản phẩm không thành công!";
            }

            if (success)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormProduct();
                LoadDataGirdViewProduct();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_exit_Click(object sender, EventArgs e)
        {
            guna2Panel1_form.Visible = false;
            guna2Button1_add.Enabled = true;
            guna2Button1_delete.Enabled = true;
            guna2Button_update.Enabled = true;
            ResetFormProduct() ;
        }
        private void ResetFormProduct()
        {
            label9_tb.Text = "Danh sách sản phẩm";
            guna2TextBox1_msp.Text = null;
            txtNameBook_namesp.Text = string.Empty;
            txtDescriptionBook_desc.Text = string.Empty;
            txtPriceBook_price.Text = string.Empty;
            txtQuantityBook.Text = string.Empty;
            guna2TextBox2_nxb.Text = string.Empty;

            guna2ComboBox1_cate.SelectedIndex = 0;
            guna2PictureBox1.Image = null;
            guna2PictureBox2_barcode.Image = null;    
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                try
                {
                    using (var context = new BookShopEntities3())
                    {
                        // Thực hiện truy vấn để lọc dữ liệu từ cơ sở dữ liệu
                        var product = (from p in context.products
                                       join cate in context.categories on p.categoryid equals cate.category_id
                                       where SqlFunctions.StringConvert((decimal)p.productid).Contains(searchKeyword) || p.productname.Contains(searchKeyword) || cate.category_name.Contains(searchKeyword)
                                       select new
                                       {
                                           p.productid,
                                           p.barcode,
                                           p.imgpath,
                                           p.productname,
                                           p.unitprice,
                                           CategoryName = cate.category_name,
                                           p.quantityinstock
                                       }).ToList();

                        // Xóa dữ liệu hiện tại trong DataGridView
                        dataGridViewProduct.Rows.Clear();

                        // Thêm dữ liệu đã lọc vào DataGridView
                        foreach (var item in product)
                        {
                            Image barcodePro = null;
                            Image imagePro = null;
                            if (item.barcode != null)
                            {
                                barcodePro = ImageProcessor.DecodeImageFromVarbinary(item.barcode);
                            }
                            if (item.imgpath != null)
                            {
                                imagePro = ImageProcessor.DecodeImageFromVarbinary(item.imgpath);
                            }

                            dataGridViewProduct.Rows.Add(
                                item.productid,
                                barcodePro,
                                imagePro,
                                item.productname,
                                item.unitprice,
                                item.CategoryName,
                                item.quantityinstock
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, load lại toàn bộ dữ liệu
                LoadDataGirdViewProduct();
            }

        }
    }
}
