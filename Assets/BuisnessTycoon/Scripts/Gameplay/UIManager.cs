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
using UnityEngine.Serialization;
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
      [FormerlySerializedAs("managementDropdown")]
      [VerticalGroup("UI Elements/Top Bar")]
      public TMP_Dropdown repeatingTasksDropdown;
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
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private MarketInfoPanel marketInfoPanel;
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private ResearchPanel researchPanel;
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private ProductionPanel productionPanel;
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private FinancingPanel financingPanel;
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private ContractsPanel contractsPanel;
      [FoldoutGroup("UI Elements/Panels")]
      [SerializeField]
      private BudgetingPanel budgetingPanel;
      
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
        // 4 Quarters per year
        turnText.text = "Y " + (turn / 4 + 1) + " Q " + (turn % 4 + 1); 
      }

      public void Initialize(Company startup) {
        InitUI(startup);

        marketInfoPanel.Initialize();
        researchPanel.Initialize();
        productionPanel.Initialize();
        financingPanel.Initialize();
        contractsPanel.Initialize();
        budgetingPanel.Initialize();
        inventoryPanel.Initialize();
        offerPanel.Initialize();

        // Activate default panel (e.g. MarketInfo)
        OnDropdownSelectionChanged(0);
        
      }

      public void OnDropdownSelectionChanged(int selectedIndex) {
        Debug.Log("Dropdown selection changed to " + selectedIndex);

        // Deactivate all other panels
        DeactivateAllPanels();

        // Activate the selected panel
        switch (selectedIndex) {
        case 0:
          // Market info
          if (marketInfoPanel.TryGetComponent(
                  out MarketInfoPanel marketInfoPanelComponent)) {
            marketInfoPanelComponent.SetActive(true);
            marketInfoPanelComponent.UpdatePanel();
          }

          break;
        case 1:
          // Research
          if (researchPanel.TryGetComponent(
                  out ResearchPanel researchPanelComponent)) {
            researchPanelComponent.SetActive(true);
            researchPanelComponent.UpdatePanel();
          }

          break;
        case 2:
          // Production
          if (inventoryPanel.TryGetComponent(
                  out InventoryPanel inventoryPanelComponent)) {
            inventoryPanelComponent.SetActive(true);
            inventoryPanelComponent.UpdatePanel();
          }

          if (productionPanel.TryGetComponent(
                  out ProductionPanel productionPanelComponent)) {
            productionPanelComponent.SetActive(true);
            productionPanelComponent.UpdatePanel();
          }

          break;
        case 3:
          // Contracts
          if (contractsPanel.TryGetComponent(
                  out ContractsPanel contractsPanelComponent)) {
            contractsPanelComponent.SetActive(true);
            contractsPanelComponent.UpdatePanel();
          }

          break;

        case 4:
          // Financing
          if (financingPanel.TryGetComponent(
                  out FinancingPanel financingPanelComponent)) {
            financingPanelComponent.SetActive(true);
            financingPanelComponent.UpdatePanel();
          }

          break;
        case 5:
          // Budgeting
          if (budgetingPanel.TryGetComponent(
                  out BudgetingPanel budgetingPanelComponent)) {
            budgetingPanelComponent.SetActive(true);
            budgetingPanelComponent.UpdatePanel();
          }

          break;
        }
      }

      private void DeactivateAllPanels() {
        try {
          marketInfoPanel.SetActive(false);
          researchPanel.SetActive(false);
          productionPanel.SetActive(false);
          financingPanel.SetActive(false);
          contractsPanel.SetActive(false);
          budgetingPanel.SetActive(false);
          inventoryPanel.SetActive(false);
          offerPanel.SetActive(false);


        } catch (Exception e) { Debug.Log("Error deactivating panels: " + e); }
      }
    }
  }
}
