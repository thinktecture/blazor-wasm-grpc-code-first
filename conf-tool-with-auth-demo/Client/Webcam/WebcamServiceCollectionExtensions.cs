using Microsoft.Extensions.DependencyInjection;

namespace ConfTool.Client.Webcam
{
    public static class WebcamServiceCollectionExtensions
    {
        public static IServiceCollection AddWebcam(this IServiceCollection services)
        {
            services.AddSingleton<IWebcamService, WebcamService>();

            return services;
        }
    }
}
