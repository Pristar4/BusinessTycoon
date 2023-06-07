#region Info
// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;
using TMPro;
using UnityEngine;

namespace BT.Scripts {
  public class UIManager : MonoBehaviour {

    public TMP_Text companyNameText;
    public TMP_Text balanceText;
    public TMP_Text incomeText;
    public TMP_Text expensesText;
    public TMP_Text netProfitText;
    public TMP_Text turnText;
    public TMP_Dropdown managementDropdown;
    public TMP_Text detailsText;
    public TMP_Dropdown marketDropdown;

    private void InitUI(Company startup) {
      UpdateFinancialUI(startup);
    }

    public void UpdateUI(Company company, int turn) {
      UpdateFinancialUI(company);
      UpdateTurnUI(turn);
    }

    private void UpdateFinancialUI(Company company) {
      companyNameText.text = company.CompanyName;
      balanceText.text = "Balance: " + company.Finance.Balance;
      incomeText.text = "Income: " + company.Finance.Income;
      expensesText.text = "Expenses: " + company.Finance.Expense;
      netProfitText.text = "Net Profit: " + company.Finance.NetProfit;
    }

    private void UpdateTurnUI(int turn) {
      turnText.text = "Turn: " + turn;
    }

    public void Initialize(Company startup) {
      InitUI(startup);
    }
  }
}
