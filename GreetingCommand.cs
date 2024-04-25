using Cocona;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAOT_Lab;

/// <summary>
/// 一個 Command class 建說只提供一個 commnd 指令。
/// </summary>
class GreetingCommand(IConfiguration _config)
{
  [Command("Greeting", Description = "打招呼。用 Class-based style 實作。")]
  public Task Greeting(
    [Option('n', Description = "指定名稱")] string name,
    [Option('h', Description = "說嘿")] bool hey)
  {
    Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {name ?? "來賓"}。");
    Console.WriteLine($"OutputFolder: {_config["OutputFolder"]}");
    return Task.CompletedTask;
  }

  /// <summary>
  /// 這不是 Command。要加 Ignore，不然 public method 預設都是 Command。
  /// </summary>
  [Ignore]
  public void DoSomething() { }

  /// <summary>
  /// 這不是 Command。不是 public method 就不會默認為 Command。
  /// </summary>
  void NotCommand() { }
}