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
    public class GetProductsByCategoryId : IGetProductsByCategoryId
    {
        private readonly IProductManagementRepository productInMemory;

        public GetProductsByCategoryId(IProductManagementRepository _productInMemory)
        {
            productInMemory = _productInMemory;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return productInMemory.GetProductsByCategoryId(categoryId);
        }
    }
}
