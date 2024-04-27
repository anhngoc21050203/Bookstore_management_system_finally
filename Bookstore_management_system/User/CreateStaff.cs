using Bookstore_management_system.LoginProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.User
{
    public class StaffCreate
    {
        public static staff CreateStaffObject(long manv, string fullname, string gender, DateTime dateofbirth, string email, string cccd, string address, string phone, string username, string password, decimal luongcoban, byte[] avatarBytes, int role, int calam)
        {
            string hashedPassword = Login_processing.HashPassword(password);

            return new staff
            {
                id = manv,
                fullname = fullname,
                sex = gender,
                date_of_birth = dateofbirth,
                cccd = cccd,
                address = address,
                phone = phone,
                email = email,
                username = username,
                password = hashedPassword, // Lưu chuỗi băm thay vì mật khẩu gốc
                avatar = avatarBytes,
                luongcoban = luongcoban,
                role_id = role,
                shift_id = calam,
                active = false
            };
        }
    }
}
