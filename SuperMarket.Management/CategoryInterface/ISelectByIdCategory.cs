using SuperMarket.Core;

namespace SuperMarket.Management.Interfaces
{
    public interface ISelectByIdCategory
    {
        Category Execute(int categoryId);
    }
}
