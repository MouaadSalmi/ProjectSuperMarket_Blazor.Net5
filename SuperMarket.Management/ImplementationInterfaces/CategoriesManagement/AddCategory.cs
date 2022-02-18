using SuperMarket.Core;
using SuperMarket.Management.ManagementInterafaces;

namespace SuperMarket.Management.CategoriesManagement
{
    public class AddCategory : IAddCategory
    {
        private readonly ICategoriesManagementRepository categoriesManagement;

        public AddCategory(ICategoriesManagementRepository _categoriesManagement)
        {
            categoriesManagement = _categoriesManagement;
        }
        public void Execute(Category category)
        {
            categoriesManagement.AddCategory(category);
        }
    }
}
