using Microsoft.OpenApi.Models;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao container de dependências (Dependency Injection)
builder.Services.AddSingleton<ITodoService, TodoService>(); // Serviço de tarefas
builder.Services.AddControllers(); // Adiciona suporte a Controllers
builder.Services.AddEndpointsApiExplorer(); // Habilita descoberta de endpoints para APIs minimalistas

// Configuração do Swagger para documentação da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Version = "v1",
        Description = "Uma API para gerenciar tarefas",
        Contact = new OpenApiContact
        {
            Name = "Nicolas da Silva Santos",
            Email = "nicolasdasilvasantos04@gmail.com",
            Url = new Uri("https://github.com/NVanitas")
        }
    });
});

var app = builder.Build();

// Configuração do Swagger (somente em ambiente de desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");
        c.RoutePrefix = string.Empty; // Swagger acessível na raiz do app
    });
}

app.UseAuthorization(); // Middleware de autorização (caso precise no futuro)

app.MapControllers(); // Mapeia os controllers para os endpoints da API

app.Run(); // Inicia a aplicação
