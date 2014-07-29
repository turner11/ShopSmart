using ShopSmart.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//This file will hold types that we might use across projects in this solution
namespace ShopSmart.Common
{
    public class ShoplistItemCandidate 
    {
        private Product Product;
        /// <summary>
        /// Indicates whether this candidate should be added to the shoplist
        /// </summary>
        public bool ToBuy { get; set; }
        /// <summary>
        /// The amount of items to add to list
        /// </summary>
        public int Quantity { get; set; }
        
        #region Wiering to product...

        public int Id { get { return this.Product.Id; } }
        public string ProductName { get { return this.Product.ProductName; } }
        public int CategoryID { get { return this.Product.CategoryID; } }
        public string Notes { get; set; }
        public Nullable<decimal> Price { get { return this.Product.Price; } set { this.Product.Price = value; } }
        public bool Main { get { return this.Product.Main; } set { this.Product.Main = value; } }


        public virtual Category Category { get { return this.Product.Category; } }

        public virtual ICollection<Commercial> Commercials { get { return this.Product.Commercials; } } 
        #endregion

        public decimal TotalCost
        {
            get
            {
                return (this.Price ?? 0) * this.Quantity;
            }
        }

        public ShoplistItemCandidate(Product product)
        {
            this.Product = product;
        }
    }
}
