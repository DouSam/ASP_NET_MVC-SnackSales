using LanchesC.Models;
using LanchesC.Models.ViewModels;
using LanchesC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public HomeController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredSnacks = _snackRepository.PreferredSnacks
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
            });
        }
    }
}
