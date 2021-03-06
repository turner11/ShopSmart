﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Drawing;


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
            return string.Format("{0}, {1}: Items: '{2}', Total Price: '{3}'.", this.Date.ToShortDateString(), this.Supermarket.Name,this.ShoplistItems.Count, this.TotalPrice);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            ShopList other = obj as ShopList;
            if (other == null)
            {
                throw new ArgumentNullException("Cannot compare a non Shoplist object to a shoplist");
            }
            return this.Id.Equals(other.Id);
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
    /// An extension for the ShoplistItem ef entity
    /// </summary>
    public partial class ShoplistItem:IComparable
    {
        public String Notes { get; set; }
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

            CategorySort myCatSort = this.Product.Category.CategorySorts.SingleOrDefault(cs => cs.SupermarketId == this.ShopList.SuperMarketId);
            CategorySort otherCatSort = other.Product.Category.CategorySorts.SingleOrDefault(cs => cs.SupermarketId == other.ShopList.SuperMarketId);
            int mySort = myCatSort != null? myCatSort.SortValue : int.MaxValue;
            int otherSort = otherCatSort != null? otherCatSort.SortValue : int.MaxValue;

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

    public partial class Commercial
    {
        public byte[] imageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public Image GetImage()
        {
            return this.byteArrayToImage(this.Image);
        }

        public void SetImage(Image imageIn)
        {
            this.Image = this.imageToByteArray(imageIn);
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

}
