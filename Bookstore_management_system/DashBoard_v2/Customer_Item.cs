using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.DashBoard_v2
{
    public partial class Customer_Item : UserControl
    {
        public string fname {  get; set; }

        public string phone { get; set; }

        public decimal point { get; set; }

        public int count { get; set; }
        public Customer_Item(string fName, string phone, decimal point, int count)
        {
            InitializeComponent();
            this.fname = fName;
            this.phone = phone;
            this.point = point;
            this.count = count;
            guna2TextBox1.Text = fName;
            guna2TextBox2.Text = phone;
            guna2TextBox3.Text = point.ToString();
            guna2TextBox4.Text = count.ToString();

        }
    }
}
