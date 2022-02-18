using SuperMarket.Core;
using System.Collections.Generic;

namespace SuperMarket.Data.InMemory
{
    public interface IProductManagementRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        void UpdateProduct(Product product);
    }
}