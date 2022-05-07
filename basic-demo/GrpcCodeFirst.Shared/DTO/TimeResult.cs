using ProtoBuf;
using System;

namespace GrpcCodeFirst.Shared.DTO
{
    [ProtoContract]
    public class TimeResult
    {
        [ProtoMember(1, DataFormat = DataFormat.WellKnown)]
        public DateTime Time { get; set; }
    }
}
