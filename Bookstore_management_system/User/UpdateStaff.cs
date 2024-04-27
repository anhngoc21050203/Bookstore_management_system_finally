using Bookstore_management_system.LoginProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.User
{
    public class StaffUpdate
    {
        public static void UpdateStaffInDatabase(long staffId, string fullname, string gender, DateTime dateofbirth, string email, string cccd, string address, string phone, string username, string password, decimal luongcoban, byte[] avatarBytes, int role, int calam)
        {
            string hashedPassword = Login_processing.HashPassword(password);
            using (var context = new BookShopEntities3())
            {
                var existingStaff = context.staffs.FirstOrDefault(s => s.id == staffId);
                if (existingStaff != null)
                {
                    existingStaff.fullname = fullname;
                    existingStaff.sex = gender;
                    existingStaff.date_of_birth = dateofbirth;
                    existingStaff.email = email;
                    existingStaff.cccd = cccd;
                    existingStaff.address = address;
                    existingStaff.phone = phone;
                    existingStaff.username = username;
                    existingStaff.password = hashedPassword;
                    existingStaff.luongcoban = luongcoban;
                    existingStaff.avatar = avatarBytes;
                    existingStaff.role_id = role;
                    existingStaff.shift_id = calam;
                    existingStaff.active = false;

                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên có ID: " + staffId, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
