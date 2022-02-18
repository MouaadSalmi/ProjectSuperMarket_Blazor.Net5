using Microsoft.EntityFrameworkCore;
using SuperMarket.Core;
using SuperMarket.Management.ManagementInterafaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Data.Sql.Repositories
{
    public class TransactionsManagementRepository : ITransactionsManagementRepository
    {
        private readonly AppDbContext db;

        public TransactionsManagementRepository(AppDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<Transa> Get(string cashierName)
        {
            return db.Transactions.ToList();
        }

        public IEnumerable<Transa> GetByDay(string cashierName, DateTime date)
        {
            return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transa
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transa> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
             return db.Transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
