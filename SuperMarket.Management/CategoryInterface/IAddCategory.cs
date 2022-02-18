using SuperMarket.Core;

namespace SuperMarket.Management.CategoriesManagement
{
    public interface IAddCategory
    {
        void Execute(Category category);
    }
}