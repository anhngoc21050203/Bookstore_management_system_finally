using Bookstore_management_system.BookShelf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Bookstore_management_system.BookShop_Map
{
    public partial class Map : Form
    {

        private int productId;
        private int shelfId;
        private string shelfName;
        private string selectedProductName;
        private const string connectionString = "Server=LAPTOP-EFN5URJM\\SQLEXPRESS;Database=BookShop;Integrated Security=True;";

        public Map(int productId, int shelfId, string selectedProductName)
        {
            InitializeComponent();
            this.productId = productId;
            this.shelfId = shelfId;
            this.selectedProductName = selectedProductName;
            HighlightShelves(SearchBooksInShelves());
            BookShelf_List bookShelfListForm = new BookShelf_List();
        }

        private List<int> SearchBooksInShelves()
        {
            List<int> shelvesWithBooks = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT sm.shelfid " +
                                "FROM shelfmanage sm " +
                                "WHERE sm.shelfid IS NOT NULL AND sm.productid IS NOT NULL"; // Chỉ lấy các hàng có cả shelfid và productid không rỗng

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int shelfId = Convert.ToInt32(reader["shelfid"]);
                            shelvesWithBooks.Add(shelfId);
                        }
                    }
                }
            }

            return shelvesWithBooks;
        }

        private void ResetShelfLabelsColor()
        {
            lblK1.ForeColor = Color.Black;
            lblK2.ForeColor = Color.Black;
            lblK3.ForeColor = Color.Black;
        }

        private void HighlightShelves(List<int> shelvesWithBooks)
        {
            ResetShelfLabelsColor();

            // Kiểm tra từng kệ sách trong danh sách shelvesWithBooks
            foreach (int shelfId in shelvesWithBooks)
            {
                // Truy vấn CSDL để kiểm tra xem sản phẩm được chọn có trong kệ này không
                bool productInShelf = CheckProductInShelf(shelfId);

                if (productInShelf)
                {
                    switch (shelfId)
                    {
                        case 1:
                            lblK1.ForeColor = Color.Red;
                            break;
                        case 2:
                            lblK2.ForeColor = Color.Red;
                            break;
                        case 3:
                            lblK3.ForeColor = Color.Red;
                            break;
                        case 4:
                            lblK4.ForeColor = Color.Red;
                            break;
                        case 5:
                            lblK5.ForeColor = Color.Red;
                            break;
                    }
                }
            }
        }

        private bool CheckProductInShelf(int shelfId)
        {
            bool productInShelf = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 1 sm.shelfid " +
                                "FROM shelfmanage sm " +
                                "WHERE sm.shelfid = @ShelfId AND sm.productid = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShelfId", shelfId);
                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Nếu có dữ liệu trả về từ truy vấn, sản phẩm được chọn nằm trong kệ
                        if (reader.Read())
                        {
                            productInShelf = true;
                        }
                    }
                }
            }

            return productInShelf;
        }


        private void BookShelfListForm_DataChanged(object sender, EventArgs e)
        {
            HighlightShelves(SearchBooksInShelves());
        }
    }
}