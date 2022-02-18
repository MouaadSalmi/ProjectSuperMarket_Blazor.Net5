using SuperMarket.Core;
using SuperMarket.Management.ManagementInterafaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket.Data.InMemory
{
    public class CategoryInMemoryRepository : ICategoriesManagementRepository
    {
        public List<Category> categories;

        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category{ CategoryId = 1 , Name = "HighTech" , Description ="HighTech"},
                new Category{ CategoryId = 2 , Name = "ElectroMenager" , Description ="ElectroMenager"},
                new Category{ CategoryId = 3 , Name = "Boulangerie" , Description ="Boulangerie"}
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
                return;
            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
        }

        public void DeleteCategory(int id)
        {
            var cat = SelectByIdGategory(id);
            categories.Remove(cat);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category SelectByIdGategory(int id)
        {
            return categories?.FirstOrDefault(a => a.CategoryId == id);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = SelectByIdGategory(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
    }
}
