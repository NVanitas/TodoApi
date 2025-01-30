using TodoApi.Models;

namespace TodoApi.Services
{
    // Serviço de gerenciamento de tarefas (CRUD) para a lista de "Todo".
    public class TodoService : ITodoService
    {
        // Lista interna que armazena as tarefas.
        private readonly List<Todo> _todoList = new();

        // Método que retorna todas as tarefas.
        public List<Todo> GetAll() => _todoList;

        // Método que retorna uma tarefa pelo ID, se encontrada.
        public Todo? GetById(int id) => _todoList.FirstOrDefault(t => t.Id == id);

        // Método que adiciona uma nova tarefa à lista.
        public void AddTask(Todo task)
        {
            // Atribui um ID único para a nova tarefa com base na contagem da lista.
            task.Id = _todoList.Count + 1;
            _todoList.Add(task);
        }

        // Método que remove uma tarefa da lista com base no ID.
        public void DeleteTask(int id)
        {
            // Procura a tarefa pelo ID.
            var task = GetById(id);
            // Se a tarefa for encontrada, remove da lista.
            if (task != null)
            {
                _todoList.Remove(task);
            }
        }

        // Método que atualiza os detalhes de uma tarefa existente.
        public void UpdateTask(int id, Todo task)
        {
            // Verifica se a tarefa existe com o ID fornecido.
            var exists = GetById(id);
            // Se a tarefa existir, atualiza o nome e o status de concluído.
            if (exists != null)
            {
                exists.Name = task.Name;
                exists.Done = task.Done;
            }
        }
    }
}
