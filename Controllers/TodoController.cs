using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

// Controlador responsável pelas rotas relacionadas a tarefas (Todo).
[ApiController]
[Route("api/tasks")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService; // ✅ Correção da injeção de dependência

    // Construtor que recebe a dependência do serviço de tarefas.
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    // Endpoint para obter todas as tarefas.
    [HttpGet]
    public ActionResult<List<Todo>> GetAll() => _todoService.GetAll();

    // Endpoint para obter uma tarefa por ID.
    [HttpGet("{id}")] // ✅ Adicionando a rota correta para buscar por ID
    public ActionResult<Todo> GetById(int id)
    {
        var task = _todoService.GetById(id);
        if (task == null) return NotFound(); // Retorna 404 se a tarefa não for encontrada.
        return task; // Retorna a tarefa encontrada.
    }

    // Endpoint para adicionar uma nova tarefa.
    [HttpPost]
    public IActionResult AddTask(Todo task)
    {
        _todoService.AddTask(task); // Adiciona a tarefa ao serviço.
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task); // Retorna o status 201 com a URL da nova tarefa.
    }

    // Endpoint para atualizar uma tarefa existente.
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, Todo task)
    {
        var exists = _todoService.GetById(id);
        if (exists == null) return NotFound(); // Retorna 404 se a tarefa não for encontrada.
        _todoService.UpdateTask(id, task); // Atualiza a tarefa.
        return NoContent(); // Retorna 204 para indicar que a operação foi bem-sucedida, mas sem conteúdo.
    }

    // Endpoint para excluir uma tarefa por ID.
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id) // ✅ Retornando IActionResult para manter padrão
    {
        var exists = _todoService.GetById(id);
        if (exists == null) return NotFound(); // Retorna 404 se a tarefa não for encontrada.
        _todoService.DeleteTask(id); // Exclui a tarefa.
        return NoContent(); // Retorna 204 indicando que a tarefa foi excluída com sucesso.
    }
}
