using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ShopSmart.Dal
{
    /// <summary>
    /// An extension for the product ef entity
    /// </summary>
    public partial class Product
    {
        
        public override string ToString()
        {
            return this.ProductName;
        }

    }


    /// <summary>
    /// An extension for the category ef entity
    /// </summary>
    public partial class Category
    {
        public override string ToString()
        {
            return this.Name;
        }
    }

    /// <summary>
    /// An extension for the ShopList ef entity
    /// </summary>
    public partial class ShopList
    {
        /// <summary>
        /// Gets the total price of items in shop list.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public decimal TotalPrice
        {
            get
            {
                return this.ShoplistItems.Sum(item => item.Product.Price * item.Quantity) ?? 0;
            }
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Items: '{0}', Total Price: '{1}'.", this.ShoplistItems.Count, this.TotalPrice);
        }
    }


    /// <summary>
    /// An extension for the ShoplistItem ef entity
    /// </summary>
    public partial class ShoplistItem:IComparable
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("{0} * {1}", this.Product.ProductName, this.Quantity);
        }

        public int CompareTo(object objOther)
        {
            ShoplistItem other = objOther as ShoplistItem;
            if (other == null)
            {
                throw new ArgumentException("Cannot compare shoplist item to a non shoplist item");                
            }

            int mySort = this.Product.Category.CategorySorts.SingleOrDefault(cs => cs.SupermarketId == this.ShopList.SuperMarketId).SortValue;
            int otherSort = other.Product.Category.CategorySorts.SingleOrDefault(cs => cs.SupermarketId == other.ShopList.SuperMarketId).SortValue;

            return mySort.CompareTo(otherSort);
        }
    }

    /// <summary>
    /// An extension for the Customer ef entity
    /// </summary>
    public partial class Customer
    {
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Customer other = obj as Customer;
            if (other == null)
            {
                throw new ArgumentException("Customer cannot be compared to non Customer object");
            }
            return this.UserName.Equals(other.UserName);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("UserName: '{0}'; Type: '{1}'",this.UserName,this.UserType);
        }
    }
}
