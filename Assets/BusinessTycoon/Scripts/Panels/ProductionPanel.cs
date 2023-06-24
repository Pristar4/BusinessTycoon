#region Info
// -----------------------------------------------------------------------
// ProductionPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.Interfaces;
using BT.Scripts.Managers;
using BT.Scripts.Models;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Panels {
  public class ProductionPanel : MonoBehaviour, IPanel {
    [SerializeField] private GameObject factoryPanel;
    [SerializeField] private TMP_Text totalCostText;
    private int totalCost;
    private Company company;
    #region IPanel Members
    public void Initialize(PanelData data = null) {
      company = ManagerProvider.Current.PlayerManager.GetPlayerCompany();
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
      factoryPanel.SetActive(isActive);
    }
    public void UpdatePanel() {
      totalCost = CalculateTotalCost();
      totalCostText.text = "Total Cost: " + totalCost + "€";
    }
    #endregion
    private int CalculateTotalCost() {
      totalCost = 0;
      foreach (var factoryData in company.FactoryInventory)
        totalCost += factoryData.CalculateProductionCost() +
                     CalculateMaterialCost(factoryData) +
                     CalculateLaborCost(factoryData);
      return totalCost;
    }
    private static int CalculateMaterialCost(FactoryData factoryData) {
      return factoryData.Factory.productProduced.MaterialCostPerUnit *
             factoryData.CurrentOutput;
    }
    private int CalculateLaborCost(FactoryData factoryData) {
      var wage = 110;
      // 8 hours per day, 22 days per month, 3 months per quarter = 528 hours per quarter
      var hoursPerQuarter = 528;
      return factoryData.Factory.LaborForce * hoursPerQuarter * wage;

    }
    
  }
}
