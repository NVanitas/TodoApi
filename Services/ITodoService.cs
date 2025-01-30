using TodoApi.Models;

namespace TodoApi.Services
{
    // Interface que define os métodos essenciais para o serviço de gerenciamento de tarefas.
    public interface ITodoService
    {
        // Método para obter todas as tarefas.
        List<Todo> GetAll();

        // Método para obter uma tarefa pelo seu ID.
        Todo? GetById(int id);

        // Método para adicionar uma nova tarefa.
        void AddTask(Todo task);

        // Método para atualizar uma tarefa existente.
        void UpdateTask(int id, Todo task);

        // Método para remover uma tarefa com base no ID.
        void DeleteTask(int id);
    }
}
