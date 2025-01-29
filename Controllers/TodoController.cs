using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService; // ✅ Correção da injeção de dependência

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public ActionResult<List<Todo>> GetAll() => _todoService.GetAll();

    [HttpGet("{id}")] // ✅ Adicionando a rota correta para buscar por ID
    public ActionResult<Todo> GetById(int id)
    {
        var task = _todoService.GetById(id);
        if (task == null) return NotFound();
        return task;
    }

    [HttpPost]
    public IActionResult AddTask(Todo task)
    {
        _todoService.AddTask(task);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, Todo task)
    {
        var exists = _todoService.GetById(id);
        if (exists == null) return NotFound();
        _todoService.UpdateTask(id, task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id) // ✅ Retornando IActionResult para manter padrão
    {
        var exists = _todoService.GetById(id);
        if (exists == null) return NotFound();
        _todoService.DeleteTask(id); // ✅ Corrigindo nome do método
        return NoContent();
    }
}
