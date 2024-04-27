using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Outputproduct
{
    internal class CreateExport
    {
        public static exportproduct CreateObjectExport(int exportid, int productid, DateTime exportdate, int quantity, String exporter, String destination)
        {

            return new exportproduct
            {
                exportid = exportid,
                productid = productid,
                exportdate = exportdate,
                quantity = quantity,
                exporter = exporter,
                destination = destination
            };

        }
    }
}
