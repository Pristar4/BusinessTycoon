#region Info
// -----------------------------------------------------------------------
// Finance.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using UnityEngine;
#endregion

namespace BT.Scripts.Models {
  [Serializable]
  public class Finance {
    #region Serialized Fields
    [SerializeField] private float balanceView;
    [SerializeField] private float incomeView;
    [SerializeField] private float expenseView;
    [SerializeField] private float netProfitView;
    #endregion
    private decimal balance;
    private decimal expense;
    private decimal income;
    private decimal netProfit;
    public Finance() {
      Balance = 0;
      Income = 0;
      Expense = 0;
      NetProfit = 0;
    }

    public decimal Balance {
      get => balance;
      set {
        balance = value;
        balanceView = (float)balance;
      }
    }

    public decimal Income {
      get => income;
      set {
        income = value;
        incomeView = (float)income;
      }
    }

    public decimal Expense {
      get => expense;
      set {
        expense = value;
        expenseView = (float)expense;
      }
    }

    public decimal NetProfit {
      get => netProfit;
      set {
        netProfit = value;
        netProfitView = (float)netProfit;
      }
    }

    public void CalculateExpensesAndProfits() {
      NetProfit = Income - Expense;

      Balance += NetProfit;


    }
  }
}
