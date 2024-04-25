using Cocona;
using DapperBiz;

namespace DapperAOT_Lab;

class DapperTestCommand(DapperTestBiz bizSvc)
{
  [Command("conn", Description = "測試 Dapper.ATO。")]
  public async Task ConnDB()
  {
    await bizSvc.TestDapperAsync();
  }
}

