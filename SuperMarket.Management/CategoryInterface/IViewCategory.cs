using SuperMarket.Core;
using System.Collections.Generic;

namespace SuperMarket.Management.Interfaces
{
    public interface IViewCategory
    {
        IEnumerable<Category> Execute();
    }
}
