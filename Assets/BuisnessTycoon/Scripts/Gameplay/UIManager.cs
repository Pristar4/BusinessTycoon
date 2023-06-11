#region Info
// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using BT.Scripts.production;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {

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
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private InventoryPanel inventoryPanel;
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private OfferPanel offerPanel;
      #endregion

      private void InitUI(Company startup) {
        UpdateFinancialUI(startup);
        offerPanel.UpdatePanel();
      }

      public void UpdateUI(Company company, int turn) {
        UpdateFinancialUI(company);
        UpdateTurnUI(turn);
        offerPanel.UpdatePanel();
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
        inventoryPanel.Initialize();
        offerPanel.Initialize();
      }

      public void OnDropdownSelectionChanged(int selectedIndex) {
        Debug.Log("Dropdown selection changed to " + selectedIndex);

        // Deactivate all other panels
        DeactivateAllPanels();

        // Activate the selected panel
        switch (selectedIndex) {
        case 0:
          // Inventory
          if (inventoryPanel.TryGetComponent(
                  out InventoryPanel inventoryPanelComponent)) {
            inventoryPanelComponent.SetActive(true);
            inventoryPanelComponent.UpdatePanel();
          }

          break;
        // Add cases for other panels
        }
      }

      private void DeactivateAllPanels() {
        try {
          inventoryPanel.SetActive(false);
          // TODO: Deactivate other screens as well


        } catch (Exception e) { Debug.Log("Error deactivating panels: " + e); }
      }
    }
  }
}
