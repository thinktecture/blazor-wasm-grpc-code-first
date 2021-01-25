using Grpc.Net.Client;
using GrpcCodeFirst.Api.GrpcServices.Interfaces;
using System;

namespace GrpcCodeFirst.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a key!");
            Console.ReadKey();

            Console.WriteLine("Calling gRPC service...");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ConferenceService.ConferenceServiceClient(channel);

            var confs = client.ListConferences(new ListConferencesRequest());
            Console.WriteLine(confs.Conferences.Count);

            Console.ReadLine();
        }
    }
}
