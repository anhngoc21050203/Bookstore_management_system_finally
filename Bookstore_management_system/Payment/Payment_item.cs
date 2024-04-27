using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bookstore_management_system.Payment
{
    public partial class Payment_item : UserControl
    {
        // Thêm một delegator cho sự kiện xóa
        public delegate void DeleteButtonClickedEventHandler(object sender, EventArgs e);
        public event DeleteButtonClickedEventHandler DeleteButtonClicked;
        public event EventHandler QuantityChanged;


        public string maSP { get; private set; }
        public string tenSP { get; private set; }
        public decimal giaSP { get; private set; }
        public int soluongSP { get;  set; }
        public decimal tongtienSP { get; private set; }

        public Payment_item(string masp, string tensp, decimal giasp, int soluongsp, decimal tongtiensp)
        {
            InitializeComponent();
            maSP = masp;
            tenSP = tensp;
            giaSP = giasp;
            soluongSP = soluongsp;
            tongtienSP = tongtiensp;
            guna2TextBox1_msp.Text = maSP;
            guna2TextBox1_namesp.Text = tenSP;
            guna2TextBox1_price.Text =  giaSP.ToString();
            guna2NumericUpDown_number.Value = soluongSP;
            guna2TextBox_totalprice.Text = tongtienSP.ToString();
            guna2Button1_delete_item.Click += guna2Button1_delete_item_Click;
        }

        private void guna2Button1_delete_item_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void guna2NumericUpDown_number_ValueChanged(object sender, EventArgs e)
        {
            soluongSP = (int)guna2NumericUpDown_number.Value;
            tongtienSP = soluongSP * giaSP;
            guna2TextBox_totalprice.Text = tongtienSP.ToString();

            QuantityChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
