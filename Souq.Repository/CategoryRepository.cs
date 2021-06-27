using Microsoft.EntityFrameworkCore;
using Souq.Database;
using Souq.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Souq.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbSet<Category> _dbset;
        public CategoryRepository(SouqContext context)
        {
            _dbset = context.Set<Category>();
        }

        public IEnumerable<Category> GetCategorys()
        {
            return
                 _dbset.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return
                 _dbset.Where(x => x.ID == id).FirstOrDefault();
        }

        public void AddCategory(Category Category)
        {
            _dbset.Add(Category);
        }

        public void RemoveCategory(Category Category)
        {
            _dbset.Remove(Category);
        }

    }
}
