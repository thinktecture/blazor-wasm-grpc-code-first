using BlazorWasmGrpcCodeFirst.Server.GrpcServices;
using Microsoft.AspNetCore.ResponseCompression;
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
});
#endif

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
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

app.UseRouting();

app.UseGrpcWeb();

app.MapRazorPages();
app.MapControllers();

app.MapGrpcService<WeatherService>();
app.MapGrpcService<WeatherForecastService>().EnableGrpcWeb();

app.MapFallbackToFile("index.html");

app.Run();