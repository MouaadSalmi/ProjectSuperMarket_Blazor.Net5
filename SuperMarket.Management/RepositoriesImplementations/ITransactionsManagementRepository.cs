using SuperMarket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperMarket.Management.ManagementInterafaces
{
    public interface ITransactionsManagementRepository
    {
        public IEnumerable<Transa> Get(string cashierName);
        public IEnumerable<Transa> GetByDay(string cashierName, DateTime date);
        public IEnumerable<Transa> Search(string cashierName, DateTime startDate, DateTime endate);
        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
    }
}
