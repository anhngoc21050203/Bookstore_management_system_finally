    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Bookstore_management_system.Category
    {
        public partial class Category_v2 : Form
        {
            private BookShopEntities3 context;
            private Random random = new Random();

        public Category_v2()
        {
                InitializeComponent();
                context = new BookShopEntities3();
                dataGridViewCategory.CellDoubleClick += dataGridViewCategory_CellDoubleClick;
                txtCategoryid.Enabled = false;
        }

            private async void Category_v2_Load_1(object sender, EventArgs e)
            {
                try
                {
                    using (var context = new BookShopEntities3())
                    {
                        var category = await Task.Run(() =>
                        {
                            return (from ct in context.categories

                                    select new
                                    {
                                        ct.category_id,
                                        ct.category_name,

                                    }).ToList();

                        });
                        dataGridViewCategory.Rows.Clear();

                        foreach (var item in category)
                        {
                            dataGridViewCategory.Rows.Add(
                                item.category_id,
                                item.category_name

                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }

            }

        private string RandomCategoryId()
        {
            Random random = new Random();
            String randomnumber = random.Next(1, 1000).ToString();



            return randomnumber;

        }


        private void dataGridViewCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewCategory.Rows[e.RowIndex];

                    string categoryID = row.Cells["category_id"].Value.ToString();
                    string categoryName = row.Cells["category_name"].Value.ToString();


                    txtCategoryid.Text = categoryID;
                    txtCategoryName.Text = categoryName;

                }

            }

            private void LoadDtp()
            {
                using (var context = new BookShopEntities3())
                {
                    var category = (from ct in context.categories

                                    select new
                                    {
                                        ct.category_id,
                                        ct.category_name
                                    }).ToList();
                    dataGridViewCategory.Rows.Clear();

                    foreach (var item in category)
                    {
                        dataGridViewCategory.Rows.Add(
                            item.category_id,
                            item.category_name

                        ); ;
                    }
                }
            }

            private void ResetTextBoxes()
            {
                txtCategoryid.Text = null;
                txtCategoryName.Text = null;

            }
        private void AddCategoryToDatabase(category newCategory)
        {
            using (var context = new BookShopEntities3())
            {
                context.categories.Add(newCategory);
                context.SaveChanges();
            }
        }


        private void AddNewCategory()
        {
            int categoryid = int.Parse(RandomCategoryId());
            string categoryName = txtCategoryName.Text;


            var newCategory =  createCategory.CreateObjectCategoryt(categoryid, categoryName);

            AddCategoryToDatabase(newCategory);
        }


        private void UpdateCategory()
        {

            int categoryid = int.Parse(txtCategoryid.Text);
            string categoryName = txtCategoryName.Text;


            updateCategory.UpdateCategoryInDatabase(categoryid, categoryName);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
        string updateid = txtCategoryid.Text;
        if (string.IsNullOrEmpty(updateid))
        {
            AddNewCategory();
            ResetTextBoxes();
        }
        else
        {
            UpdateCategory();
        }
        LoadDtp();
        ResetTextBoxes();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string updateid = txtCategoryid.Text;
            if (string.IsNullOrEmpty(updateid))
            {
                AddNewCategory();
                ResetTextBoxes();
            }
            else
            {
                UpdateCategory();
            }
            LoadDtp();
            ResetTextBoxes();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int categoryid = int.Parse(txtCategoryid.Text);
            bool del = deleteCategory.DeleteCategoryById(categoryid);
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
        }
    }
}
