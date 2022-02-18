using SuperMarket.Management.ManagementInterafaces;
using SuperMarket.Management.ProductInterface;
using SuperMarket.Management.TranscationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.Transactions
{
    public class RecordTransaction : IRecordTransactions
    {
        private readonly ITransactionsManagementRepository transactionRepository;
        private readonly IGetProductById getProductById;

        public RecordTransaction(
            ITransactionsManagementRepository _transactionRepository,
            IGetProductById _getProductById)
        {
            transactionRepository = _transactionRepository;
            getProductById = _getProductById;
        }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = getProductById.Execute(productId);
            //Save transaction
            transactionRepository.Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qty);
        }
    }
}
