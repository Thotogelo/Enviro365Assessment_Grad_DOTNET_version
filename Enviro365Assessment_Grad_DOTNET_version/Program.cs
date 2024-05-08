using Enviro365Assessment_Grad_DOTNET_version;
using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Repository;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddProblemDetails();

// Logging Services
builder.Logging.AddConsole();

//Add DI
builder.Services.AddTransient<DataContext>();
builder.Services.AddTransient<WasteRepository>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Enviro365 Environment API V1");
    opt.RoutePrefix = string.Empty;
    opt.DocumentTitle = "Enviro365 Environment API";
});

// Use the custom error handler middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

// app.MapGet("/demo", (Exception e) => { throw new WasteErrorException();});
app.MapControllers();

app.Run();