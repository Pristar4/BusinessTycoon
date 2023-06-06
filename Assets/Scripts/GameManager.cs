#region Info
// -----------------------------------------------------------------------
// GameManager.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
#region

using System.Collections.Generic;
using BT.Scripts;
using TMPro;
using UnityEngine;

#endregion

namespace BT.Scripts {
  public class GameManager : MonoBehaviour {
    #region Serialized Fields
    // UI element to display the company name
    public TMP_Text companyNameText;

    // UI element to display the balance
    public TMP_Text balanceText;

    // UI element to display the income
    public TMP_Text incomeText;

    // UI element to display the expenses
    public TMP_Text expensesText;

    // UI element to display the net profit
    public TMP_Text netProfitText;

    // UI element to display the turn number
    public TMP_Text turnText;

    // Dropdown for management options
    public TMP_Dropdown managementDropdown;

    // Text field to display the details of the selected management option
    public TMP_Text detailsText;

    // Dropdown to display different market statistics
    public TMP_Dropdown marketDropdown;
    #endregion

    private float timeRemaining = 3;

    // List of all startups in the game
    public List<Startup> Startups { get; private set; }
    private Market Market { get; set; }

    private int Turn { get; set; }
    #region Event Functions
    // This method is called at the start of the game
    private void Start() {
      // Initialize the market
      Market = new Market();

      // Initialize the list of startups
      Startups = new List<Startup>();

      // You should create startups here and add them to the Startups list
      // For example:
      Startups.Add(new Startup("My Startup"));
      Startups[0].Finance.Balance = 1000;
      Startups[0].Finance.Income = 100;
      Startups[0].Finance.Expense = 200;
      Startups[0].Finance.NetProfit = -100;

      Startups.Add(new Startup("McDonalds"));

      // Initialize the turn number
      Turn = 0;

      // Set the company name text
      // This assumes that the player controls the first startup in the list
      companyNameText.text = Startups[0].CompanyName;

      // Update the financial display to match the player's startup's finances
      UpdateFinancialUI(Startups[0]);
    }

    // This method is called every frame
    private void Update() {
      if (timeRemaining > 0) {
        timeRemaining -= Time.deltaTime;
        return;

      }

      timeRemaining = 3;
      Debug.Log("Turn: " + Turn);
      AdvanceTurn();

      // You can add code here to check for player input, advance turns, or manage other parts of the game state
    }
    #endregion

    private void UpdateUI() {
      UpdateFinancialUI(Startups[0]);
      UpdateTurnUI();
      Market.UpdateMarket();
    }

    // This method advances the game by one turn
    public void AdvanceTurn() {
      // Increment the turn number
      Turn++;

      // Simulate a turn for each startup
      foreach (var startup in Startups) startup.RunTurn(Market);

      // Update the market after all startups have run their turn
      Market.UpdateMarket();

      // Update the financial display to reflect changes from this turn
      // Again, this assumes that the player controls the first startup in the list
      UpdateUI();
    }

    // This method updates the financial display to match the provided startup's finances
    private void UpdateFinancialUI(Startup startup) {
      // Update the balance, income, expenses, and net profit text fields
      balanceText.text = "Balance: " + startup.Finance.Balance;

      incomeText.text = "Income: " + startup.Finance.Income;
      expensesText.text = "Expenses: " + startup.Finance.Expense;
      netProfitText.text
          = "Net Profit: " + startup.Finance.NetProfit;
    }

    private void UpdateTurnUI() {
      turnText.text = Turn.ToString();
    }
  }

}
