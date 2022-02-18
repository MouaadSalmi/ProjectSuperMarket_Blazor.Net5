using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.TranscationsInterface
{
    public interface IRecordTransactions
    {
        void Execute(string cashierName, int productId, int qty);
    }
}
