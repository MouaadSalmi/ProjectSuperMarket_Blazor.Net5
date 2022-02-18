using SuperMarket.Core;
using SuperMarket.Management.ManagementInterafaces;
using SuperMarket.Management.TranscationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.Transactions
{
    public class GetTransactions : IGetTransactions
    {
        //Transactions Report
        private readonly ITransactionsManagementRepository transactionRepository;

        public GetTransactions(ITransactionsManagementRepository _transactionRepository)
        {
            transactionRepository = _transactionRepository;
        }

        public IEnumerable<Transa> Execute(string cashierName,DateTime startDate,DateTime endDate)
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
