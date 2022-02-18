using SuperMarket.Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuperMarket.Management.ManagementInterafaces;

namespace SuperMarket.Management.CategoriesManagement
{
    public class DeleteCategory : IDeleteCategory
    {
        private readonly ICategoriesManagementRepository memoryRepository;

        public DeleteCategory(ICategoriesManagementRepository _memoryRepository)
        {
            memoryRepository = _memoryRepository;
        }
        public void execute(int id)
        {
            memoryRepository.DeleteCategory(id);
        }
    }
}
