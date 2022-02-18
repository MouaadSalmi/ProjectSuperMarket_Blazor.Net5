using SuperMarket.Data.InMemory;
using SuperMarket.Management.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.ProductManagement
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly IProductManagementRepository productInMemory;

        public DeleteProduct(IProductManagementRepository _productInMemory)
        {
            productInMemory = _productInMemory;
        }
        public void Execute(int productId)
        {
            productInMemory.DeleteProduct(productId);
        }
    }
}
