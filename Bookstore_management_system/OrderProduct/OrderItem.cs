using Bookstore_management_system.Image_processing;
using System;
using System.Windows.Forms;

namespace Bookstore_management_system.OrderProduct
{
    public partial class OrderItem : UserControl
    {
        public event EventHandler OrderdetailsItemCick;
        public long order_id {  get; set; }
        public string staff_name { get; set; }
        public int quantity { get; set; }
        public decimal ttprice { get; set; }
        public string discountid { get; set; }
        public byte[] bar_code { get; set; }

        public DateTime timeD {  get; set; }
        public OrderItem(long orderId, string staffName, int quantityP, decimal ttPrice, string discountId, byte[] barcode, DateTime timeDate)
        {
            InitializeComponent();
            this.order_id = orderId;
            this.staff_name = staffName;
            this.quantity = quantityP;
            this.ttprice = ttPrice;
            this.discountid = discountId;
            this.bar_code = barcode;
            label_orderid.Text = orderId.ToString();
            label_staff.Text = staffName;
            label_quantity.Text = quantityP.ToString();
            label_ttprice.Text = ttPrice.ToString();
            label_disid.Text = discountId.ToString();
            if (barcode != null)
            {
                guna2PictureBox1.Image = ImageProcessor.DecodeImageFromVarbinary(barcode);
            }
            else
            {
                guna2PictureBox1.Image = null;
            }

            this.timeD = timeDate;
            label_date.Text = timeD.ToString("dd/MM/yyyy");
        }

        private void guna2GradientButton1_ods_Click(object sender, EventArgs e)
        {
            OrderdetailsItemCick?.Invoke(this, EventArgs.Empty);
        }
    }
}
