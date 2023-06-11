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
    private Company company;
    private IPanelDisplay panelDisplayImplementation;
    public void Initialize(Company selected = null) {
      company = selected;
      Debug.Log(company + "InventoryPanel initialized");
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }
    public void UpdateUI() {
      //update the inventory panel here and add product gameobjects with the correct data under the Scrollview the public Transform inventoryContainer; is in the uimanager under that gameobjects manage the produts
    }
  }
}
