using Bookstore_management_system.Image_processing;
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
    public partial class History_item : UserControl
    {
        public History_item(byte[] barcode, long nv_id, int kh_id, string gg_id, int number, decimal price_Total)
        {
            InitializeComponent();
            guna2PictureBox1.Image = ImageProcessor.DecodeImageFromVarbinary(barcode);
            mnv.Text = nv_id.ToString();
            mkh.Text = kh_id.ToString();
            mgg.Text = gg_id;
            num.Text = number.ToString();
            price.Text = price_Total.ToString();    
        }
    }
}
