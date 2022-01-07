using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage = "Please, inform the name of the category.")]
        [Display(Name = "Nome")]
        public string CategoryName { get; set; }

        [StringLength(200, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Required(ErrorMessage = "Please, inform the description of the category.")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public List<Snack> Snacks { get; set; }
    }
}
