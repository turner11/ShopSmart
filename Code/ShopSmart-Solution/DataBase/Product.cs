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
    
    public partial class Product
    {
        public Product()
        {
            this.ShoplistItems = new HashSet<ShoplistItem>();
            this.Commercials = new HashSet<Commercial>();
        }
    
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string Notes { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool Main { get; set; }
        public System.Guid guid { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<ShoplistItem> ShoplistItems { get; set; }
        public virtual ICollection<Commercial> Commercials { get; set; }
    }
}
