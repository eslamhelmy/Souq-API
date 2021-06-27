using Souq.Models;
using System.Collections.Generic;

namespace Souq.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategorys();
        void AddCategory(Category Category);
        void RemoveCategory(Category Category);
        Category GetCategoryById(int id);

    }
}