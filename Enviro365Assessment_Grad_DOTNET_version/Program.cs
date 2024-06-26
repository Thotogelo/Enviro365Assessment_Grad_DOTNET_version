using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Exceptions;
using Enviro365Assessment_Grad_DOTNET_version.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen(c 
    => { c.SwaggerDoc("v1", new() { Title = "Environment Data API", Version = "v1" }); });
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

app.MapControllers();

app.Run();