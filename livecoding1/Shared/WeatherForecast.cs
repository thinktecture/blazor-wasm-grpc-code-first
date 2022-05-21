﻿using ProtoBuf;

namespace BlazorGrpc.Shared
{
    [ProtoContract]
    public class WeatherForecast
    {
        [ProtoMember(1)]
        public DateTime Date { get; set; }
        [ProtoMember(2)]
        public int TemperatureC { get; set; }
        [ProtoMember(3)]
        public string? Summary { get; set; }
    }
}
