using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Models
{
    public class User
    {
        [Key]
        [StringLength(10)]
        public string UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [StringLength(10)]
        public string? Role { get; set; }   
    }
}
