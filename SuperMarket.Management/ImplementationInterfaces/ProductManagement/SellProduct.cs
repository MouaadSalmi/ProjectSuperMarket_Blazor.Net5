using SuperMarket.Data.InMemory;
using SuperMarket.Management.ProductInterface;
using SuperMarket.Management.TranscationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.ProductManagement
{
    public class SellProduct : ISellProduct
    {
        private readonly IProductManagementRepository productRepo;
        private readonly IRecordTransactions recordTransaction;

        public SellProduct(
            IProductManagementRepository _productInMemory
            , IRecordTransactions _recordTransaction)
        {
            productRepo = _productInMemory;
            recordTransaction = _recordTransaction;
        }

        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productRepo.GetProductById(productId);
            if (product == null) return;
            recordTransaction.Execute(cashierName, productId, qtyToSell);
            //Mettre à jour la quantité restante en stock
            product.Quantity -= qtyToSell;
            productRepo.UpdateProduct(product);
        }
    }
}
