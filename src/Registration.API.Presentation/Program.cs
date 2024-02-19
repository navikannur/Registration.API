using FastEndpoints;
using FastEndpoints.Swagger;
using Registration.API.Application;
using Registration.API.Infrastructure.Database;
using Registration.API.Infrastructure.Repositories;
using Registration.API.Infrastructure.Services;
using Registration.API.Presentation;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Registration API";
            s.Version = "v1";
        };
    });

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
new SqliteConnectionFactory(config.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

//app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.UseFastEndpoints()
   .UseSwaggerGen(); //add this
app.Run();
