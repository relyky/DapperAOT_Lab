using Cocona;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
namespace DapperAOT_Lab;

/// <summary>
/// Dapper.AOT - Limitations and caveats
///     Dapper.AOT does not support all Dapper features; not all APIs are supported, 
/// and when an API is supported it might have limitations - for example, the 
/// generic APIs like Query<Foo> should work, but the non-generic API passing 
/// typeof(Foo) is not supported.The underlying implementation is completely 
/// separate to Dapper (and usually your code doesn’t even need Dapper once 
/// compiled); there may be subtle differences in how some things behave.
///     In particular, any Dapper configuration (including SqlMapper.Settings, 
/// ITypeHandler, etc) are not used; in many cases similar configuration is 
/// available via new Dapper.AOT markers.Please ask if you get stuck!
/// </summary>
class DapperTestCommand(IConfiguration _config)
{
  [Command("conn", Description = "測試 Dapper.ATO。")]
  public async Task ConnDB()
  {
    string connStr = _config.GetConnectionString("DefaultConnection");
    Console.WriteLine($"連線字串: {connStr}");

    using var conn = new SqlConnection(connStr);
    await conn.OpenAsync();
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
  public decimal Amount {  get; set; }
  public DateTime? Birthday {  get; set; }
  public string? Remark { get; set; }
}