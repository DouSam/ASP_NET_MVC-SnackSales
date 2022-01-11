using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesC.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Inform the name.")]
        [StringLength(50, ErrorMessage = "The name cannot pass the maximum(50) length.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inform the surname.")]
        [StringLength(50, ErrorMessage = "The surname cannot pass the maximum(50) length.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Inform the address.")]
        [StringLength(100, ErrorMessage = "The address cannot pass the maximum(100) lenght.")]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Inform the address complement.")]
        [StringLength(100, ErrorMessage = "The address complement cannot pass the maximum(100) lenght.")]
        [Display(Name = "Address Complement")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Inform the Zip Code.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "The Zip Code cannot pass the maximum(10) lenght.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Inform the state.")]
        [StringLength(20, ErrorMessage = "The state cannot pass the maximum(20) lenght.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Inform the city.")]
        [StringLength(25, ErrorMessage = "The city name cannot pass the maximum(25) lenght.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Inform the cellphone number.")]
        [StringLength(13, ErrorMessage = "The cellphone cannot pass the maximum(13) lenght.")]
        [Display(Name = "Cellphone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "Inform the e-mail.")]
        [StringLength(50, ErrorMessage = "The e-mail cannot pass the maximum(50) lenght.")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Total of Itens")]
        public int OrderItensTotal { get; set; }

        [Display(Name = "Date of order")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateOrder { get; set; }

        [Display(Name = "Date of delivery")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateDelivery { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
