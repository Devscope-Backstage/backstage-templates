using Microsoft.EntityFrameworkCore;
using ${{values.name}}.Models;
using Prometheus;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "${{values.name}}", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "${{values.name}} v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();