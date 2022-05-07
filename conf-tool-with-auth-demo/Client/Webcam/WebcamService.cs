using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ConfTool.Client.Webcam
{
    public class WebcamService : IWebcamService, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public WebcamService(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./jsinterop/webcam.js").AsTask());
        }

        public async Task StartVideoAsync(WebcamOptions options)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("startVideo", options);
        }

        public async Task TakePictureAsync()
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("takePicture");
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
