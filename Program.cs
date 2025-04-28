using DependencyInjectionLifetimeSample.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IService, PrimaryService>();

var app = builder.Build();

app.MapGet("/", (IService s) => Results.Ok(s.GetType().Name));

app.Run();

public interface IService
{
}