using LanchesC.Models;
using LanchesC.Models.ViewModels;
using LanchesC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Details(int snackId)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(l => l.SnackId == snackId);
            return View(snack);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Snack> snacks;
            string actualCategory = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                snacks = _snackRepository.Snacks.OrderBy(p => p.SnackId);
                actualCategory = "All snacks";
            }
            else
            {
                snacks = _snackRepository.Snacks
                          .Where(p => p.Name.ToLower().Contains(searchString.ToLower()));

                if (snacks.Any())
                    actualCategory = "Results for: " + searchString.ToUpper();
                else
                    actualCategory = "No snacks found";
            }

            return View("~/Views/Snack/List.cshtml", new SnackListViewModel
            {
                Snacks = snacks,
                ActualCategory = actualCategory
            });
        }

    }
}
