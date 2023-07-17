using Microsoft.EntityFrameworkCore;
using UserService.Host.Routes;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<UserContext>(b => b.UseNpgsql(connectionString));

builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);
builder.Services.AddBusinessLogic2(builder.Configuration, connectionString!);
builder.Services.AddBusinessLogic3(builder.Configuration, connectionString!);
builder.Services.AddBusinessLogic4(builder.Configuration, connectionString!);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddUserRouter();
app.AddMessageRouter();
app.AddChatRouter();
app.AddNotificationRouter();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();