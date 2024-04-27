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
using Bookstore_management_system;
using Guna.UI2.WinForms;
using Bookstore_management_system.Image_processing;
using Bookstore_management_system.Print;
using System.Security.Cryptography;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Security.Claims;
using System.Data.Objects.SqlClient;

namespace Bookstore_management_system.User
{
    public partial class User_Management : Form
    {
        private BookShopEntities3 context;
        public User_Management()
        {
            InitializeComponent();

            context = new BookShopEntities3();

            guna2DataGridView1.CellDoubleClick += Guna2DataGridView1_CellDoubleClick;
        }

        private void Guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                String sex = row.Cells["sex"].Value.ToString();
                String rolename = row.Cells["rolename"].Value.ToString();
                String shiftname = row.Cells["shiftname"].Value.ToString();

                int roleId = GetRoleIdByName(rolename);

                // Lấy shift_id tương ứng với shiftname từ cơ sở dữ liệu
                int shiftId = GetShiftIdByName(shiftname);
                // Gán giá trị vào textbox
                guna2TextBox_name.Text = row.Cells["fullname"].Value.ToString();
                if (sex.Equals("Nam"))
                {
                    guna2CustomRadioButton_nam.Checked = true;
                }
                else
                {
                    guna2CustomRadioButton_nu.Checked = true;
                }

                if (row.Cells["date_of_birth"].Value != null)
                {
                    string dateString = row.Cells["date_of_birth"].Value.ToString();
                    if (DateTime.TryParse(dateString, out DateTime dateOfBirth))
                    {
                        guna2DateTimePicker_dateofbirth.Value = dateOfBirth;
                    }
                }
                if (row.Cells["avatar"].Value is Image avatarImage)
                {
                    // Gán ảnh từ ô "avatar" vào PictureBox
                    guna2PictureBox_img.Image = avatarImage;
                }
                else
                {
                    // Nếu ô "avatar" không chứa dữ liệu hình ảnh, xử lý tùy thuộc vào yêu cầu của bạn
                    guna2PictureBox_img.Image = null; // Hoặc gán một hình ảnh mặc định khác
                }

                guna2TextBox_name.Text = row.Cells["fullname"].Value?.ToString();
                guna2TextBox_cccd.Text = row.Cells["cccd"].Value?.ToString();
                guna2TextBox_email.Text = row.Cells["email"].Value?.ToString();
                guna2TextBox_address.Text = row.Cells["address"].Value?.ToString();
                guna2TextBox_phone.Text = row.Cells["phone"].Value?.ToString();
                guna2TextBox_mnv.Text = row.Cells["mnv"].Value?.ToString();
                guna2TextBox_username.Text = row.Cells["username"].Value?.ToString();
                guna2TextBox_password.Text = row.Cells["password"].Value?.ToString();
                guna2TextBox_hesoluong.Text = row.Cells["luongcoban"].Value?.ToString();
                guna2ComboBox_role.SelectedValue = roleId;
                guna2ComboBox_calam.SelectedValue = shiftId;

            }
        }

        private int GetRoleIdByName(string roleName)
        {
            using (var context = new BookShopEntities3())
            {
                var role = context.roles.FirstOrDefault(r => r.rolename == roleName);
                return role != null ? role.roleid : -1; // Trả về -1 nếu không tìm thấy
            }
        }

        private int GetShiftIdByName(string shiftName)
        {
            using (var context = new BookShopEntities3())
            {
                var shift = context.shifts.FirstOrDefault(s => s.name == shiftName);
                return shift != null ? shift.shiftid : -1; // Trả về -1 nếu không tìm thấy
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void User_Management_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookShopShift.shift' table. You can move, or remove it, as needed.
            this.shiftTableAdapter.Fill(this.bookShopShift.shift);
            // TODO: This line of code loads data into the 'bookShopRole.role' table. You can move, or remove it, as needed.
            this.roleTableAdapter.Fill(this.bookShopRole.role);
            // TODO: This line of code loads data into the 'bookShopDataSet.role' table. You can move, or remove it, as needed.

            try
            {
                // Đảm bảo dữ liệu của bảng shift và role đã được tải vào DataSet trước khi thực hiện các thao tác khác
                

                // Ẩn Panel2
                guna2Panel2.Visible = false;

                // Sử dụng context trong khối using để đảm bảo rằng nó sẽ được giải phóng khi không cần thiết
                using (var context = new BookShopEntities3())
                {
                    // Sử dụng Task.Run để thực thi truy vấn LINQ mà không làm treo giao diện người dùng
                    var staff = await Task.Run(() =>
                    {
                        // Thực hiện truy vấn LINQ để lấy dữ liệu từ cơ sở dữ liệu
                        return (from s in context.staffs
                                join r in context.roles on s.role_id equals r.roleid
                                join sh in context.shifts on s.shift_id equals sh.shiftid
                                select new
                                {
                                    s.id,
                                    s.fullname,
                                    s.sex,
                                    s.date_of_birth,
                                    s.address,
                                    s.phone,
                                    s.email,
                                    s.cccd,
                                    s.avatar,
                                    s.username,
                                    s.password,
                                    s.luongcoban,
                                    RoleName = r.rolename,
                                    ShiftName = sh.name
                                }).ToList();
                    });

                    // Xóa tất cả các dòng hiện có trong DataGridView trước khi thêm dữ liệu mới
                    guna2DataGridView1.Rows.Clear();

                    // Thêm dữ liệu từ danh sách staff vào DataGridView
                    foreach (var item in staff)
                    {
                        // Decode dữ liệu avatar từ byte[] sang hình ảnh Image
                        Image avatarImage = null;
                        if (item.avatar != null)
                        {
                            avatarImage = ImageProcessor.DecodeImageFromVarbinary(item.avatar);
                        }

                        // Thêm dòng mới vào DataGridView
                        guna2DataGridView1.Rows.Add(
                            item.id,
                            item.fullname,
                            item.sex,
                            item.date_of_birth,
                            item.address,
                            item.phone,
                            item.email,
                            item.cccd,
                            avatarImage,
                            item.username,
                            item.password,
                            item.luongcoban,
                            item.RoleName,
                            item.ShiftName
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button_add_Click(object sender, EventArgs e)
        {
            guna2Panel2.Visible = true;
            guna2DataGridView1.Enabled = false;
            guna2Button_add.Enabled = false;
            guna2Button_del.Enabled = false;
            guna2Button_update.Enabled = false;
            guna2HtmlLabel1_tb.Text = "Bạn đang ở chế độ thêm mới";
        }

        private string GenerateEmployeeID(int role_id)
        {
            // Lấy hai chữ số cuối của năm hiện tại
            string yearSuffix = (DateTime.Now.Year % 100).ToString("00");

            // Sinh một số ngẫu nhiên từ 1000 đến 9999
            Random random = new Random();
            string randomDigits = random.Next(1000, 9999).ToString();

            // Kết hợp các thành phần để tạo mã nhân viên
            string employeeID = yearSuffix + role_id.ToString() + randomDigits;

            return employeeID;
        }

        private void guna2Button_update_Click(object sender, EventArgs e)
        {
            guna2Panel2.Visible = true;
            guna2Button_add.Enabled = false;
            guna2Button_del.Enabled = true;
            guna2Button_add.Enabled = false;
            guna2HtmlLabel1_tb.Text = "Bạn đang ở chế độ sửa";
        }

        private void guna2Button_del_Click(object sender, EventArgs e)
        {
            long staffId = long.Parse(guna2TextBox_mnv.Text);
            bool isSuccess = StaffDelete.DeleteStaffById(staffId);
            if (isSuccess)
            {
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataToDataGridView();
        }

        private void LoadDataToDataGridView()
        {
            using (var context = new BookShopEntities3())
            {
                var staff = (from s in context.staffs
                             join r in context.roles on s.role_id equals r.roleid
                             join sh in context.shifts on s.shift_id equals sh.shiftid
                             select new
                             {
                                 s.id,
                                 s.fullname,
                                 s.sex,
                                 s.date_of_birth,
                                 s.address,
                                 s.phone,
                                 s.email,
                                 s.cccd,
                                 s.avatar,
                                 s.username,
                                 s.password,
                                 s.luongcoban,
                                 RoleName = r.rolename,
                                 ShiftName = sh.name
                             }).ToList();

                // Xóa các dòng hiện có trong DataGridView để tránh việc dữ liệu bị trùng lặp khi load lại form
                guna2DataGridView1.Rows.Clear();

                // Đổ dữ liệu vào DataGridView
                foreach (var item in staff)
                {
                    Image avatarImage = null;
                    if (item.avatar != null)
                    {
                        avatarImage = ImageProcessor.DecodeImageFromVarbinary(item.avatar);
                    }

                    guna2DataGridView1.Rows.Add(
                        item.id,
                        item.fullname,
                        item.sex,
                        item.date_of_birth,
                        item.address,
                        item.phone,
                        item.email,
                        item.cccd,
                        avatarImage,
                        item.username,
                        item.password,
                        item.luongcoban,
                        item.RoleName,
                        item.ShiftName
                    );
                }
    
            }
        }

        private void guna2Button_save_Click(object sender, EventArgs e)
        {
            string updateId = guna2TextBox_mnv.Text;
            string username = guna2TextBox_username.Text;
            var existingUser = context.staffs.FirstOrDefault(u => u.username == username);

            // updateId ==n null thi thực hiên thêm mới
            if (string.IsNullOrEmpty(updateId))
            {

                if (existingUser != null)
                {
                    MessageBox.Show("Người dùng đã tồn tại. Vui lòng nhập một tên người dùng khác.", "Thông báo");
                }
                else
                {
                    AddNewStaff();
                    ResetTextBoxes();
                }
            }
            else
            {

                if (existingUser != null)
                {
                    MessageBox.Show("Người dùng đã tồn tại. Vui lòng nhập một tên người dùng khác.", "Thông báo");
                }
                else
                {
                    UpdateExistingStaff();
                    ResetTextBoxes();
                }
            }
            LoadDataToDataGridView();
        }

        private void AddNewStaff()
        {
            // Lấy thông tin từ giao diện người dùng
            string fullname = guna2TextBox_name.Text;
            string gender = guna2CustomRadioButton_nam.Checked ? "Nam" : "Nữ";
            DateTime dateofbirth = guna2DateTimePicker_dateofbirth.Value;
            string email = guna2TextBox_email.Text;
            string cccd = guna2TextBox_cccd.Text;
            string address = guna2TextBox_address.Text;
            string phone = guna2TextBox_phone.Text;
            string username = guna2TextBox_username.Text;
            string password = guna2TextBox_password.Text;
            decimal luongcoban = decimal.Parse(guna2TextBox_hesoluong.Text);
            byte[] avatarBytes = ImageProcessor.EncodeImageToVarbinary(guna2PictureBox_img.Image);
            DataRowView selectedRow = (DataRowView)guna2ComboBox_role.SelectedItem;
            int role = Convert.ToInt32(selectedRow["roleid"]);
            DataRowView selectedRow2 = (DataRowView)guna2ComboBox_calam.SelectedItem;
            int calam = Convert.ToInt32(selectedRow2["shiftid"]);
            long manv = long.Parse(GenerateEmployeeID(role));

            var existingUser = context.staffs.FirstOrDefault(u => u.username == username);

      
            var newStaff = StaffCreate.CreateStaffObject(manv, fullname, gender, dateofbirth, email, cccd, address, phone, username, password, luongcoban, avatarBytes, role, calam);
            AddStaffToDatabase(newStaff);

        }

        private void AddStaffToDatabase(staff newStaff)
        {
            using (var context = new BookShopEntities3())
            {
                context.staffs.Add(newStaff);
                context.SaveChanges();
            }
        }

        private void UpdateExistingStaff()
        {
            long staffId = long.Parse(guna2TextBox_mnv.Text);

            // Lấy thông tin từ giao diện người dùng
            string fullname = guna2TextBox_name.Text;
            string gender = guna2CustomRadioButton_nam.Checked ? "Nam" : "Nữ";
            DateTime dateofbirth = guna2DateTimePicker_dateofbirth.Value;
            string email = guna2TextBox_email.Text;
            string cccd = guna2TextBox_cccd.Text;
            string address = guna2TextBox_address.Text;
            string phone = guna2TextBox_phone.Text;
            string username = guna2TextBox_username.Text;
            string password = guna2TextBox_password.Text;
            decimal luongcoban = decimal.Parse(guna2TextBox_hesoluong.Text);
            byte[] avatarBytes = ImageProcessor.EncodeImageToVarbinary(guna2PictureBox_img.Image);
            DataRowView selectedRow = (DataRowView)guna2ComboBox_role.SelectedItem;
            int role = Convert.ToInt32(selectedRow["roleid"]);
            DataRowView selectedRow2 = (DataRowView)guna2ComboBox_calam.SelectedItem;
            int calam = Convert.ToInt32(selectedRow2["shiftid"]);


            StaffUpdate.UpdateStaffInDatabase(staffId, fullname, gender, dateofbirth, email, cccd, address, phone, username, password, luongcoban, avatarBytes, role, calam);
            
            // Gọi phương thức từ lớp UpdateStaffHelper để cập nhật nhân viên trong cơ sở dữ liệu
        }

        private void guna2Button_print_Click(object sender, EventArgs e)
        {
            PrintStaff printStaff = new PrintStaff();
            printStaff.ShowDialog();
        }

        private void guna2Button1_upload_Click(object sender, EventArgs e)
        {
            byte[] imageData = ImageProcessor.UploadImage();
            if (imageData != null)
            {
                // Hiển thị ảnh trên PictureBox
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    guna2PictureBox_img.Image = image;
                }
            }
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel2.Visible = false;
            guna2DataGridView1.Enabled = true;
            guna2Button_add.Enabled = true;
            guna2Button_del.Enabled = true;
            guna2Button_update.Enabled = true;
            guna2HtmlLabel1_tb.Text = "";
            ResetTextBoxes();
        }
        private void ResetTextBoxes()
        {
            guna2TextBox_name.Text = null;
            guna2TextBox_email.Text = null;
            guna2TextBox_cccd.Text = null;
            guna2TextBox_address.Text = null;
            guna2TextBox_phone.Text = null;
            guna2TextBox_username.Text = null;
            guna2TextBox_password.Text = null;
            guna2TextBox_hesoluong.Text = null;
            guna2TextBox_mnv.Text = null;
            // Thêm các TextBox khác ở đây...

            // Reset giá trị của các control khác như DateTimePicker, RadioButton, ComboBox,...
            guna2CustomRadioButton_nam.Checked = false;
            guna2DateTimePicker_dateofbirth.Value = DateTime.Now;
            guna2PictureBox_img.Image = null;
            guna2ComboBox_role.SelectedIndex = 0;
            guna2ComboBox_calam.SelectedIndex = 0;
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchUser.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                try
                {
                    using (var context = new BookShopEntities3())
                    {
                        // Thực hiện truy vấn để lọc dữ liệu từ cơ sở dữ liệu
                        var staff = (from s in context.staffs
                                     join r in context.roles on s.role_id equals r.roleid
                                     join sh in context.shifts on s.shift_id equals sh.shiftid
                                     where SqlFunctions.StringConvert((decimal)s.id).Contains(searchKeyword) || s.fullname.Contains(searchKeyword) || r.rolename.Contains(searchKeyword) || sh.name.Contains(searchKeyword)
                                     select new
                                     {
                                         s.id,
                                         s.fullname,
                                         s.sex,
                                         s.date_of_birth,
                                         s.address,
                                         s.phone,
                                         s.email,
                                         s.cccd,
                                         s.avatar,
                                         s.username,
                                         s.password,
                                         s.luongcoban,
                                         RoleName = r.rolename,
                                         ShiftName = sh.name
                                     }).ToList();

                        // Xóa dữ liệu hiện tại trong DataGridView
                        guna2DataGridView1.Rows.Clear();

                        // Thêm dữ liệu đã lọc vào DataGridView
                        foreach (var item in staff)
                        {
                            Image avatarImage = null;
                            if (item.avatar != null)
                            {
                                avatarImage = ImageProcessor.DecodeImageFromVarbinary(item.avatar);
                            }

                            guna2DataGridView1.Rows.Add(
                                item.id,
                                item.fullname,
                                item.sex,
                                item.date_of_birth,
                                item.address,
                                item.phone,
                                item.email,
                                item.cccd,
                                avatarImage,
                                item.username,
                                item.password,
                                item.luongcoban,
                                item.RoleName,
                                item.ShiftName
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, load lại toàn bộ dữ liệu
                LoadDataToDataGridView();
            }
        }
    }
}
