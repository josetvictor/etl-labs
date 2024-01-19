using Hangfire;
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

app.MapControllers();

app.Run();
