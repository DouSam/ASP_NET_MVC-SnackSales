using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Models
{
    public class Snack
    {
        public int SnackId { get; set; }

        [Required(ErrorMessage = "The name must be informed.")]
        [Display(Name = "Name of Snack")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "The {0} must have minimal {1} and maximum {2} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} must be informed.")]
        [Display(Name = "Snack short description")]
        [MinLength(20, ErrorMessage = "Shot description must have minimal {1} characters.")]
        [MaxLength(200, ErrorMessage = "Short description cannot exceed {1} characters.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "The {0} must be informed.")]
        [Display(Name = "Detailed description")]
        [MinLength(20, ErrorMessage = "Detailed description must have minimal {1} characters.")]
        [MaxLength(200, ErrorMessage = "Detailed description cannot exceed {1} characters.")]
        public string DetailedDescription { get; set; }

        [Required(ErrorMessage = "Inform the snack price.")]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "The price must be between 1 and 999.99.")]
        public decimal Price { get; set; }

        [Display(Name = "Image Directory")]
        [StringLength(200, ErrorMessage = "The {0} must have in maximum {1} characters.")]
        public string ImageUrl { get; set; }

        [Display(Name = "Thumbnail Directory")]
        [StringLength(200, ErrorMessage = "The {0} must have in maximum {1} characters.")]
        public string ImageThumbUrl { get; set; }

        [Display(Name = "Preferred?")]
        public bool IsPreferredSnack { get; set; }

        [Display(Name = "Stock")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
