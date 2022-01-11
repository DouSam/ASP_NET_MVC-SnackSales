using LanchesC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanchesC.Components
{
    public class MenuCategories : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public MenuCategories(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
