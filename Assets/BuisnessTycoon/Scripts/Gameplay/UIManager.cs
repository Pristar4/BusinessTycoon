#region Info
// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 08.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.production;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
#endregion

namespace BT.Scripts.Gameplay {
  public class UIManager : MonoBehaviour {
    #region Serialized Fields
    //collapsable fields

    [VerticalGroup("UI Elements/Top Bar")]
    public TMP_Text companyNameText;
     [VerticalGroup("UI Elements/Top Bar")]
    public TMP_Text balanceText;
   [VerticalGroup("UI Elements/Top Bar")]
    public TMP_Text incomeText;
  [VerticalGroup("UI Elements/Top Bar")]
    public TMP_Text expensesText;
     [VerticalGroup("UI Elements/Top Bar")]
    public TMP_Text netProfitText;
    [VerticalGroup("UI Elements/Top Bar")]
    public TMP_Text turnText;
    [VerticalGroup("UI Elements")]
    public TMP_Dropdown managementDropdown;
    [VerticalGroup("UI Elements")]
    public TMP_Text detailsText;
    [VerticalGroup("UI Elements")]
    public TMP_Dropdown marketDropdown;
    [VerticalGroup("UI Elements")]
    public Transform offerContainer;

    [SerializeField]
    private GameObject offerItemPrefab;
    #endregion

    [SerializeField]
    private MarketManager marketManager;
    private IReadOnlyList<Offer> offers; // Read-only list of offers

    private void InitUI(Company startup) {
      offers = marketManager.GetOffers();
      UpdateFinancialUI(startup);
      UpdateOfferUI();
    }

    public void UpdateUI(Company company, int turn) {
      UpdateFinancialUI(company);
      UpdateTurnUI(turn);
      UpdateOfferUI();
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

    private void UpdateOfferUI() {
      // Clear existing offer items
      foreach (Transform child in offerContainer) { Destroy(child.gameObject); }

      
      offers = marketManager.GetOffers();
      // Instantiate offer items for  all offers in market
      foreach (var offer in offers) {
        // Instantiate offer item prefab
        var offerItem = Instantiate(offerItemPrefab, offerContainer);

        // Set offer details in TMP Text component
        var offerText = offerItem.GetComponentInChildren<TMP_Text>();
        offerText.text = offer.GetOfferDetails();
      }
    }

    public void Initialize(Company startup) {
      InitUI(startup);
    }
  }
}
