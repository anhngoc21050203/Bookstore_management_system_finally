using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.OrderProduct
{
    
    public partial class OrderSearch : UserControl
    {
        public event EventHandler OrderdetailsCick;
        public long order_id {  get; set; }

        public string staff_name {  get; set; }
        public OrderSearch(long orderid, string staffname)
        {
            InitializeComponent();
            this.order_id = orderid;
            this.staff_name = staffname;
            label_orderid.Text = order_id.ToString();
            label_staff.Text = staff_name;
        }

        private void guna2GradientButton1_ods_Click(object sender, EventArgs e)
        {
            OrderdetailsCick?.Invoke(this, EventArgs.Empty);
        }
    }
}
