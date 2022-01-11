using System.Collections.Generic;

namespace LanchesC.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> PreferredSnacks { get; set; }
    }
}
