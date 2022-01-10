using LanchesC.Data;
using LanchesC.Models;
using LanchesC.Repositories.Interfaces;
using System.Collections.Generic;

namespace LanchesC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<Category> Categories => _context.Categorys;
    }
}
