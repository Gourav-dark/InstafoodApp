using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Models
{
    public class Order
    {
        [Key]
        [StringLength(10)]
        public string? OrderId { get; set; }
        [Required]
        public string? CustomerId { get; set; }
        public virtual User? Customer { get; set; }
        public DateOnly OrderDate { get; set; }=DateOnly.FromDateTime(DateTime.Now);
        public TimeOnly OrderTime { get; set; }=TimeOnly.FromDateTime(DateTime.Now);
        [Required]
        public float TotalCost { get; set; }
        public int OrderStatusId { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
    }
}
