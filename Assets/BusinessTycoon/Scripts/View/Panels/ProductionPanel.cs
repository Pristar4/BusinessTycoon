#region Info
// -----------------------------------------------------------------------
// ProductionPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.BusinessTycoon.Scripts.Controller.Managers;
using BT.BusinessTycoon.Scripts.Models;
using TMPro;
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.View.Panels {
  public class ProductionPanel : BasePanel {
    [SerializeField] private GameObject factoryPanel;
    [SerializeField] private TMP_Text totalCostText;
    private Company company;
    public float TotalCost { set; get; }
    #region IPanel Members
    public override void Initialize(PanelData data = null) {
      company = ManagerProvider.Current.PlayerManager.GetPlayerCompany();
    }
    public override void Open() {
      gameObject.SetActive(true);
      factoryPanel.SetActive(true);
    }
    public override void Close() {
      gameObject.SetActive(false);
      factoryPanel.SetActive(false);
    }
    public override void UpdatePanel() {
      TotalCost = company.CalculateTotalCost();
      totalCostText.text = "Total Cost: " + TotalCost + "€";
    }
    #endregion
  }
}
