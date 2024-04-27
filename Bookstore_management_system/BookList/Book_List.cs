using Bookstore_management_system.Image_processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bookstore_management_system.BookList.Book;
using Bookstore_management_system.BookShop_Map;

namespace Bookstore_management_system.BookList
{
    public partial class Book_List : Form
    {
        private const string connectionString = "Server=LAPTOP-EFN5URJM\\SQLEXPRESS;Database=BookShop;Integrated Security=True;";
        private bool panel3Visible = false;
        private string MapShelfName = "";
        private string selectedProductName = "";

        public Book_List()
        {
            InitializeComponent();
            panel3.Visible = false;
            AddBooksToFlowLayoutPanel();
        }

        private void Book_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSet1.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.bookShopDataSet1.category);
            // TODO: This line of code loads data into the 'bookShopDataSetProduct.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.bookShopDataSetProduct.product);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        #region Phần hiển thị sách
        private void AddBooksToFlowLayoutPanel()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT p.imgpath, p.productname, p.unitprice, p.quantityinstock, p.publishing_company, p.description " +
                                "FROM product p " +
                                "INNER JOIN category c ON p.categoryid = c.category_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] imgpath = (byte[])reader["imgpath"];
                            Image decodedImage = ImageProcessor.DecodeImageFromVarbinary(imgpath);

                            Book bookControl = new Book(
                                decodedImage,
                                reader["productname"].ToString(),
                                Convert.ToDecimal(reader["unitprice"]),
                                Convert.ToInt32(reader["quantityinstock"]),
                                reader["publishing_company"].ToString(),
                                reader["description"].ToString(),
                                panel3,
                                HidePanel3
                            );

                            bookControl.BookClick += (sender, e) =>
                            {
                                if (e is BookClickEventArgs bookClickEventArgs)
                                {
                                    selectedProductName = bookClickEventArgs.ProductName;
                                    // Cập nhật thông tin trên panel3 tùy thuộc vào quyển sách được nhấn
                                    ShowBookDetails(bookClickEventArgs.imageBook, bookClickEventArgs.ProductName, bookClickEventArgs.UnitPrice, bookClickEventArgs.QuantityInStock, bookClickEventArgs.PublishingCompany, bookClickEventArgs.Description);
                                }
                            };

                            flowLayoutPanel1.Controls.Add(bookControl);
                        }
                    }
                }
            }
        }

        private void Book_BookClick(object sender, EventArgs e)
        {
            if (e is BookClickEventArgs bookClickEventArgs)
            {
                string productName = bookClickEventArgs.ProductName;

                // Truy vấn để lấy productid và shelfid của quyển sách
                string query = "SELECT p.productid, sm.shelfid " +
                               "FROM product p " +
                               "INNER JOIN shelfmanage sm ON p.productid = sm.productid " +
                               "WHERE p.productname = @ProductName";

                int productId = -1;
                int shelfId = -1;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            productId = Convert.ToInt32(reader["productid"]);
                            shelfId = Convert.ToInt32(reader["shelfid"]);
                        }
                    }
                }

                if (productId != -1 && shelfId != -1)
                {
                    ShowMapInfo(productId, shelfId, productName);
                }
                else
                {
                    MessageBox.Show("Không có thông tin về vị trí của sách này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }





        #endregion


        #region Hiển thị thông tin sách
        private void ShowBookDetails(Image Image, string productName, decimal unitPrice, int quantityInStock, string publishingCompany, string description)
        {
            const int maxCharsPerLine = 20;
            const int maxLines = 3;

            string truncatedTitle = TruncateText(productName, maxCharsPerLine * maxLines);
            ptbBook1.Image = Image;

            lblTitle1.AutoSize = false;
            lblTitle1.Size = new Size(140, 66);
            lblTitle1.Text = truncatedTitle;

            lblPrice1.Text = unitPrice.ToString();
            lblPubCo.Text = publishingCompany;
            textBoxDescription.Text = description;
            panel3.Visible = true;
        }

        private string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (text.Length <= maxLength)
                return text;

            int breakIndex = text.LastIndexOf(' ', maxLength);
            if (breakIndex == -1)
                return text.Substring(0, maxLength) + "...";

            return text.Substring(0, breakIndex) + "\r\n" + TruncateText(text.Substring(breakIndex + 1), maxLength);
        }

        private void ShowMapInfo(int productId, int shelfId, string selectedProductName)
        {
            Map  mapForm = new Map(productId, shelfId, selectedProductName);
            mapForm.TopLevel = false;
            mapForm.FormBorderStyle = FormBorderStyle.None;
            mapForm.Dock = DockStyle.Fill;
            mapForm.Show();
        }

        #endregion

        #region Thanh điều khiển
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Book book)
                {
                    if (book.productname.ToLower().Contains(searchText) || book.publishingcompany.ToLower().Contains(searchText) || book.description.ToLower().Contains(searchText))
                    {
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }

        private void btnSortLatest_Click(object sender2, EventArgs e2)
        {
            string connectionString = "Server=LAPTOP-EFN5URJM\\SQLEXPRESS;Database=BookShop;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT p.imgpath, p.productname, p.unitprice, p.quantityinstock, p.publishing_company, p.description " +
                               "FROM product p " +
                               "INNER JOIN category c ON p.categoryid = c.category_id " +
                               "ORDER BY p.updated_at DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Xóa hết các sách hiện có trong flowLayoutPanel1 trước khi thêm lại theo thứ tự mới
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            byte[] imgpath = (byte[])reader["imgpath"];
                            Image decodedImage = ImageProcessor.DecodeImageFromVarbinary(imgpath);

                            Book bookControl = new Book(
                                decodedImage,
                                reader["productname"].ToString(),
                                Convert.ToDecimal(reader["unitprice"]),
                                Convert.ToInt32(reader["quantityinstock"]),
                                reader["publishing_company"].ToString(),
                                reader["description"].ToString(),
                                panel3,
                                HidePanel3
                            );

                            bookControl.BookClick += (sender3, e3) =>
                            {
                                if (e2 is BookClickEventArgs bookClickEventArgs)
                                {
                                    ShowBookDetails(bookClickEventArgs.imageBook, bookClickEventArgs.ProductName, bookClickEventArgs.UnitPrice, bookClickEventArgs.QuantityInStock, bookClickEventArgs.PublishingCompany, bookClickEventArgs.Description);
                                }
                            };

                            flowLayoutPanel1.Controls.Add(bookControl);
                        }
                    }
                }
            }
        }

        private void btnSortPrice_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-EFN5URJM\\SQLEXPRESS;Database=BookShop;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT p.imgpath, p.productname, p.unitprice, p.quantityinstock, p.publishing_company, p.description " +
                               "FROM product p " +
                               "INNER JOIN category c ON p.categoryid = c.category_id " +
                               "ORDER BY p.unitprice DESC"; //ASC nếu muốn tăng dần
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            byte[] imgpath = (byte[])reader["imgpath"];
                            Image decodedImage = ImageProcessor.DecodeImageFromVarbinary(imgpath);

                            Book bookControl = new Book(
                                decodedImage,
                                reader["productname"].ToString(),
                                Convert.ToDecimal(reader["unitprice"]),
                                Convert.ToInt32(reader["quantityinstock"]),
                                reader["publishing_company"].ToString(),
                                reader["description"].ToString(),
                                panel3,
                                HidePanel3
                            );

                            bookControl.BookClick += Book_BookClick;

                            flowLayoutPanel1.Controls.Add(bookControl);
                        }
                    }
                }
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBoxCategory.SelectedItem;
                string selectedCategory = selectedRow["category_id"].ToString();

                string connectionString = "Server=LAPTOP-EFN5URJM\\SQLEXPRESS;Database=BookShop;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT p.imgpath, p.productname, p.unitprice, p.quantityinstock, p.publishing_company, p.description " +
                                   "FROM product p " +
                                   "INNER JOIN category c ON p.categoryid = c.category_id " +
                                   "WHERE c.category_id = @CategoryID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", selectedCategory);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            flowLayoutPanel1.Controls.Clear();

                            while (reader.Read())
                            {
                                byte[] imgpath = (byte[])reader["imgpath"];
                                Image decodedImage = ImageProcessor.DecodeImageFromVarbinary(imgpath);

                                Book bookControl = new Book(
                                    decodedImage,
                                    reader["productname"].ToString(),
                                    Convert.ToDecimal(reader["unitprice"]),
                                    Convert.ToInt32(reader["quantityinstock"]),
                                    reader["publishing_company"].ToString(),
                                    reader["description"].ToString(),
                                    panel3,
                                    HidePanel3
                                );

                                bookControl.BookClick += Book_BookClick;

                                flowLayoutPanel1.Controls.Add(bookControl);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Các nút của Panel3
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        private void HidePanel3()
        {
            if (panel3Visible)
            {
                panel3.Visible = false;
                panel3Visible = false;
            }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedProductName))
            {
                // Truy vấn cơ sở dữ liệu để lấy thông tin về shelfId và productId dựa trên tên sách
                string query = "SELECT sm.shelfid, p.productid " +
                                "FROM shelfmanage sm " +
                                "JOIN product p ON sm.productid = p.productid " +
                                "WHERE p.productname = @ProductName";

                int productId = -1;
                int shelfId = -1;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", selectedProductName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                shelfId = Convert.ToInt32(reader["shelfid"]);
                                productId = Convert.ToInt32(reader["productid"]);
                            }
                        }
                    }
                }

                // Kiểm tra xem shelfId và productId có hợp lệ không
                if (productId != -1 && shelfId != -1)
                {
                    // Tạo và hiển thị cửa sổ Map
                    Map mapForm = new Map(productId, shelfId, selectedProductName);
                    mapForm.Show();
                }
                else
                {
                    MessageBox.Show("Không có thông tin về vị trí của sách này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sách để hiển thị vị trí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion


    }
}

