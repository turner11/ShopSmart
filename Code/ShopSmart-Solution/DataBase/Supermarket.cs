//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopSmart.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supermarket 
    {
        public Supermarket()
        {
            this.CategorySorts = new HashSet<CategorySort>();
            this.ShopLists = new HashSet<ShopList>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.Guid guid { get; set; }
    
        public virtual ICollection<CategorySort> CategorySorts { get; set; }
        public virtual ICollection<ShopList> ShopLists { get; set; }
    }
}
