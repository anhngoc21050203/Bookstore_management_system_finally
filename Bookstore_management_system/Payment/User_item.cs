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
    public partial class User_item : UserControl
    {
        public event EventHandler TakeDiscountForUser;
        public int use_id { get; set; }
        public string name {  get; set; }
        public string userphone {  get; set; }
        public User_item(int useid, string fname, string phone)
        {
            InitializeComponent();
            this.use_id = useid;
            this.name = fname;
            this.userphone = phone;
            label1_customerid.Text = use_id.ToString();
            label_namecustom.Text = name.ToString();
            label_phone.Text = userphone.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TakeDiscountForUser?.Invoke(this, EventArgs.Empty);
        }
    }
}
