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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ProductName;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">Cannot compare Product to non Product object</exception>
        public override bool Equals(object obj)
        {
             Product other = obj as Product;
            if (other == null)
            {
                throw new ArgumentException("Cannot compare Product to non Product object");
            }

            return this.guid.Equals(other.guid);
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

    }


    /// <summary>
    /// An extension for the category ef entity
    /// </summary>
    public partial class Category
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">Cannot compare Category to non category object</exception>
        public override bool Equals(object obj)
        {
            Category other = obj as Category;
            if (other == null)
            {
                return false;//throw new ArgumentException("Cannot compare Category to non category object");
            }

            return this.guid.Equals(other.guid);
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
        /// Gets the sort by super market.
        /// </summary>
        /// <param name="superMarket">The super market.</param>
        /// <returns>the sort</returns>
        public CategorySort GetSortBySuperMarket(Supermarket superMarket)
        {
            return this.CategorySorts.FirstOrDefault(cs => cs.SupermarketId == superMarket.Id) ?? new CategorySortNullObject();
        }



    }

    /// <summary>
    /// An extension for the ShopList ef entity
    /// </summary>
    [Serializable]
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

        public override bool Equals(object obj)
        {
            ShopList other = obj as ShopList;
            if (other == null)
            {
                throw new ArgumentNullException("Cannot compare a Shoplist to non Shoplist Item");
            }
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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

    /// <summary>
    /// A null object for category sorts
    /// </summary>
    public class CategorySortNullObject : CategorySort
    {
        public CategorySortNullObject()
        {
            this.SortValue = 0;            
        }
    }

    /// <summary>
    /// A null object for category 
    /// </summary>
    public class CategoryNullObject : Category
    {
        public CategoryNullObject()
        {
            this.Name = String.Empty;
            this.Products = new List<Product>();
            this.Id = -1;
            this.CategorySorts = new List<CategorySort>();

        }
    }

    /// <summary>
    /// A wrapper for a shoplist with Extra information for archiving
    /// </summary>
    [Serializable]
    public class ArchivedShoplistObject
    {
        
        private DateTime _date;
        /// <summary>
        /// Gets the date that lsit was created at.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date
        {
            get { return _date; }
        }

        private ShopList _shoppingList;

        /// <summary>
        /// Gets the shopping list.
        /// </summary>
        /// <value>
        /// The shopping list.
        /// </value>
        public ShopList ShoppingList
        {
            get { return _shoppingList; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchivedShoplistObject"/> class.
        /// </summary>
        /// <param name="shoppingList">The shopping list.</param>
        public ArchivedShoplistObject(ShopList shoppingList)
        {
            this._date = DateTime.Now;
            this._shoppingList = new ShopList();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Cannot compare non ArchivedShoplist objet to ArchivedShoplist</exception>
        public override bool Equals(object obj)
        {
            ArchivedShoplistObject other = obj as ArchivedShoplistObject;
            if (other == null)
            {
                throw new ArgumentNullException("Cannot compare non ArchivedShoplist objet to ArchivedShoplist");
            }
            return this._shoppingList.Id.Equals(other.ShoppingList.Id);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("'{0}': '{1}'", this.Date,this.ShoppingList.ToString());
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

    }

}
