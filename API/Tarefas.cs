using NSwag.AspNetCore;
using Tarefas.Data;
using Tarefas.Models;

class WebAPI
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "ListaTarefas";
            config.Title = "ListaTarefas v1";
            config.Version = "v1";
        });

        //Da classe WebApplication, instancie um objeto APP
        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi(config =>
            {
                config.DocumentTitle = "ListaTarefas API";
                config.Path = "/swagger";
                config.DocumentPath = "/swagger/{documentName}/swagger.json";
                config.DocExpansion = "list";
            });
        }

        app.MapGet("/api/listaTarefas", (DataContext context) =>
            {
                var listaTarefas = context.ListaTarefas;
                return listaTarefas is not null ? Results.Ok(listaTarefas) : Results.NotFound();

            }
        ).Produces<ListaTarefas>();

        app.MapPost("/api/listaTarefas", (DataContext context, string novaTarefa) =>
            {
                var tarefa = new ListaTarefas(Guid.NewGuid(), novaTarefa, false);

                context.ListaTarefas.Add(tarefa);
                context.SaveChanges();

                return Results.Ok();
            }
        ).Produces<ListaTarefas>();

        app.MapPut("/api/listaTarefas", (DataContext context, ListaTarefas novaTarefa) =>
            {

                var tarefa = context.ListaTarefas.Find(novaTarefa.Id);
                if (tarefa is null) return Results.NotFound();

                var entry = context.Entry(tarefa).CurrentValues;

                entry.SetValues(novaTarefa);

                context.SaveChanges();

                return Results.Ok(tarefa);  
            }
        ).Produces<ListaTarefas>();

        app.MapDelete("/api/listaTarefas", (DataContext context, Guid Id) =>
            {
                var tarefa = context.ListaTarefas.Find(Id);

                if(tarefa is null) return Results.NotFound();

                context.ListaTarefas.Remove(tarefa);
                context.SaveChanges();
                return Results.Ok(tarefa);
            }
        ).Produces<ListaTarefas>();

        app.Run();
    }

}

