using Bookstore_management_system.Image_processing;
using Bookstore_management_system.Print;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Product
{
    public partial class OptionPrintProduct : Form
    {
        public OptionPrintProduct()
        {
            InitializeComponent();
        }

        private void OptionPrintProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopDataSetProduct.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.bookShopDataSetProduct.product);
            guna2ShadowForm1.SetShadowForm(this);
            guna2DragControl1.TargetControl = this;
            guna2ComboBox1_pro.SelectedIndexChanged += guna2ComboBox1_pro_SelectedIndexChanged;
        

    }

        private void guna2Button1_nhap_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2ComboBox1_pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
