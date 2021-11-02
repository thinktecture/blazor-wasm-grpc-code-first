using ProtoBuf;
using System;

namespace GrpcCodeFirst.Shared.DTO
{
    [ProtoContract]
    public class ConferenceOverview
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public string Title { get; set; }
    }
}
