#region Info
// -----------------------------------------------------------------------
// InventoryPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.Controller.Managers;
using BT.Scripts.Models;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.View.Panels {
  public class InventoryPanel : BasePanel {
    #region Serialized Fields
    [SerializeField] private Transform inventoryContainer;
    [SerializeField]
    private GameObject productItemPrefab;
    #endregion
    private Company company;
    #region IPanel Members
    public override void Initialize(PanelData data = null) {
      company = ManagerProvider.Current.PlayerManager.GetPlayerCompany();

    }
    public override void UpdatePanel() {
// Clear existing offer items
      foreach (Transform child in inventoryContainer) Destroy(child.gameObject);


      // Instantiate offer items for  all offers in market
      foreach (var item in company.ProductInventory) {
        // Instantiate offer item prefab
        var product = Instantiate(productItemPrefab, inventoryContainer);

        // Set product details in TMP Text component
        var productText = product.GetComponentInChildren<TMP_Text>();
        productText.text = item.Type.name + " X " + item.Amount;
      }
    }
    #endregion
  }
}
