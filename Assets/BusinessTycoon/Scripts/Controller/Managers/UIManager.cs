#region Info

// -----------------------------------------------------------------------
// UIManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System;
using BT.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

#endregion

namespace BT.Managers {
    namespace BT.Scripts.Gameplay {
        public class UIManager : MonoBehaviour, IManager {
            #region Serialized Fields

            //collapsable fields
            [Header("UI Elements")] [SerializeField]
            private TMP_Text companyNameText;
            [SerializeField] private TMP_Text balanceText;
            [SerializeField] private TMP_Text incomeText;
            [SerializeField] private TMP_Text expensesText;
            [SerializeField] private TMP_Text netProfitText;
            [SerializeField] private TMP_Text turnText;
            [SerializeField] private TMP_Dropdown repeatingTasksDropdown;
            [SerializeField] private TMP_Text detailsText;
            [SerializeField] private TMP_Dropdown marketDropdown;
            [Header("Panels")] [SerializeField] private InventoryPanel inventoryPanel;
            [SerializeField] private OfferPanel offerPanel;
            [SerializeField] private MarketInfoPanel marketInfoPanel;
            [SerializeField] private ResearchPanel researchPanel;
            // [FoldoutGroup("UI Elements/Panels")]
            [SerializeField] private ProductionPanel productionPanel;
            [SerializeField] private FinancingPanel financingPanel;
            [SerializeField] private ContractsPanel contractsPanel;
            [SerializeField] private BudgetingPanel budgetingPanel;

            #endregion

            private InputManager inputManager;

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
                }
                catch (Exception e) {
                    Debug.Log("Error deactivating panels: " + e);
                }
            }
        }
    }
}