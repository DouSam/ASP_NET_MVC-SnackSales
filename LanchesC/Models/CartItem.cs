using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesC.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Snack Snack { get; set; }

        public int Quantity { get; set; }

        [StringLength(200)]
        public string CartId { get; set; }
    }
}
