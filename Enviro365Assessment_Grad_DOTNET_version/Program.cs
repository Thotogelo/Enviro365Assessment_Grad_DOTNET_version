var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Enviro365 Environment API V1");
    opt.RoutePrefix = string.Empty;
    opt.DocumentTitle = "Enviro365 Environment API";
});

app.MapControllers();

app.MapGet("/test", () => "Hello World!");

app.Run();