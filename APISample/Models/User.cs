using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "User Login ID")]
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string UserID { get; set; }
        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string UserPwd { get; set; }

    }
}
