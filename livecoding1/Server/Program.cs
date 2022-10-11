using BlazorGrpc.Server;
using BlazorGrpc.Server.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// for macOS
#if DEBUG
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5050, o => o.Protocols =
        HttpProtocols.Http2);
    options.ListenLocalhost(5051, o => o.Protocols =
        HttpProtocols.Http1AndHttp2);
});
#endif

builder.Services.AddScoped<WeatherForecastService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

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

app.MapRazorPages();
app.MapControllers();

app.MapGrpcService<MyWeatherForecastGrpcService>();
app.MapGrpcReflectionService();

app.MapFallbackToFile("index.html");

app.Run();