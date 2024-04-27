using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Payment
{
    public partial class PaymentScreen : Form
    {
        public PaymentScreen()
        {
            InitializeComponent();
            container(new Payment_Staff());
        }


        private void container(object _form)
        {
            if (guna2Panel2_payContainner.Controls.Count > 0) guna2Panel2_payContainner.Controls.Clear();

            Form form = _form as Form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            guna2Panel2_payContainner.Controls.Add(form);
            guna2Panel2_payContainner.Tag = form;
            form.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            container(new Payment_Staff());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void guna2Button2_his_Click(object sender, EventArgs e)
        {
            container(new History_payment_staff());
        }
    }
}
