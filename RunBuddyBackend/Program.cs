using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RunBuddyBackend.DataAccess;
using RunBuddyBackend.BusinessLogic;
using RunBuddyBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file in the RunBuddy-db directory
Env.Load("../RunBuddy-db/.env");

// Build the configuration
var env = builder.Configuration;
var connectionString = $"Host=db;Database={env["POSTGRES_DB"]};Username={env["POSTGRES_USER"]};Password={env["POSTGRES_PASSWORD"]}";

// Add the connection string to the in-memory configuration
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
{
    { "ConnectionStrings:DefaultConnection", connectionString }
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AppDbContext with PostgreSQL configuration
builder.Services.AddDbContext<RunBuddyContext>(options =>
    options.UseNpgsql(connectionString));

// Register services and repositories for dependency injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
