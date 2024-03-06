using etl_labs.API.Jobs;
using etl_labs.API.Repository;

using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITopFiveRepository, TopFiveRepository>();
builder.Services.AddHostedService<TopFiveJob>();

// Inicio da configuração no service - HANGFIRE
builder.Services.AddHangfire(config => config.UseMemoryStorage());
builder.Services.AddHangfireServer();
// Fim da Configuração no service - HANGFIRE

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Inicio da configuração no APP - HANGFIRE
app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    AppPath = null,
    DashboardTitle = "Hangfire Dashboard Sample teste"
});
// Fim da configuração no App - HANGFIRE

app.UseAuthorization();

app.MapControllers();

app.Run();
