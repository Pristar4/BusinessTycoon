#region Info
// -----------------------------------------------------------------------
// InventoryPanel.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.production;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class InventoryPanel : MonoBehaviour, IPanelDisplay {
    private readonly Company company;
    private IPanelDisplay panelDisplayImplementation;

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
      //update the inventory panel here and add product game-objects with the correct data under the Scroll-view the public Transform inventoryContainer; is in the ui-manager under that game-objects manage the products
    }
    #endregion
  }
}