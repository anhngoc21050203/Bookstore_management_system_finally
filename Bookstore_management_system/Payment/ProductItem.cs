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
    public partial class ProductItem : UserControl
    {
        public event EventHandler TakeProductId;
        public int id {  get; set; }
        public string name { get; set; }
        public ProductItem(int pid, string pname)
        {
            InitializeComponent();
            id = pid;
            name = pname;
            guna2TextBox1_productid.Text = id.ToString();
            guna2TextBox1_nameproduct.Text = name.ToString();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            TakeProductId?.Invoke(this, EventArgs.Empty);
        }
    }
}
