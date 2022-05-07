using System;
using ConfTool.Shared.Contracts;
using ProtoBuf.Grpc.Reflection;

namespace ConfTool.Tools
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var generator = new SchemaGenerator();
            var schema = generator.GetSchema<IConferencesService>();

            Console.WriteLine("***ProtoBuf Schema***: \n\n" + schema);
        }
    }
}
