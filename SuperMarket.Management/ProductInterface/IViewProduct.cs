using SuperMarket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.ProductInterface
{
    public interface IViewProduct
    {
        IEnumerable<Product> Execute();
    }
}
