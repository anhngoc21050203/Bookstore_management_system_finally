using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bookstore_management_system.DashBoard;
using Bookstore_management_system.LoginProcessing;
using Bookstore_management_system.Payment;

namespace Bookstore_management_system
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {

            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            guna2TextBox_pword.PasswordChar = '*';
         
        }
        

        private void guna2Button1_Click(object sender, EventArgs e)
{
            string fname = guna2TextBox_username.Text;
            string pass = guna2TextBox_pword.Text;

            // Kiểm tra xem người dùng đã nhập đủ tên người dùng và mật khẩu chưa
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng và mật khẩu.");
                return;
            }
            /*Management_framework _mf = new Management_framework();
            _mf.Show();*/

            using (var context = new BookShopEntities3())
            {
                //Management_framework _mf = new Management_framework();
                //_mf.Show();
                // Truy vấn để kiểm tra xem tên người dùng có tồn tại không
                var staffs = context.staffs.Where(sa => sa.username.Equals(fname)).ToList();

                 if (staffs.Count > 0)
                 {
                     // Tên người dùng tồn tại, kiểm tra mật khẩu
                     foreach (var staff in staffs)
                     {
                         if (Login_processing.VerifyPassword(pass, staff.password))
                         {
                             /*if(staff.active == false)
                             {*/
                                if (staff.role_id == 1)
                                {
                                    staff.active = true;
                                     context.SaveChanges();

                                    // Lưu ID của nhân viên đã đăng nhập vào cài đặt
                                    Properties.Settings.Default.LoggedInStaffID = staff.id;
                                    Properties.Settings.Default.NameStaff = staff.username;
                                    

                                    // Lưu các thay đổi vào cài đặt
                                    Properties.Settings.Default.Save();

                                     MessageBox.Show("Đăng nhập thành công!");
                                     Management_framework _mf = new Management_framework();
                                     _mf.Show();
                                 }
                                 else if (staff.role_id == 2)
                                 {
                                     staff.active = true;
                                     context.SaveChanges();
                                     Properties.Settings.Default.LoggedInStaffID = staff.id;

                                     // Lưu các thay đổi vào cài đặt
                                     Properties.Settings.Default.Save();
                                     MessageBox.Show("Đăng nhập thành công!");
                                     PaymentScreen _ps = new PaymentScreen();
                                     _ps.WindowState = FormWindowState.Maximized;
                                     _ps.Show();
                                 }
                                 /*guna2TextBox_pword.Text = "";
                                 guna2TextBox_username.Text = "";*/
                                 return; // Thoát sau khi đã đăng nhập thành công

                             /*}
                             else
                             {
                                 MessageBox.Show("Tài khoản của bạn đã đăng nhập ở nơi khác!");
                             }*/


                     }
                     else
                     {
                        MessageBox.Show("Sai mật khẩu!");
                     }
                 }
                }
                else
                {
                    // Tên người dùng không tồn tại
                    MessageBox.Show("Tên người dùng không tồn tại.");
                }
            }
        }

    }
}
