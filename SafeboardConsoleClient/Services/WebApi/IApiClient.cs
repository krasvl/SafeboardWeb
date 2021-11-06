using System.Threading.Tasks;

namespace SafeboardConsoleClient.Services.WebApi
{
    interface IApiClient
    {
        Task<string> CreateScanTaskAsync(string directoryPath);
        Task<string[]> GetScanTaskStatusAsync(int taskId);
        Task<string> GetServerStatusAsync();
    }
}