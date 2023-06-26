#region Info
// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using BT.BusinessTycoon.Scripts.Models;
using BT.BusinessTycoon.Scripts.View.Panels;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
#endregion

namespace BT.BusinessTycoon.Scripts.Controller.Managers {
  namespace BT.Scripts.Gameplay {
    public class UIManager : MonoBehaviour, IManager {
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
      private InputManager inputManager;
      public void Initialize() {
        // Method intentionally left empty.
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
            marketInfoPanelComponent.Open();
            marketInfoPanelComponent.UpdatePanel();
          }

          break;
        case 1:
          // Research
          if (researchPanel.TryGetComponent(
                  out ResearchPanel researchPanelComponent)) {
            researchPanelComponent.Open();
            researchPanelComponent.UpdatePanel();
          }

          break;
        case 2:
          // Production
          if (inventoryPanel.TryGetComponent(
                  out InventoryPanel inventoryPanelComponent)) {
            inventoryPanelComponent.Open();
            inventoryPanelComponent.UpdatePanel();
          }

          if (productionPanel.TryGetComponent(
                  out ProductionPanel productionPanelComponent)) {
            productionPanelComponent.Open();
            productionPanelComponent.UpdatePanel();
          }

          break;
        case 3:
          // Contracts
          if (contractsPanel.TryGetComponent(
                  out ContractsPanel contractsPanelComponent)) {
            contractsPanelComponent.Open();
            contractsPanelComponent.UpdatePanel();
          }

          break;

        case 4:
          // Financing
          if (financingPanel.TryGetComponent(
                  out FinancingPanel financingPanelComponent)) {
            financingPanelComponent.Open();
            financingPanelComponent.UpdatePanel();
          }

          break;
        case 5:
          // Budgeting
          if (budgetingPanel.TryGetComponent(
                  out BudgetingPanel budgetingPanelComponent)) {
            budgetingPanelComponent.Open();
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
          marketInfoPanel.Close();
          researchPanel.Close();
          productionPanel.Close();
          financingPanel.Close();
          contractsPanel.Close();
          budgetingPanel.Close();
          inventoryPanel.Close();
          offerPanel.Close();

        } catch (Exception e) { Debug.Log("Error deactivating panels: " + e); }
      }
    }
  }
}
