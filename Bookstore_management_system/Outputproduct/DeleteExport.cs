using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Outputproduct
{
    public class DeleteExport
    {
        public static bool DeleteExportProductById(int exportid)
        {
            try
            {
                using (var context = new BookShopEntities3())
                {
                    var existingExport = context.exportproducts.FirstOrDefault(s => s.exportid == exportid);
                    if (existingExport != null)
                    {
                        context.exportproducts.Remove(existingExport);
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
