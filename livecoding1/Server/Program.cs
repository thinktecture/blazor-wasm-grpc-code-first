using System.Runtime;
using BlazorGrpc.Server.Grpc;
using BlazorGrpc.Server.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5050, o => o.Protocols =
        HttpProtocols.Http2);
    options.ListenLocalhost(5051, o => o.Protocols =
        HttpProtocols.Http1AndHttp2);
    options.ListenLocalhost(5052, o => o.Protocols =
        HttpProtocols.Http1);
});
#endif

builder.Services.AddScoped<WeatherForecastService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.Services.AddCodeFirstGrpc();
builder.Services.AddCodeFirstGrpcReflection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseGrpcWeb();

app.MapCodeFirstGrpcReflectionService();
app.MapGrpcReflectionService();

app.MapGrpcService<MyWeatherForecastGrpcService>();
app.MapGrpcService<WeatherForecastFacade>().EnableGrpcWeb();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();