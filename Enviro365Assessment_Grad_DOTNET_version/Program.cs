using Enviro365Assessment_Grad_DOTNET_version;
using Enviro365Assessment_Grad_DOTNET_version.Data;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddProblemDetails();

builder.Logging.AddConsole();

//Add DI
builder.Services.AddTransient<DataContext>();
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
// app.UseExceptionHandler(appError =>
// {
//     appError.Run(async ctx =>
//     {
//         ctx.Response.StatusCode = 500;
//         ctx.Response.ContentType = "application/json";

//         var ctxFeature = ctx.Features.Get<IExceptionHandlerFeature>();

//         if (ctxFeature is not null)
//         {
//             Console.WriteLine("Error: " + ctxFeature.Error);
//             await ctx.Response.WriteAsJsonAsync(new
//             {
//                 ctx.Response.StatusCode,
//                 Message = "Internal Server Error"
//             });

//         }
//     });
// });

app.MapGet("/demo", () =>
{
    throw new WasteError();
});

app.MapControllers();

app.Run();