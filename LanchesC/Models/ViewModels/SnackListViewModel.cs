using System.Collections.Generic;

namespace LanchesC.Models.ViewModels
{
    public class SnackListViewModel
    {
        public IEnumerable<Snack> Snacks { get; set; }
        public string ActualCategory { get; set; }
    }
}
