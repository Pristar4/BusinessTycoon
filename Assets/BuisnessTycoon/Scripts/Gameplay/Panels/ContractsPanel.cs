#region Info
// -----------------------------------------------------------------------
// ContractsPanel.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using BT.Scripts.production;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class ContractsPanel : MonoBehaviour, IPanel {
    public void Initialize(PanelData data = null) {
      Debug.Log("ContractsPanel initialized");
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }
    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}
