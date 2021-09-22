using System;
using System.Runtime.Serialization;

namespace GrpcCodeFirst.Shared.DTO
{
    [DataContract]
    public class ConferenceOverview
    {
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        [DataMember(Order = 2)]
        public string Title { get; set; }
    }
}
