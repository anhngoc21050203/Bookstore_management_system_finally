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
    public partial class NewCustomer : Form
    {
        private BookShopEntities3 context;
        public event EventHandler<int> NewCustomerIdAdded;

        public NewCustomer()
        {
            InitializeComponent();
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int customerId = GenerateCustomerID();
            string discount_id = "NC";
            discount_id += customerId.ToString();
            string fullname = guna2TextBox_fullname.Text;
            string phone = guna2TextBox_phone.Text;
            string email = guna2TextBox_email.Text;
            string address = guna2TextBox_address.Text;

            if (phone.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng phương thức nếu số điện thoại không hợp lệ
            }
            else
            {
                using (context = new BookShopEntities3())
                {
                    customer customer = new customer
                    {
                        customerid = customerId,
                        fullname = fullname,
                        email = email,
                        phone = phone,
                        address = address,
                        point = 0,
                        returncount = 0,
                        datein = DateTime.Now,
                    };

                    discount newdiscount = new discount
                    {
                        discount_id = discount_id,
                        customer_id = customerId,
                        apply_count = 1,
                        discount_amount = (decimal)0.5,
                        created_at = DateTime.Now,
                        created_by = "Admin",
                        discount_type_id = 4,
                        note = "Giảm giá 50%"

                    };

                    context.customers.Add(customer);
                    context.discounts.Add(newdiscount);

                    context.SaveChanges();

                    if (NewCustomerIdAdded != null)
                    {
                        NewCustomerIdAdded(this, customerId); // customerId là ID mới của khách hàng vừa thêm
                    }


                    MessageBox.Show("Thêm khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
            }
        }
        private int GenerateCustomerID()
        {
            // Lấy năm, tháng, ngày và giờ hiện tại
            int year = DateTime.Now.Year % 100; // Lấy số cuối cùng của năm
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            // Định dạng các thành phần để có được ID theo yêu cầu
            string customerId = string.Format("{0:00}{1:00}{2:00}", year, month, day);

            // Sinh ba số ngẫu nhiên từ 0 đến 999
            Random random = new Random();
            int randomDigits = random.Next(1000);

            // Kết hợp ba số ngẫu nhiên vào ID
            customerId += randomDigits.ToString("000");

            // Chuyển đổi ID từ kiểu string sang kiểu int
            int customerIdInt = int.Parse(customerId);

            // Kiểm tra xem ID đã tồn tại trong cơ sở dữ liệu chưa
            using (var context = new BookShopEntities3())
            {
                // Lặp lại cho đến khi không còn trùng lặp với ID đã tồn tại trong cơ sở dữ liệu
                while (context.customers.Any(c => c.customerid == customerIdInt))
                {
                    customerId = string.Format("{0:00}{1:00}{2:00}04", year, month, day) + random.Next(1000).ToString("000");
                    customerIdInt = int.Parse(customerId);
                }
            }

            return customerIdInt;
        }

    }
}
