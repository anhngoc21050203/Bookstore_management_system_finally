using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.InputProduct
{
    public class createImport
    {
        public static importproduct CreateObjectImport(int importid, int productid, DateTime importdate, int quantity, String importer, String source)
        {
            // Tạo đối tượng product mới
            return new importproduct
            {
                importid = importid,
                productid = productid,
                importdate = importdate,
                quantity = quantity,
                importer = importer,
                source = source

            };
       
        }

        
    }
}
