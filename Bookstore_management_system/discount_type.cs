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
    
    public partial class discount_type
    {
        public discount_type()
        {
            this.discounts = new HashSet<discount>();
        }
    
        public int discount_type_id { get; set; }
        public string type_name { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<discount> discounts { get; set; }
    }
}
