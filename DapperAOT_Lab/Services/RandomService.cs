﻿using Microsoft.Extensions.Configuration;

namespace DapperAOT_Lab.Services;

class RandomService(IConfiguration _config)
{
  public string GetRandomGuid()
  {
    // 測試 services injection
    Console.WriteLine($"{_config["OutputFolder"]}");

    return Guid.NewGuid().ToString();
  }
}