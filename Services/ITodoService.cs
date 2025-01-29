using TodoApi.Models;
namespace TodoApi.Services
{
    public interface ITodoService
    {
        List<Todo> GetAll();
        Todo? GetById(int id);
        void AddTask(Todo task);
        void UpdateTask(int id , Todo task);
        void DeleteTask(int id);
    }
}
