#region Info
// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 08.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;

namespace BT.Scripts.Gameplay {
  #region
  using System;
  using System.Collections.Generic;
  using Sirenix.OdinInspector;
  using TMPro;
  using UnityEngine;
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
      [VerticalGroup("UI Elements/Top Bar")]
      public TMP_Dropdown managementDropdown;
      [FoldoutGroup("UI Elements")]
      public TMP_Text detailsText;
      [FoldoutGroup("UI Elements")]
      public TMP_Dropdown marketDropdown;
      [FoldoutGroup("UI Elements")]
      public Transform offerContainer;
      [FoldoutGroup("UI Elements")]
      public Transform inventoryContainer;
      [SerializeField]
      private GameObject offerItemPrefab;
      #endregion
      private MarketManager marketManager;
      private IReadOnlyList<Offer> offers; // Read-only list of offers
      private IPanelDisplay currentPanel;
      [SerializeField]
      private InventoryPanel inventoryPanel;
      private void InitUI(Company startup) {
        marketManager = FindFirstObjectByType<MarketManager>();
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
        foreach (Transform child in offerContainer) {
          Destroy(child.gameObject);
        }


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
        inventoryPanel.Initialize(startup);
      }
      public void OnDropdownSelectionChanged(int selectedIndex) {

        Debug.Log("Dropdown selection changed to " + selectedIndex);

        // Deactivate all other screens
        DeactivateAllPanels();

// Activate the selected screen

        switch (selectedIndex) {
        case 0:
          // Inventory
          inventoryPanel.SetActive(true);
          break;
        }
        // Activate the InventoryScreen using SetActive(true)
        // Call Initialize() on the InventoryScreen with the Company reference if necessary
        // Call UpdateUI() on the InventoryScreen to initially display the inventory data
      }
      public void OnDropdownSelectionChanged(int selectedIndex)
      {
        Debug.Log("Dropdown selection changed to " + selectedIndex);

        // Deactivate all other panels
        DeactivateAllPanels();

        // Activate the selected panel
        switch (selectedIndex)
        {
        case 0:
          // Inventory
          if (inventoryPanel.TryGetComponent(out InventoryPanel inventoryPanelComponent))
          {
            inventoryPanelComponent.SetActive(true);
            // inventoryPanelComponent.Initialize(company);
            inventoryPanelComponent.UpdateUI();
          }
          break;
        // Add cases for other panels
        }
      }

      private void DeactivateAllPanels() {
        try {
          inventoryPanel.SetActive(false);
          // TODO: Deactivate other screens as well


        } catch (Exception e) {
          Debug.Log("Exception caught: " + inventoryPanel + " is null");
        }
      }
    }
  }
}
