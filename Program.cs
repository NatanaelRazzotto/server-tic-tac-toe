using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using server_tic_tac_toe.Infrastructure.Persistence;
using server_tic_tac_toe.Domain.Repositories;
using server_tic_tac_toe.Infrastructure.Repositories;
using server_tic_tac_toe.Application.Services;
using server_tic_tac_toe.Application.UseCases;
using System.Text.Json.Serialization;
using server_tic_tac_toe.Domain.Entities;

// Carrega o arquivo .env
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Adiciona variáveis de ambiente
builder.Configuration.AddEnvironmentVariables();

// Monta a connection string
var connectionString =
    $"Host={builder.Configuration["POSTGRES_DB_HOST"]};" +
    $"Port={builder.Configuration["POSTGRES_DB_PORT"]};" +
    $"Database={builder.Configuration["POSTGRES_DB_NAME"]};" +
    $"Username={builder.Configuration["POSTGRES_DB_USER"]};" +
    $"Password={builder.Configuration["POSTGRES_DB_PASSWORD"]}";

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var frontendUrl = builder.Configuration["APP_WEB_CLIENT"];
if (string.IsNullOrEmpty(frontendUrl))
{
    throw new InvalidOperationException("A variável FRONTEND_URL não está definida.");
}
// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificApp", policy =>
        policy
            .WithOrigins(frontendUrl)

            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});


// ===== Aqui registramos os repositórios e serviços =====
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGameMatchRepository, GameMatchRepository>();
builder.Services.AddScoped<IRepository<Move>, MoveRepository>();



//service
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GameMatchService>();
builder.Services.AddScoped<MoveService>();


// UseCases
builder.Services.AddScoped<CreateGameMatch>();
builder.Services.AddScoped<MakeMove>();
builder.Services.AddScoped<FinishGameMatch>();
builder.Services.AddScoped<CreateUser>();
builder.Services.AddScoped<UpdateUser>();

// Controllers + Swagger
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se você **não usa autenticação**, não precisa disso agora:
// builder.Services.AddAuthorization();

var app = builder.Build();

// Ativa CORS
app.UseCors("AllowSpecificApp");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// Não precisa de autenticação/authorization por enquanto
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
