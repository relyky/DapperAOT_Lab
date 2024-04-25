using Cocona;
using DapperAOT_Lab.Services;
using DapperAOT_Lab;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DapperBiz;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var builder = CoconaApp.CreateBuilder();

builder.Services.AddScoped<RandomService>();
builder.Services.AddScoped<DapperTestBiz>();

var app = builder.Build();

// 主要指令。※只能有一個。
app.AddCommand((
  [Option("first", Description = "這是前名稱。")] string firstname,
  [Option("last", Description = "這是後名稱。")] string? lastname) =>
  Console.WriteLine($"哈囉 {firstname} {lastname}。"));

// Command 指令。Class-based style。
app.AddCommands<GreetingCommand>();

// Command 指令。Class-based style。
app.AddCommands<DapperTestCommand>();

app.Run();