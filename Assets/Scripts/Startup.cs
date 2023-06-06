#region Info
// -----------------------------------------------------------------------
// Startup.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
namespace BT.Scripts {
  public class Startup {
    public Startup(string companyName) {
      CompanyName = companyName;
      Finance = new Finance();
    }

    public string CompanyName { get; private set; }
    public Finance Finance { get; private set; }

    public void RunTurn(Market market) {
      // Add logic for the startup's turn simulation
      
      // make every startup earn their net profit
      Finance.Balance += Finance.NetProfit;
    }
  }
}
