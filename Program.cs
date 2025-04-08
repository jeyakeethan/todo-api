using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
// Load environment variables from .env file
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
    Env.Load();

var connectionString = $"server={Environment.GetEnvironmentVariable("MYSQL_HOST")};" +
                       $"port={Environment.GetEnvironmentVariable("MYSQL_PORT")};" +
                       $"database={Environment.GetEnvironmentVariable("MYSQL_DATABASE")};" +
                       $"user={Environment.GetEnvironmentVariable("MYSQL_USER")};" +
                       $"password={Environment.GetEnvironmentVariable("MYSQL_PASSWORD")};";
Console.WriteLine(connectionString);

// Add database connection
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 41)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure()
    )
);

// Register your TodoService here
builder.Services.AddScoped<TodoService>(); // Registers the service in DI container

// Add controllers (API controllers)
builder.Services.AddControllers();

// Optionally, add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors headers to responses
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
   {
       policy.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
   });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // This enables the Swagger UI
}

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    Thread.Sleep(3000);
    var context = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
    context.Database.EnsureCreated(); // Ensure the table is created
}

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Map API endpoints
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
