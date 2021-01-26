using GrpcCodeFirst.Shared.Interfaces;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Api.GrpcServices
{
    public class TimeService : ITimeService
    {
        public IAsyncEnumerable<TimeResult> SubscribeAsync(CallContext context = default)
            => SubscribeAsyncImpl(context.CancellationToken);

        private async IAsyncEnumerable<TimeResult> SubscribeAsyncImpl([EnumeratorCancellation] CancellationToken cancel)
        {
            while (!cancel.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), cancel);
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                yield return new TimeResult { Time = DateTime.UtcNow };
            }
        }
    }
}
