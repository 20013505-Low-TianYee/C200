using System;
using System.ComponentModel.DataAnnotations;

namespace _4Shapes.Models
{
    public class Staff
    {
        [Required(ErrorMessage = "Please enter Staff ID")]
        public string StaffID { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FullName { get; set; }
        public string UserRole { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
