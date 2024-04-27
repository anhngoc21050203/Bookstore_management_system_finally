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
    public partial class Discount_item : UserControl
    {
        public event EventHandler ApplyDiscountForUser;
        public string id { get; set; }
        public string note { get; set; }

        public Discount_item(string dId, string ghiChu)
        {
            InitializeComponent();
            id = dId;
            note = ghiChu;
            label_discountid.Text = id;
            label2_note.Text = note;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ApplyDiscountForUser?.Invoke(this, EventArgs.Empty);
        }
    }
}
