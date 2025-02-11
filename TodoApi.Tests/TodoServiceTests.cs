using TodoApi.Models;
using TodoApi.Services;
using Xunit;

namespace TodoApi.TodoApi.Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public void AddTask_DeveAdicionarTarefaNaLista()
        {
            //Arrange
            var service = new TodoService();
            var task = new Todo { Name = "Nova Tarefa ", Done = false };

            //Act
            service.AddTask(task);
            var result = service.GetAll();

            //Assert
            Assert.Contains(task, result);
        }
        [Fact]
        public void UpdateTask_DeveAtualizarTarefa()
        {
            // Arrange
            var service = new TodoService();
            var task = new Todo { Name = "Tarefa Antiga", Done = false };
            service.AddTask(task);

            var updatedTask = new Todo { Name = "Tarefa Atualizada", Done = true };

            // Act
            service.UpdateTask(task.Id, updatedTask);
            var result = service.GetById(task.Id); // 🔥 Pegando a tarefa correta

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Tarefa Atualizada", result?.Name); // 🔥 Corrigindo a verificação
            Assert.True(result?.Done);
        }

        [Fact]
        public void DeleteTask_DeveRemoverTarefaDaLista()
        {
            // Arrange
            var service = new TodoService();
            var task = new Todo { Name = "Tarefa para deletar", Done = false };
            service.AddTask(task);

            // Act
            service.DeleteTask(task.Id);
            var result = service.GetAll();

            // Assert
            Assert.DoesNotContain(task, result);
        }


    }
}
