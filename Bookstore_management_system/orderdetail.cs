//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookstore_management_system
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderdetail
    {
        public long orderdetailid { get; set; }
        public Nullable<long> orderid { get; set; }
        public Nullable<int> productid { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<decimal> totalprice { get; set; }
        public int payment { get; set; }
    
        public virtual product product { get; set; }
        public virtual payment_methods payment_methods { get; set; }
        public virtual orderp orderp { get; set; }
    }
}
