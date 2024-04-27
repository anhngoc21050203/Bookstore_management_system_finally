using System;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Bookstore_management_system.BookShelf
{
    public partial class BookShelf_List : Form
    {
        private BookShopEntities3 context;
        public BookShelf_List()
        {
            InitializeComponent();
            context = new BookShopEntities3();  
        }

        private void BookShelf_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSetProduct.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.bookShopDataSetProduct.product);
            // TODO: This line of code loads data into the 'bookShopDataSet4.bookshelf' table. You can move, or remove it, as needed.
            this.bookshelfTableAdapter.Fill(this.bookShopDataSet4.bookshelf);
          
            LoadAllBooks();

        }

        private void LoadAllBooks()
        {
            int totalShelf = 0;
            using (var context = new BookShopEntities3())
            {
                var query = from s in context.shelfmanages
                            join p in context.products on s.productid equals p.productid
                            join b in context.bookshelves on s.shelfid equals b.shelfid
                            select new
                            {
                                s.shelfmanageid,
                                p.productname,
                                s.quantityinshelf,
                                b.shelfname
                            };

                guna2DataGridView1.Rows.Clear();
                // Thêm dữ liệu vào từng dòng của DataGridView
                foreach (var item in query)
                {
                    guna2DataGridView1.Rows.Add(
                        item.shelfmanageid,
                        item.productname,
                        item.shelfname,
                        item.quantityinshelf
                    );

                    // Tính tổng số lượng sách trên các kệ
                    totalShelf += item.quantityinshelf ?? 0;
                }

                // Hiển thị tổng số lượng sách trên các kệ
                lblTotal.Text = totalShelf.ToString();
            }
        }

        #region Số lượng sách / Button top menu

        private void btnTotal_Click_1(object sender, EventArgs e)
        {
            LoadAllBooks();
            panel2.Visible = true;
        }
        #endregion


        #region Top menu công cụ
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                var search = from sh in context.shelfmanages
                             join s in context.bookshelves on sh.shelfid equals s.shelfid
                             join p in context.products on sh.productid equals p.productid
                             where s.shelfname.Contains(searchKeyword) || p.productname.Contains(searchKeyword)
                             select new
                             {
                                 sh.shelfmanageid,
                                 p.productname,
                                 sh.quantityinshelf,
                                 s.shelfname
                             };
                guna2DataGridView1.Rows.Clear();
                foreach (var item in search)
                {
                    guna2DataGridView1.Rows.Add(
                        item.shelfmanageid,
                        item.productname,
                        item.shelfname,
                        item.quantityinshelf
                    );
                }
            }
            else
            {
                LoadAllBooks();
            }
        }

        #endregion

        #region Thêm sửa xóa button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)comboBoxName.SelectedItem;
            int productId = Convert.ToInt32(selectedRow["productid"]);

            DataRowView selectedRow1 = (DataRowView)comboBoxPos.SelectedItem;
            int shelf_Id = Convert.ToInt32(selectedRow1["shelfid"]);

            int quantity = int.Parse(textBoxQuantity.Text);

            var checkQuantity = context.products.FirstOrDefault(p => p.productid == productId && p.quantityinstock > quantity);

            if(checkQuantity != null)
            {
                var newBookShelf = new shelfmanage
                {
                    productid = productId,
                    shelfid = shelf_Id,
                    quantityinshelf = quantity
                };

                // Thêm mới vào bookshelf
                context.shelfmanages.Add(newBookShelf);
                context.SaveChanges();
                MessageBox.Show("Sản phẩm đã được thêm vào bookshelf thành công.", "Thông báo");
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm không đủ trong kho. Vui lòng chọn một số lượng nhỏ hơn.", "Thông báo");
            }
            LoadAllBooks();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = 0;
                int shelfId = 0;
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                // Lấy giá trị từ hàng được chọn
                string productName = selectedRow.Cells["columnNameOfProductName"].Value.ToString();
                string shelfName = selectedRow.Cells["columnNameOfShelfName"].Value.ToString();
                int id = Convert.ToInt32(selectedRow.Cells["columnNameOfId"].Value);
                int quantity = Convert.ToInt32(selectedRow.Cells["columnNameOfQuantity"].Value);

                if (!string.IsNullOrEmpty(productName))
                {
                    var takeProductId = context.products.FirstOrDefault(p => p.productname == productName);

                    if (takeProductId != null)
                    {
                        productId = takeProductId.productid;
                    }
                }
                if(!string.IsNullOrEmpty(shelfName))
                {
                    var takeShelfId = context.bookshelves.FirstOrDefault(s =>  s.shelfname == shelfName);
                    if(takeShelfId != null)
                    {
                        shelfId = takeShelfId.shelfid;
                    }
                }

                comboBoxName.SelectedValue = productId;
                comboBoxPos.SelectedValue = shelfId;
                guna2TextBox1_id.Text = id.ToString();
                textBoxQuantity.Text = quantity.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)comboBoxName.SelectedItem;
            int productId = Convert.ToInt32(selectedRow["productid"]);

            DataRowView selectedRow1 = (DataRowView)comboBoxPos.SelectedItem;
            int shelf_Id = Convert.ToInt32(selectedRow1["shelfid"]);

            int quantity = int.Parse(textBoxQuantity.Text);

            int id = int.Parse(guna2TextBox1_id.Text);

            var checkQuantity = context.products.FirstOrDefault(p => p.productid == productId && p.quantityinstock > quantity);
            var updateShelf = context.shelfmanages.FirstOrDefault(sh => sh.shelfmanageid == id);

            if (checkQuantity != null)
            {
               if(updateShelf != null)
                {
                    updateShelf.productid = productId;
                    updateShelf.shelfid = shelf_Id;
                    updateShelf.quantityinshelf = quantity;
                }

                context.SaveChanges();
                MessageBox.Show("Sản phẩm đã được cập nhât vào bookshelf thành công.", "Thông báo");
            }
            else
            {
                MessageBox.Show("Số lượng sản phẩm không đủ trong kho. Vui lòng chọn một số lượng nhỏ hơn.", "Thông báo");
            }
            LoadAllBooks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(guna2TextBox1_id.Text);
            var updateShelf = context.shelfmanages.FirstOrDefault(sh => sh.shelfmanageid == id);
            if(updateShelf != null)
            {
                context.shelfmanages.Remove(updateShelf);
                context.SaveChanges();
                LoadAllBooks();
                MessageBox.Show("Sản phẩm đã được xóa khỏi bookshelf thành công.", "Thông báo");
            }
            
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalShelf = 0;
            DataRowView selectedRow1 = (DataRowView)comboBoxSelect.SelectedItem;

            if (selectedRow1 != null)
            {
                int shelf_Id = Convert.ToInt32(selectedRow1["shelfid"]);

                using (var context = new BookShopEntities3())
                {
                    var query = from s in context.shelfmanages
                                join p in context.products on s.productid equals p.productid
                                join b in context.bookshelves on s.shelfid equals b.shelfid
                                where s.shelfid == shelf_Id
                                select new
                                {
                                    s.shelfmanageid,
                                    p.productname,
                                    s.quantityinshelf,
                                    b.shelfname
                                };

                    guna2DataGridView1.Rows.Clear();
                    // Thêm dữ liệu vào từng dòng của DataGridView
                    foreach (var item in query)
                    {
                        guna2DataGridView1.Rows.Add(
                            item.shelfmanageid,
                            item.productname,
                            item.shelfname,
                            item.quantityinshelf
                        );

                        // Tính tổng số lượng sách trên các kệ
                        totalShelf += item.quantityinshelf ?? 0;
                    }

                }
                lblTotal.Text = totalShelf.ToString();
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ trong comboBox.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

#endregion