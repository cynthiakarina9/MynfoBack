using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MynfoBack.Models
{
    public class DeviceUser
    {
        [Key]
        public int DeviceUserID { get; set;}

        [StringLength(10,ErrorMessage = "The field {0} most contain between {2} and {1} charactes", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the fiel {0}")]
        [Display(Name = "NickName")]
        public string NickName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} most contain between {2} and {1} charactes", MinimumLength = 3)]
        [Required(ErrorMessage = "You must enter the fiel {0}")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} most contain between {2} and {1} charactes", MinimumLength = 5)]
        [Required(ErrorMessage = "You must enter the fiel {0}")]
        [Display(Name = "SecondName")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "The field {0} most contain between {2} and {1} charactes", MinimumLength = 4)]
        [Required(ErrorMessage = "You must enter the fiel {0}")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}