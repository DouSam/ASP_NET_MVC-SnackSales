using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Models
{
    public class Snack
    {
        public int SnackId { get; set; }
        public string Name { get; set; }
        public string ShotDescription { get; set; }
        public string DetailedDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }
        public bool IsPreferredSnack { get; set; }
        public bool InStock { get; set; }
    }
}
