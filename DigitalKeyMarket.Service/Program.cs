using DigitalKeyMarket.Service.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();