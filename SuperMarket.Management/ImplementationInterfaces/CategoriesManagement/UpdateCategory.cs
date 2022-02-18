using SuperMarket.Core;
using SuperMarket.Management.Interfaces;
using SuperMarket.Management.ManagementInterafaces;

namespace SuperMarket.Management.CategoriesManagement
{
    public class UpdateCategory : IUpdateCategory
    {
        private readonly ICategoriesManagementRepository memoryRepository;

        public UpdateCategory(ICategoriesManagementRepository _memoryRepository)
        {
            memoryRepository = _memoryRepository;
        }
        public void Execute(Category category)
        {
            memoryRepository.UpdateCategory(category);
        }
    }
}
