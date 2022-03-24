using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using NL.Serverless.AspNetCore.AzureFunctionsHost;
using System.Threading.Tasks;

namespace MudBlazorDemoWasm.FunctionApp
{
    /// <summary>
    /// Proxy function to delegate incoming http request to web app.
    /// </summary>
    public class WebAppProxyFunction : WebAppProxyFunctionBase
    {
        public WebAppProxyFunction(IFunctionsRequestHandler requestHandler) : base(requestHandler)
        {
        }

        [Function("WebAppProxyFunction")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", "patch", "delete", "options", Route = "{*any}")] HttpRequestData req,
            FunctionContext context)
        {
            return await ProcessRequestAsync(req, context.GetLogger<WebAppProxyFunction>());
        }
    }
}
