#region Info
// -----------------------------------------------------------------------
// FinancingPanel.cs
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
  public class FinancingPanel : MonoBehaviour, IPanel {
    public void Initialize(PanelData data = null) {
      Debug.Log("FinancingPanel initialized");
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }
    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}
