using GrpcCodeFirst.Api.GrpcServices;
using GrpcCodeFirst.Api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProtoBuf.Grpc.Server;
using System;
using System.IO.Compression;

namespace GrpcCodeFirst.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ConferencesDbContext>(
                options => options.UseInMemoryDatabase(databaseName: "BlazorWasmGrpcCodeFirst"));

            services.AddGrpc();
            services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = CompressionLevel.Optimal; });
            services.AddCodeFirstGrpcReflection();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlazorWASMGrpcCodeFirst", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConferencesDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorWASMGrpcCodeFirst v1"));
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseGrpcWeb();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ConferenceServiceContractFirst>();
                endpoints.MapGrpcService<ConferenceService>().EnableGrpcWeb();
                endpoints.MapGrpcService<TimeService>().EnableGrpcWeb();

                endpoints.MapCodeFirstGrpcReflectionService();

                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            DataGenerator.Initialize(dbContext);
        }
    }
}
