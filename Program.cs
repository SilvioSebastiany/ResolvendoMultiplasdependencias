using DependencyInjectionLifetimeSample.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.TryAddTransient<IService, SecondaryService>();
//builder.Services.TryAddTransient<IService, PrimaryService>();
//builder.Services.TryAddTransient<IService, PrimaryService>();
//builder.Services.TryAddTransient<IService, SecondaryService>();
//builder.Services.AddTransient<IService, TertiaryService>();

builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IService, PrimaryService>());
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IService, PrimaryService>());




var app = builder.Build();

app.MapGet("/", (IEnumerable<IService> services) 
    => Results.Ok(services.Select(s => s.GetType().Name)));

app.Run();

public interface IService
{
}