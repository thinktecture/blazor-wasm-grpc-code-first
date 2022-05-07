using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrpcCodeFirst.Shared.DTO
{
    [ProtoContract]
    public class ConferenceDetails
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        [Required]
        public string Title { get; set; }

        [ProtoMember(3)]
        [Required]
        public DateTime DateFrom { get; set; }

        [ProtoMember(4)]
        [Required]
        public DateTime DateTo { get; set; }

        [ProtoMember(5)]
        [Required]
        public string Country { get; set; }

        [ProtoMember(6)]
        [Required]
        public string City { get; set; }

        [ProtoMember(7)]
        public string Url { get; set; }
    }
}
