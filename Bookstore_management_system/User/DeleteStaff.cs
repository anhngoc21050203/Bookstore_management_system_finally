using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore_management_system.User
{
    public class StaffDelete
    {
        public static bool DeleteStaffById(long staffId)
        {
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var existingStaff = context.staffs.FirstOrDefault(s => s.id == staffId);
                    if (existingStaff != null)
                    {
                        context.staffs.Remove(existingStaff);
                        context.SaveChanges();
                        return true; // Xóa thành công
                    }
                    else
                    { 
                        return false; // Không tìm thấy nhân viên để xóa
                    }
                }
            }
            catch (Exception ex)
            {
                return false; // Lỗi xóa nhân viên
            }
        }
    }
}
