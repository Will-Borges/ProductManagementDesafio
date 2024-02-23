using DesafioAutoglass.Adapters.Persistence.Adapters.Configuration;
using DesafioAutoglass.Adapters.Persistence.Ioc;
using DesafioAutoglass.Automapper;
using DesafioAutoglass.Core.Application.Ioc;
using DesafioAutoglass.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Context Connection
builder.Services.AddSingleton<DapperContext>();

// Services
builder.Services.AddPersistenceRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddPortsPresenters();

builder.Services.AddAutoMapper(typeof(DesafioAutoglassProfile).Assembly);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
