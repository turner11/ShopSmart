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
    
    public partial class Customer
    {
        public Customer()
        {
            this.ShopLists = new HashSet<ShopList>();
        }
    
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
    
        public virtual ICollection<ShopList> ShopLists { get; set; }
        public virtual ArchivedShoppingList ArchivedShoppingList { get; set; }
    }
}
