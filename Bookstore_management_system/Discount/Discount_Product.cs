using Bookstore_management_system.Image_processing;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.Discount
{
    public partial class Discount_Product : Form
    {
        private BookShopEntities3 context;
        private string disAA = "";

        public Discount_Product()
        {
            InitializeComponent();
            context = new BookShopEntities3();
            guna2Panel1_Dis.Visible = true;
            LoadDataGridViewDiscount();

        }

        private void Discount_Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetDiscount.discount_type' table. You can move, or remove it, as needed.
            this.discount_typeTableAdapter.Fill(this.dataSetDiscount.discount_type);

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow1 = (DataRowView)guna2ComboBox1.SelectedItem;

            if (selectedRow1 != null)
            {
                int dis_type_id = Convert.ToInt32(selectedRow1["discount_type_id"]);

                if (dis_type_id == 2)
                {
                    guna2TextBox_point.Visible = false;
                    disAA = "DE";
                    guna2DateTimePicker1_od.Visible = false;
                    label8.Visible = false;
                } else if (dis_type_id == 3)
                {
                    guna2TextBox_point.Visible = false;
                    disAA = "OD";
                    guna2DateTimePicker1_od.Visible = true;
                    label8.Visible = true;
                }
                else if (dis_type_id == 1)
                {
                    guna2TextBox_point.Visible = false;
                    disAA = "SL";
                    guna2DateTimePicker1_od.Visible = false;
                    label8.Visible = false;
                }
                else if (dis_type_id == 5) {
                    guna2TextBox_point.Visible = true;
                    disAA = "CL";
                    guna2DateTimePicker1_od.Visible = false;
                    label8.Visible = false;
                }
                else
                {
                    guna2TextBox_point.Visible = false;
                    guna2DateTimePicker1_od.Visible = false;
                    label8.Visible = false;
                }
                
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow1 = (DataRowView)guna2ComboBox1.SelectedItem;

            if (selectedRow1 != null)
            {
                
                int dis_type_id = Convert.ToInt32(selectedRow1["discount_type_id"]);
                DateTime sDate = pickerstart.Value;
                DateTime eDate = pickerend.Value;
                decimal discPT = decimal.Parse(TextBoxPhantramck.Text);
                decimal disc = (decimal)Math.Round(discPT / 100, 3);

                decimal min_count = 0;
                if (RadioNoGiatri.Checked)
                {
                    min_count = 0;
                    TextboxMucchi.Visible = false;
                }
                else
                {
                    min_count = decimal.Parse(TextboxMucchi.Text);
                }

                int app_C = int.Parse(txtNote.Text);
                string note_C = guna2TextBox1.Text;

                long discountID = GenerateCustomerID(dis_type_id);

                disAA += discountID.ToString();

                DateTime oD = guna2DateTimePicker1_od.Value;
                String point = guna2TextBox_point.Text;
                if(dis_type_id == 2)
                {
                    var addDiscount = new discount
                    {
                        discount_id = disAA,
                        apply_count = app_C,
                        min_amount = min_count,
                        start_date = sDate,
                        end_date = eDate,
                        note = note_C,
                        discount_amount = disc,
                        created_at = DateTime.Now,
                        created_by = Properties.Settings.Default.NameStaff,
                        discount_type_id = dis_type_id
                    };

                    context.discounts.Add(addDiscount);
                }
                else if(dis_type_id == 3)
                {
                    var addDiscount = new discount
                    {
                        discount_id = disAA,
                        apply_count = app_C,
                        min_amount = min_count,
                        start_date = sDate,
                        end_date = eDate,
                        note = note_C,
                        discount_amount = disc,
                        created_at = DateTime.Now,
                        created_by = Properties.Settings.Default.NameStaff,
                        discount_type_id = dis_type_id,
                        out_date = oD
                       
                    };

                    context.discounts.Add(addDiscount);
                }else if(dis_type_id == 5){

                    var addDiscount = new discount
                    {
                        discount_id = disAA,
                        apply_count = app_C,
                        min_amount = min_count,
                        start_date = sDate,
                        end_date = eDate,
                        note = note_C,
                        discount_amount = disc,
                        created_at = DateTime.Now,
                        created_by = Properties.Settings.Default.NameStaff,
                        discount_type_id = dis_type_id,
                        condition = point

                    };
                }
                else
                {
                    MessageBox.Show("Không thể thêm mới do loại giảm giá không được hỗ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                context.SaveChanges();
            }
            RefeshUI();
            LoadDataGridViewDiscount();
        }


        private void LoadDataGridViewDiscount()
        {
            pickerend.Value = DateTime.Now;
            var listDiscount = from d in context.discounts
                               join dt in context.discount_type on d.discount_type_id equals dt.discount_type_id
                               select new
                               {
                                   d.discount_id,
                                   dt.type_name,
                                   DiscountAmount = (d.discount_amount * 100),
                                   d.apply_count,
                                   d.min_amount,
                                   d.end_date
                               };
            guna2DataGridView1.Rows.Clear();

            foreach(var item  in listDiscount)
            {
                string dis = item.DiscountAmount.ToString() + "%";
                guna2DataGridView1.Rows.Add(
                    item.discount_id,
                    item.type_name,
                    dis,
                    item.apply_count,
                    item.min_amount,
                    item.end_date
                    );
            }

        }
        private void RefeshUI()
        {
            guna2ComboBox1.SelectedIndex = 0;
            RadioNoGiatri.Checked = true; // Chọn RadioButton mặc định
            TextboxMucchi.Visible = true; // Hiển thị TextBox
            TextboxMucchi.Text = ""; // Xóa nội dung của TextBox
            TextBoxPhantramck.Text = ""; // Xóa nội dung của TextBox khác
            txtNote.Text = ""; // Xóa nội dung của TextBox khác
            guna2TextBox1.Text = ""; // Xóa nội dung của TextBox khác
           
        }

        private long GenerateCustomerID(int dType)
        {
            // Lấy năm, tháng, ngày và giờ hiện tại
            int year = DateTime.Now.Year % 100; // Lấy số cuối cùng của năm
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            // Định dạng các thành phần để có được ID theo yêu cầu
            string customerId = "";

            // Sinh ba số ngẫu nhiên từ 0 đến 999
            Random random = new Random();

            long customerIdInt = 0;

            customerId = string.Format("{0:00}{1:00}{2:00}{3:00}", year, month, day, dType) + random.Next(1000).ToString("000");
            customerIdInt = long.Parse(customerId);
            

            return customerIdInt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RefeshUI();
        }
    }
}
