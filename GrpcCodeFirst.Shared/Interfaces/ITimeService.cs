using GrpcCodeFirst.Shared.DTO;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using System.Collections.Generic;

namespace GrpcCodeFirst.Shared.Interfaces
{
    [Service]
    public interface ITimeService
    {
        IAsyncEnumerable<TimeResult> SubscribeAsync(CallContext context = default);
    }
}
