using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVC_Data_Assignment1.Models
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*Please enter name*"), MaxLength(20)]
        [Display(Name = "Name")]
        public string PersonName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "*Please enter phonenumber*"), MaxLength(20)]
        [Display(Name = "PhoneNumber")]
        public string PersonPhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*Please enter city*"), MaxLength(20)]
        [Display(Name = "City")]
        public string PersonCity { get; set; }
    }
}
