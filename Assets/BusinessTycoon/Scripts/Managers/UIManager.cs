#region Info
// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 23.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using BT.Scripts.Interfaces;
using BT.Scripts.Models;
using BT.Scripts.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
#if ODIN_INSPECTOR
#endif
#endregion


namespace BT.Scripts.Managers {
  namespace BT.Scripts.Gameplay {
    public class UIManager : MonoBehaviour, IManager {
      #region Serialized Fields
      //collapsable fields
      [Header("UI Elements")]
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Text companyNameText;
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Text balanceText;
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Text incomeText;
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Text expensesText;
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Text netProfitText;
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Text turnText;
      #if ODIN_INSPECTOR
      [VerticalGroup("UI Elements/Top Bar")]
      #endif
      public TMP_Dropdown repeatingTasksDropdown;
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements")]
      #endif
      public TMP_Text detailsText;
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements")]
      #endif
      public TMP_Dropdown marketDropdown;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private InventoryPanel inventoryPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private OfferPanel offerPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private MarketInfoPanel marketInfoPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private ResearchPanel researchPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private ProductionPanel productionPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private FinancingPanel financingPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private ContractsPanel contractsPanel;
      [SerializeField]
      #if ODIN_INSPECTOR
      [FoldoutGroup("UI Elements/Panels")]
      #endif
      private BudgetingPanel budgetingPanel;
      #endregion
      private InputManager inputManager;
      #region Event Functions
      private void Start() {
        // Method intentionally left empty.
      }
      #endregion
      #region IManager Members
      public void Initialize() {
        // Method intentionally left empty.
      }
      #endregion
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
      public void UpdateUI(Company company, int turn) {
        UpdateFinancialUI(company);
        UpdateTurnUI(turn);
        offerPanel.UpdatePanel();
      }
      public void OnDropdownSelectionChanged(int selectedIndex) {

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
      public event UnityAction OnEndTurnPressed;
      public void EndTurnPressed() {
        OnEndTurnPressed?.Invoke();
      }
      private void InitUI(Company startup) {
        UpdateFinancialUI(startup);
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
        turnText.text = "Y " + (turn / 4 + 1) + " Q " + (turn % 4 + 0);
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
