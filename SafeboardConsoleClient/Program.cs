using SafeboardConsoleClient.Services.WebApi;
using System;
using System.Threading.Tasks;

namespace SafeboardConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IApiClient apiClient = new ApiClient();

            Console.WriteLine("To get server status enter: scan_service");
            Console.WriteLine("To scan directory enter: scan_util_scan 'path' ");
            Console.WriteLine("To get scan task status enter: scan_util_status 'task_id' ");
            Console.WriteLine("To exit enter: 0 ");
            Console.WriteLine("========================================================");

            while (true)
            {
                var arr = Console.ReadLine().Split(" ");
                string action = arr[0]; ;
                string data = "";

                if (arr.Length > 1)
                    data = arr[1];

                if (action == "scan_util_scan")
                {
                    if (string.IsNullOrWhiteSpace(data))
                    {
                        Console.WriteLine("Enter path to directory");
                    }
                    else
                    {
                        var response = await apiClient.CreateScanTaskAsync(data);

                        Console.WriteLine(response);
                    }
                }
                else if(action == "scan_util_status")
                {
                    int id;
                    if(int.TryParse(data, out id))
                    {
                        var response = await apiClient.GetScanTaskStatusAsync(id);
                        Array.ForEach(response, r => Console.WriteLine(r));
                    }
                    else
                    {
                        Console.WriteLine("task id must be number");
                    }
                }
                else if(action == "scan_service")
                {
                    Console.WriteLine(await apiClient.GetServerStatusAsync());
                }
                else if (action == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect action");
                }
            }
        }

    }
}
