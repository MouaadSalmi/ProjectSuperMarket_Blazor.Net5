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
    public class GetTodayTransactions : IGetTodayTransactions
    {
        private readonly ITransactionsManagementRepository transactionRepository;

        public GetTodayTransactions(ITransactionsManagementRepository _transactionRepository)
        {
            transactionRepository = _transactionRepository;
        }

        public IEnumerable<Transa> Execute(string cashierName)
        {
            return transactionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}
