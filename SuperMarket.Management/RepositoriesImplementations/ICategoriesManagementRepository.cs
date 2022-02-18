using SuperMarket.Core;
using System.Collections.Generic;

namespace SuperMarket.Management.ManagementInterafaces
{
    public interface ICategoriesManagementRepository
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        Category SelectByIdGategory(int id);
        void DeleteCategory(int id);
    }
}
