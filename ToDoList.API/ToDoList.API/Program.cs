using ToDoList.Application;
using ToDoList.Infrastructure;
using ToDoList.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(cfg =>
    {
        cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoList API v1");
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.InitializeDatabase();
if (app.Environment.IsDevelopment())
{
    await app.SeedDatabase();
}

app.Run();
