using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.InputProduct
{
    public class UpdateImport
    {
        public static void UpdateImportInDatabase(int importid, int productid, DateTime importdate, int quantity, String importer, String source)
        {
            using (var context = new BookShopEntities3())
            {
                //existing: biến cục bộ, lưu trữ đối tượng và kiểm tra xem có trùng import 
                var existingPro = context.importproducts.FirstOrDefault(i => i.importid == importid);
                if (existingPro != null)
                {
                    existingPro.importid = importid;
                    existingPro.productid = productid;
                    existingPro.importdate = importdate;
                    existingPro.quantity = quantity;
                    existingPro.importer = importer;
                    existingPro.source = source;
                    context.SaveChanges();
                }
            }
        }
    }
}
