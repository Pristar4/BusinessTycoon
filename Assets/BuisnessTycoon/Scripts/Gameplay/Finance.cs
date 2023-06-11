#region Info
// -----------------------------------------------------------------------
// Finance.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
#endregion

namespace BT.Scripts.Gameplay {

  [Serializable]
  public class Finance {

    public Finance() {
      Balance = 0;
      Income = 0;
      Expense = 0;
      NetProfit = 0;
    }

    public decimal Balance { get; set; }
    public decimal Income { get; set; }
    public decimal Expense { get; set; }
    public decimal NetProfit { get; set; }

    public void CalculateExpensesAndProfits() {
      NetProfit = Income - Expense;

      Balance += NetProfit;





    }
  }
}