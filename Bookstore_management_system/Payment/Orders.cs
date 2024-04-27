using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Payment
{   
    
    public class Orders
    {
        public static orderp NewOrder(long orid, byte[] barcode, long staffid, int cusid, DateTime ordate, decimal totalprice, string dis, int totalPro)
        {
            return new orderp
            {
                orderid = orid,
                staffid = staffid,
                barcode = barcode,
                paycustomerid = cusid,
                orderdate = ordate,
                totalamount = totalprice,
                discountused = dis,
                number = totalPro
            };
        }
    }
}
