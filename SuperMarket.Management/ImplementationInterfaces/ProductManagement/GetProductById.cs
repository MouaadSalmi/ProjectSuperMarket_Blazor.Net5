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
    public class GetProductById : IGetProductById
    {
        private readonly IProductManagementRepository productInMemory;

        public GetProductById(IProductManagementRepository _productInMemory)
        {
            productInMemory = _productInMemory;
        }
        public Product Execute(int productId)
        {
            return productInMemory.GetProductById(productId);
        }
    }
}
