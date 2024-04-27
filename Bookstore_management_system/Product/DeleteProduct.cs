using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Product
{
    public class DeleteProduct
    {
        public static bool DeleteProductById(int productId)
        {
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var existingProduct = context.products.FirstOrDefault(s => s.productid == productId);
                    if (existingProduct != null)
                    {
                        context.products.Remove(existingProduct);
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
