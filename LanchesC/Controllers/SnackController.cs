using LanchesC.Models;
using LanchesC.Models.ViewModels;
using LanchesC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string actualCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(snack => snack.SnackId);
                actualCategory = "All snacks";
            }
            else
            {
                snacks = _snackRepository.Snacks
                    .Where(snack => snack.Category.CategoryName.Equals(category))
                    .OrderBy(snack => snack.Name);

                actualCategory = category;
            }

            var snacksListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                ActualCategory = actualCategory
            };

            return View(snacksListViewModel);
        }
    }
}
