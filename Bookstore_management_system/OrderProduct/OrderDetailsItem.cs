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
    public partial class OrderDetailsItem : UserControl
    {
        public string namP {  get; set; }
        public decimal upP { get; set; }
        public int qP { get; set; }
        public decimal ttP { get; set; }
        public OrderDetailsItem(string nameProduct, decimal uintpP, int quanP, decimal totP)
        {
            InitializeComponent();
            this.namP = nameProduct;
            this.upP = uintpP;
            this.qP = quanP;
            this.ttP = totP;
            label2_proname.Text = namP;
            label2_uprice.Text = upP.ToString();
            labelquantity.Text = qP.ToString();
            label_price.Text = ttP.ToString();
        }
    }
}
