using System;
using System.ComponentModel.DataAnnotations;

namespace GrpcCodeFirst.Shared.DTO
{
    public class ConferenceDetails
    {
        public Guid ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required] 
        public DateTime DateFrom { get; set; }

        [Required] 
        public DateTime DateTo { get; set; }

        [Required] 
        public string Country { get; set; }

        [Required] 
        public string City { get; set; }

        public string Url { get; set; }
    }
}
