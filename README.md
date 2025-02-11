# TodoApi - API para Gerenciamento de Tarefas

## Descrição

Este projeto é uma API simples para gerenciar tarefas (To-Do list), desenvolvida com **ASP.NET Core**. A API oferece operações CRUD (Criar, Ler, Atualizar e Deletar) para gerenciar uma lista de tarefas. Foi implementada com **Swagger** para facilitar a documentação e testes interativos da API.

## Funcionalidades

- **CRUD de Tarefas:** Permite adicionar, visualizar, atualizar e excluir tarefas.
- **Swagger:** Utiliza o Swagger para documentação interativa e fácil teste da API.
- **Injeção de Dependência:** Implementa o padrão de Injeção de Dependência (Dependency Injection).
- **Exemplo prático de API RESTful:** Estrutura simples e funcional para operações com recursos.

## Tecnologias

- **ASP.NET Core** - Framework principal para criação da API.
- **C#** - Linguagem de programação utilizada.
- **Swagger** - Para documentação e testes da API.
- **Dependency Injection** - Para gerenciamento de dependências e melhor organização do código.

## Como Rodar o Projeto

### Requisitos

- .NET SDK 6.0 ou superior
- Visual Studio ou qualquer editor de sua escolha (VS Code recomendado)
- Git (para versionamento e upload para o GitHub)

### Passos

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/NVanitas/TodoApi.git
   cd TodoApi
   ```

2. **Restaurar pacotes NuGet:**

   Caso tenha o **.NET SDK** instalado, basta rodar:

   ```bash
   dotnet restore
   ```

3. **Executar a API:**

   Para rodar o servidor local, utilize o comando:

   ```bash
   dotnet run
   ```

4. **Acessar a documentação do Swagger:**

   Abra seu navegador e vá para:

   ```
   http://localhost:5000
   ```

   A interface do **Swagger** estará disponível para você testar os endpoints interativamente.

## Endpoints

### GET /api/tasks
- **Descrição:** Retorna todas as tarefas.
- **Resposta:** Lista de tarefas.

### GET /api/tasks/{id}
- **Descrição:** Retorna uma tarefa específica pelo `id`.
- **Resposta:** Tarefa com o ID fornecido.

### POST /api/tasks
- **Descrição:** Adiciona uma nova tarefa.
- **Corpo da requisição:** Um objeto JSON contendo a descrição da tarefa.
  
### PUT /api/tasks/{id}
- **Descrição:** Atualiza uma tarefa existente.
- **Corpo da requisição:** Um objeto JSON com as novas informações da tarefa.

### DELETE /api/tasks/{id}
- **Descrição:** Deleta uma tarefa pelo `id`.
- **Resposta:** Status da operação.

## Testes Unitários

Este projeto possui testes unitários utilizando **xUnit** para garantir a confiabilidade das funcionalidades.

### Como Rodar os Testes

1. Navegue até a pasta raiz do projeto:
   ```sh
   cd TodoApi
   ```
2. Execute os testes com o comando:
   ```sh
   dotnet test
   ```

### Exemplo de Teste

Os testes seguem o padrão **Arrange, Act, Assert**.

```csharp
[Fact]
public void AddTask_DeveAdicionarTarefaNaLista()
{
    // Arrange
    var service = new TodoService();
    var task = new Todo { Name = "Nova Tarefa", Done = false };

    // Act
    service.AddTask(task);
    var result = service.GetAll();

    // Assert
    Assert.Contains(task, result);
}
```

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir **issues** ou enviar **pull requests** para melhorias no projeto.

## Licença

Distribuído sob a licença MIT. Veja a [LICENSE](LICENSE) para mais informações.

## Autor

**Nicolas da Silva Santos**  
GitHub: [@NVanitas](https://github.com/NVanitas)  
E-mail: [nicolasdasilvasantos04@gmail.com](mailto:nicolasdasilvasantos04@gmail.com)

