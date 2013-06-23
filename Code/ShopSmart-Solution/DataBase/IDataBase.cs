using System;
namespace ShopSmart.Dal
{
    public interface IDataBase
    {
        Customer CreateCustomer(string userName, string password, UserTypes userType, string customerId, out string errorMessage);
        bool DeleteProduct(Product product, out string errorMsg);
        void Dispose();
        System.Collections.Generic.IEnumerable<Category> GetAllCategories();
        System.Collections.Generic.IEnumerable<Product> GetAllProducts();
        System.Collections.Generic.IEnumerable<Supermarket> GetAllSuperMarkets();
        System.Collections.Generic.List<ShopList> GetArchivedLists(Customer customer);
        System.Collections.Generic.List<Commercial> GetCommecialsForProducts(System.Collections.Generic.List<int> productsIds);
        System.Collections.Generic.List<Customer> GetCustomers(string userName, string password, UserTypes? userType);
        bool Save(System.Collections.Generic.List<Product> products, out string errorMessage);
        bool SaveChanges(out string errorMessage);
        bool SaveProduct(Product newProduct, out string errorMsg);
        bool SaveShoplist(ShopList list, out string errorMsg);
    }
}
