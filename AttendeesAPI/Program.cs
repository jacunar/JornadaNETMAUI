using AttendeesAPI.Models;
using AttendeesAPI.Repository;
using NuGet.Protocol;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AttendeesContext>(builder.Configuration.GetConnectionString("AttendeesDb"));
builder.Services.AddScoped<AttendeesRepository>();
builder.Services.AddScoped<SessionAttendeeRepository>();
builder.Services.AddScoped<SessionRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/attendees", (AttendeesContext context) => context.Attendees.ToList());

app.UseHttpsRedirection();

app.Run();