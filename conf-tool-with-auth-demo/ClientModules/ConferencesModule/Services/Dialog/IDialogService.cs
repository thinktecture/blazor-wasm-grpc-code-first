using System.Threading.Tasks;

namespace ConfTool.ClientModules.Conferences.Services
{
    public interface IDialogService
    {
        Task<bool> ConfirmAsync(string message);
        Task AlertAsync(string message);
    }
}
