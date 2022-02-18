using SuperMarket.Core;
using SuperMarket.Management.Interfaces;
using SuperMarket.Management.ManagementInterafaces;

namespace SuperMarket.Management.CategoriesManagement
{
    public class SelectByIdCategory : ISelectByIdCategory
    {
        private readonly ICategoriesManagementRepository managementRepository;

        public SelectByIdCategory(ICategoriesManagementRepository _managementRepository)
        {
            managementRepository = _managementRepository;
        }
        public Category Execute(int categoryId)
        {
            return managementRepository.SelectByIdGategory(categoryId);
        }
    }
}
