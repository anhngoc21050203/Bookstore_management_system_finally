using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.InputProduct
{
    public class DeleteImport
    {
        public static bool DeleteImportProductById(int importid)
        {
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var existingImport = context.importproducts.FirstOrDefault(s => s.importid == importid);
                    if (existingImport != null)
                    {
                        context.importproducts.Remove(existingImport);
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
