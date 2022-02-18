using SuperMarket.Core;
using SuperMarket.Management.Interfaces;
using SuperMarket.Management.ManagementInterafaces;
using System.Collections.Generic;

namespace SuperMarket.Management.CategoriesManagement
{
    public class ViewCategories : IViewCategory
    {
        private readonly ICategoriesManagementRepository managementRepo;

        public ViewCategories(ICategoriesManagementRepository _management)
        {
            managementRepo = _management;
        }

        public IEnumerable<Category> Execute()
        {
            return managementRepo.GetCategories();
        }

    }
}
