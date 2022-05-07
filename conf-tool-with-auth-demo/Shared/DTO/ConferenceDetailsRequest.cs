using System;
using System.Runtime.Serialization;

namespace ConfTool.Shared.DTO
{
    [DataContract]
    public class ConferenceDetailsRequest
    {
        [DataMember(Order = 1)]
        public Guid ID { get; set; }
    }
}