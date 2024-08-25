using PrintManager.Application;
using PrintManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
}

var app = builder.Build();
{
    
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}