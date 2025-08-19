using Microsoft.EntityFrameworkCore;
using server_tic_tac_toe.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a connection string diretamente na configuração
builder.Configuration.AddEnvironmentVariables();

var connectionString = 
    $"Host={builder.Configuration["POSTGRES_DB_HOST"]};" +
    $"Port={builder.Configuration["POSTGRES_DB_PORT"]};" +
    $"Database={builder.Configuration["POSTGRES_DB_NAME"]};" +
    $"Username={builder.Configuration["POSTGRES_DB_USER"]};" +
    $"Password={builder.Configuration["POSTGRES_DB_PASSWORD"]}";

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
