using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Models
{
    public class DeliveryAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public string? LandMark { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(50)]
        public string? State { get; set; }
        [StringLength(10)]
        public string? PostalCode { get; set; }
        [Required]
        public string? CustomerId { get; set; }
        public virtual User? Customer { get; set; }
    }
}
