using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(200)]
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        public string? ProductPicture { get; set; }

        public bool IsAvailable { get; set; }=true;
    }
}
