using SuperMarket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.TranscationsInterface
{
    public interface IGetTransactions
    {
        IEnumerable<Transa> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}
