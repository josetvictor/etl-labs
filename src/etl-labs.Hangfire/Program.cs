using etl_labs.Hangfire.Domain.Interfaces;
using etl_labs.Hangfire.Integration;
using etl_labs.Hangfire.Integration.Interfaces;
using etl_labs.Hangfire.Jobs;
using etl_labs.Hangfire.Queue;

using Hangfire;
using Hangfire.Common;
using Hangfire.MemoryStorage;

using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inicio da configuração no service - HANGFIRE
builder.Services.AddHangfire(config => config.UseMemoryStorage());
// Fim da Configuração no service - HANGFIRE

// Configuração da injeção de dependencia de Jobs, Queues e Integrations
builder.Services.AddScoped<ITopFiveIntegration, TopFiveIntegration>();
builder.Services.AddScoped<ITopFiveQueue, TopFiveQueue>();
builder.Services.AddScoped<IJobTopFive, FiveJob>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Inicio da configuração no APP - HANGFIRE
app.UseHangfireServer();

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    AppPath = null,
    DashboardTitle = "Hangfire Dashboard Sample",
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            User = "dev",
            Pass = "123"
        },
    }
});
// Fim da configuração no App - HANGFIRE

// Execução do Job - Inicio

var jobFive = builder.Services.BuildServiceProvider().GetService<IJobTopFive>();

RecurringJob.AddOrUpdate(
    () => jobFive.StartJob(),
    Cron.Daily,
    TimeZoneInfo.Utc
);

// Execução do Job - Fim

app.MapControllers();

app.Run();
