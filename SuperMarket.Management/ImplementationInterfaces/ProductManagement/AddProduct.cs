using SuperMarket.Core;
using SuperMarket.Data.InMemory;
using SuperMarket.Management.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.ProductManagement
{
    public class AddProduct : IAddProduct
    {
        private readonly IProductManagementRepository productInMemory;

        public AddProduct(IProductManagementRepository _productInMemory)
        {
            productInMemory = _productInMemory;
        }
        public void Execute(Product product)
        {
            productInMemory.AddProduct(product);
        }
    }
}
