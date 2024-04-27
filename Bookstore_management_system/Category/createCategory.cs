using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Category
{
    public class createCategory
    {
        public static category CreateObjectCategoryt(int category_id, String category_name)
        {
            // Tạo đối tượng product mới
            return new category
            {
                category_id = category_id,
                category_name = category_name,
               


            };

        }
    }
}
