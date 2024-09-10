using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Models
{
    public class CartItem
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string? CustomerId { get; set; }
        public virtual User? Customer { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
