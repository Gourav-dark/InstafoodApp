using System.ComponentModel.DataAnnotations;

namespace InstafoodApp.Web.Client.DTO
{
    public class DeliveryAddressDTO
    {
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Street { get; set; }
        public string? LandMark { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? PostalCode { get; set; }
        public string CustomerId { get; set; }
    }
}
