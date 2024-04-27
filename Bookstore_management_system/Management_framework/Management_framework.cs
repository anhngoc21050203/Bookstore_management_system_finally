using System;
using System.Windows.Forms;
using Bookstore_management_system.DashBoard_v2;
using Bookstore_management_system.Category;
using Bookstore_management_system.User;
using Bookstore_management_system.Product;
using Bookstore_management_system.InputProduct;
using Bookstore_management_system.Outputproduct;
using Bookstore_management_system.Discount;
using Bookstore_management_system.Payment;
using Bookstore_management_system.OrderProduct;
using Bookstore_management_system.BookShelf;
using System.Linq;

namespace Bookstore_management_system.DashBoard
{
    public partial class Management_framework : Form
    {
        public Management_framework()
        {
            InitializeComponent();

            container(new Dashboard_v3());

        }

        private void Dashboarh_Load(object sender, EventArgs e)
        {
            guna2Button_cong.Visible = false;
            guna2Button_chitiet.Visible = false;

            guna2ShadowForm1.SetShadowForm(this);   
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            container(new Dashboard_v3());
        }

        private void container(object _form)
        {
            if(guna2Panel_container.Controls.Count > 0) guna2Panel_container.Controls.Clear();

            Form form = _form as Form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            guna2Panel_container.Controls.Add(form);
            guna2Panel_container.Tag = form;
            form.Show();

        }

        private void guna2Button_Category_Click(object sender, EventArgs e)
        {
            container(new Category_v2());
        }

        private void guna2Button_user_Click(object sender, EventArgs e)
        {
            container(new User_Management());
        }

        private void guna2Button_product_Click(object sender, EventArgs e)
        {
            container(new Product_Managerment());
        }

        private void guna2Button_import_Click(object sender, EventArgs e)
        {
            container(new Import_Product());  
        }

        private void guna2Button_export_Click(object sender, EventArgs e)
        {
            container(new Export_Product());
        }

        private void guna2Button_discount_Click(object sender, EventArgs e)
        {
            container(new Discount_Product());
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            PaymentScreen paymentScreen = new PaymentScreen();
            paymentScreen.WindowState = FormWindowState.Maximized;
            paymentScreen.Show();

            // Đóng màn hình hiện tại
            this.Close();
        }

        private void guna2Button_orders_Click(object sender, EventArgs e)
        {
            container(new Orders_Managerment());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            long loggedInStaffID = Properties.Settings.Default.LoggedInStaffID;
            using (var context = new BookShopEntities3())
            {
                // Tìm kiếm nhân viên dựa trên ID đã đăng nhập
                var loggedInStaff = context.staffs.FirstOrDefault(sa => sa.id == loggedInStaffID);

                if (loggedInStaff != null)
                {
                    // Cập nhật trạng thái active của nhân viên thành false
                    loggedInStaff.active = false;
                    context.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu

                    // Đặt lại ID của nhân viên đã đăng nhập và lưu lại cài đặt
                    Properties.Settings.Default.LoggedInStaffID = 0;
                    Properties.Settings.Default.Save();
                }
            }
            // Đóng form hiện tại
            this.Close();

        }

        private void guna2Button_book_shelf_Click(object sender, EventArgs e)
        {
            container(new BookShelf_List()); 
        }
    }
}
