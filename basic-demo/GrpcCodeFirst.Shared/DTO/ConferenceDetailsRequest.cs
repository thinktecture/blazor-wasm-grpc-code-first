using ProtoBuf;
using System;

namespace GrpcCodeFirst.Shared.DTO
{
    [ProtoContract]
    public class ConferenceDetailsRequest
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
    }
}