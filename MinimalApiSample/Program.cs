using Microsoft.EntityFrameworkCore;
using MinimalApiSample.DataDb;
using MinimalApiSample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));


builder.Services.AddDbContext<MovieMVCrud>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MovieMVCrud")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Creando Apis 
//app.MapGet("/todoitems", async (TodoDb db) =>
//    await db.Todos.ToListAsync())
//        .WithName("ShowAllItems");

//app.MapGet("/todoitemsIs", async (TodoDb db) =>
//{
//    await db.Todos
//    .Where(x => x.IsComplete == true)
//    .ToListAsync();
//});
//app.MapPost("TodoPost", async (AllItems todo, TodoDb db) =>
//{
//    db.Todos.Add(todo);
//    await db.SaveChangesAsync();
//    return Results.Created($"/todoitems{todo.Id}", todo);
//});
//app.MapGet("JustId/{id}", async (int id, TodoDb db) =>
//    await db.Todos.FindAsync(id)
//    is AllItems todo
//    ? Results.Ok(todo)
//    : Results.NotFound());

//app.MapDelete("DeleteItem/{id}", async (int id, TodoDb db) =>
//{
//    if (await db.Todos.FindAsync(id) is AllItems item)
//    {
//        db.Todos.Remove(item);
//        await db.SaveChangesAsync();
//        return Results.Ok(item);
//    }
//    return Results.NotFound();
//});

//app.MapPut("ChangeData/{id}", async (int id, AllItems imputTodo, TodoDb db) =>
//{
//    var item = await db.Todos.FindAsync(id);
//    if (item is null) return Results.NotFound();

//    item.IsComplete = imputTodo.IsComplete;
//    item.Name = imputTodo.Name;
//    await db.SaveChangesAsync();
//    return Results.NoContent();
//});
app.MapGet("/ComeHere", () => "Hello Apis");
// Test Apis
app.Run();
