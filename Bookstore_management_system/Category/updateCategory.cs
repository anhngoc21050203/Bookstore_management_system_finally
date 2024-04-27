using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Category
{
    public class updateCategory
    {
        public static void UpdateCategoryInDatabase(int category_id, String category_name)
        {
            using (var context = new BookShopEntities3())
            {
                //existing: biến cục bộ, lưu trữ đối tượng và kiểm tra xem có trùng import 
                var existingPro = context.categories.FirstOrDefault(i => i.category_id == category_id);
                if (existingPro != null)
                {
                    existingPro.category_id = category_id;
                    existingPro.category_name = category_name;
                 
                    context.SaveChanges();
                }
            }
        }
    }
}
