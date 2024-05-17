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

/*        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }*/


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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                string discountID = row.Cells["Column1"].Value?.ToString();
                if (!string.IsNullOrEmpty(discountID))
                {
                    var discount = (from d in context.discounts
                                    where d.discount_id == discountID // Lọc mã giảm giá theo ID
                                    select d).FirstOrDefault(); // Lấy mã giảm giá đầu tiên hoặc null nếu không tìm thấy

                    if (discount != null)
                    {
                        // Hiển thị thông tin mã giảm giá trong các điều khiển trên giao diện
                        guna2ComboBox1.Text = discount.discount_type.type_name;
                        TextBoxPhantramck.Text = (discount.discount_amount * 100).ToString();
                        txtNote.Text = discount.apply_count.ToString();
                        TextboxMucchi.Text = discount.min_amount.ToString();
                        pickerstart.Value = discount.start_date ?? DateTime.Now;
                        pickerend.Value = discount.end_date ?? DateTime.Now;

                        if (discount.discount_type_id == 3)
                        {
                            guna2DateTimePicker1_od.Value = discount.out_date ?? DateTime.Now;
                        }

                        if (discount.discount_type_id == 5)
                        {
                            guna2TextBox_point.Text = discount.condition;
                        }
                    }
                    else
                    {
                        // Xử lý khi không tìm thấy mã giảm giá
                    }
                }
            }
        }

        private void guna2ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = guna2DataGridView1.SelectedRows[0];
                string discountID = row.Cells["Column1"].Value?.ToString();
                if (!string.IsNullOrEmpty(discountID))
                {
                    var discount = context.discounts.FirstOrDefault(d => d.discount_id == discountID);
                    if (discount != null)
                    {
                        discount.discount_type_id = Convert.ToInt32(guna2ComboBox1.SelectedValue);
                        discount.discount_amount = decimal.Parse(TextBoxPhantramck.Text) / 100;
                        discount.apply_count = int.Parse(txtNote.Text);
                        discount.min_amount = decimal.Parse(TextboxMucchi.Text);
                        discount.start_date = pickerstart.Value;
                        discount.end_date = pickerend.Value;

                        if (discount.discount_type_id == 3)
                        {
                            discount.out_date = guna2DateTimePicker1_od.Value;
                        }

                        if (discount.discount_type_id == 5)
                        {
                            discount.condition = guna2TextBox_point.Text;
                        }

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridViewDiscount();
                        RefeshUI();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một mã giảm giá để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DiscountSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = DiscountSearch.Text.ToLower();  // Lấy văn bản từ TextBox và chuyển thành chữ thường để tìm kiếm không phân biệt hoa thường.
            LoadFilteredDiscounts(searchText);  // Tải lại danh sách giảm giá dựa trên từ khóa tìm kiếm.
        }

        private void LoadFilteredDiscounts(string searchText)
        {
            var filteredData = context.discounts.Where(
                d => d.discount_id.ToLower().Contains(searchText) ||  // Tìm kiếm theo ID giảm giá.
                     d.discount_type.type_name.ToLower().Contains(searchText)  // Tìm kiếm theo tên loại giảm giá.
            ).ToList();

            UpdateDataGridView(filteredData);  // Cập nhật DataGridView với dữ liệu đã lọc.
        }

        private void UpdateDataGridView(List<discount> discounts)
        {
            guna2DataGridView1.Rows.Clear();  // Xóa các hàng hiện tại trong DataGridView.

            foreach (var discount in discounts)
            {
                string endDate = discount.end_date.HasValue ? discount.end_date.Value.ToShortDateString() : ""; // Kiểm tra giá trị null trước khi gọi phương thức.

                guna2DataGridView1.Rows.Add(
                    discount.discount_id,
                    discount.discount_type.type_name,
                    (discount.discount_amount * 100).ToString() + "%",
                    discount.apply_count,
                    discount.min_amount,
                    endDate // Sử dụng biến endDate đã kiểm tra null.
                );
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
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
                if (dis_type_id == 2)
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
                else if (dis_type_id == 3)
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
                }
                else if (dis_type_id == 5)
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
    }
}
