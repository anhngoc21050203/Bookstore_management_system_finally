using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_management_system.Payment
{
    public class OrdersDetails
    {
        public static orderdetail CreateOrdersDetails(long orderid, int proid, int number, decimal totalP, int pment) {
            return new orderdetail
            {
                orderid = orderid,
                productid = proid,
                quantity = number,
                totalprice = totalP,
                payment = pment
            };
        }
    }
}
