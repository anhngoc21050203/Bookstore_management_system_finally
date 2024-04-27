using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Category
{
    public class deleteCategory
    {
        public static bool DeleteCategoryById(int category_id)
        {
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var existingCategory = context.categories.FirstOrDefault(s => s.category_id == category_id);
                    if (existingCategory != null)
                    {
                        context.categories.Remove(existingCategory);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
