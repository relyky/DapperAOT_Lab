using Dapper;
using DBHelper;
using Microsoft.Extensions.Configuration;

namespace DapperBiz;

class DapperTestBiz(IConfiguration _config)
{
  public async Task TestDapperAsync()
  {
    string connString = _config.GetConnectionString("DefaultConnection");
    Console.WriteLine($"連線字串: {connString}");

    var proxy = new ConnProxy(connString);
    //using var conn = new SqlConnection(connString);   
    //await conn.OpenAsync();

    var conn = await proxy.OpenAsync();
    Console.WriteLine($"開啟連線");

    const string sql = "SELECT TOP 1 * FROM MyData";
    var info = conn.QueryFirst<MyData>(sql);
    Console.WriteLine(info);
  }
}

record MyData
{
  public long SN { get; set; }
  public string IDN { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public decimal Amount { get; set; }
  public DateTime? Birthday { get; set; }
  public string? Remark { get; set; }
}