using System.Threading.Tasks;

namespace ConfTool.Client.Webcam
{
    public interface IWebcamService
    {
        Task StartVideoAsync(WebcamOptions options);
        Task TakePictureAsync();
    }
}
