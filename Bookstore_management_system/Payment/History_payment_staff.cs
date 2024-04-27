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
    public partial class History_payment_staff : Form
    {
        private long id;
        public History_payment_staff()
        {
            InitializeComponent();
            id = Properties.Settings.Default.LoggedInStaffID;
        }

        private void History_payment_staff_Load(object sender, EventArgs e)
        {
            DateTime dayNow = DateTime.Now.Date;
            using (var context = new BookShopEntities3())
            {
                var listOrderByStaff = from ord in context.orderps
                                       where ord.staffid == id && ord.orderdate == dayNow
                                       select ord;

                int totalOrders = listOrderByStaff.Count();
                decimal totalPayment = listOrderByStaff.Sum(or => or.totalamount) ?? 0;
                int totalPro = listOrderByStaff.Sum(or => or.number) ?? 0;


                foreach (var ord in listOrderByStaff)
                {
                    History_item history_Item = new History_item(ord.barcode, ord.staffid, ord.paycustomerid, ord.discountused, (int)ord.number, (decimal)ord.totalamount);
                    flowLayoutPanel1.Controls.Add(history_Item);
                }

                guna2TextBox1_totalod.Text = totalOrders.ToString();
                guna2TextBox2_totalnum.Text = totalPro.ToString();
                guna2TextBox3_totalpri.Text = totalPayment.ToString();

            }
        }
    }
}
