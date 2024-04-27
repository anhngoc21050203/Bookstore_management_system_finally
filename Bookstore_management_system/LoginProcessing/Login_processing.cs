using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.LoginProcessing
{
    public class Login_processing
    {
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Băm mật khẩu nhập vào
            string hashedInputPassword = HashPassword(password);

            // So sánh mật khẩu băm từ nguồn dữ liệu với mật khẩu đã nhập
            return string.Equals(hashedInputPassword, hashedPassword);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Tính toán giá trị băm của mật khẩu
                byte[] hash = sha256.ComputeHash(bytes);

                // Chuyển đổi mảng byte thành chuỗi hex để lưu trữ
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
