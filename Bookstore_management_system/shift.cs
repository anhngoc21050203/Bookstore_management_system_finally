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
    
    public partial class shift
    {
        public shift()
        {
            this.staffs = new HashSet<staff>();
        }
    
        public int shiftid { get; set; }
        public string name { get; set; }
        public decimal hesoluong { get; set; }
    
        public virtual ICollection<staff> staffs { get; set; }
    }
}
