using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<Todo> _todoList = new();

        public List<Todo> GetAll() => _todoList;

        public Todo? GetById(int id) => _todoList.FirstOrDefault(t => t.Id == id);

        public void AddTask(Todo task)
        {
            task.Id = _todoList.Count + 1;
            _todoList.Add(task);
        }

        public void DeleteTask(int id)
        {
            var task = GetById(id);
            if (task != null)
            {
                _todoList.Remove(task);
            }
        }
        public void UpdateTask(int id, Todo task)
        {
            var exists = GetById(id);
            if (exists != null) 
            {
            exists.Name = task.Name;
            exists.Done = task.Done;
                
            }
        }
    }
}
