#region Info
// -----------------------------------------------------------------------
// InventoryPanel.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.production;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class InventoryPanel : MonoBehaviour, IPanelDisplay {
    #region Serialized Fields
    [SerializeField] private Transform inventoryContainer;

    [SerializeField]
    private GameObject productItemPrefab;
    #endregion
    private readonly Company company;

    public InventoryPanel(Company selected = null) {

      if (selected == null) { Debug.Log("No company selected"); }

      company = selected;
    }

    #region IPanelDisplay Members
    public void Initialize() {
      Debug.Log(company + "InventoryPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
// Clear existing offer items
      foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }


      // Instantiate offer items for  all offers in market
      foreach (var item in company.ProductInventory) {
        // Instantiate offer item prefab
        var offerItem = Instantiate(productItemPrefab, inventoryContainer);

        // Set offer details in TMP Text component
        var productText = offerItem.GetComponentInChildren<TMP_Text>();
        productText.text = item.Type + " X " + item.Amount;
      }
    }
    #endregion
  }
}
