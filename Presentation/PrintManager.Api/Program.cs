using PrintManager.Api;
using PrintManager.Application;
using PrintManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(
            builder.Configuration.GetSection("Database"));
}

var app = builder.Build();
{    
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}