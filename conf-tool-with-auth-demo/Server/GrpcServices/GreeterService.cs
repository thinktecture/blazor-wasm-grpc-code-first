﻿using System.Threading.Tasks;
using Grpc.Core;
using GrpcGreeter;

namespace ConfTool.Server.GrpcServices
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
