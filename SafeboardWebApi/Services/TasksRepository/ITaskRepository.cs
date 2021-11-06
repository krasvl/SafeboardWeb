using System.Threading.Tasks;

namespace SafeboardWebApi.Services.TasksRepository
{
    public interface ITaskRepository
    {
        void Add(Task<string[]> task);
        string[] GetResult(int id);
        bool IsCompleted(int id);
    }
}