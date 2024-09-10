using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        [Required]
        public string? Status { get; set; }
    }
}
