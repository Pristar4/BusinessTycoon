#region Info
// -----------------------------------------------------------------------
// BudgetingPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.Interfaces;
using BT.Scripts.Models;
using UnityEngine;
#endregion

namespace BT.Scripts.Panels {
  public class BudgetingPanel : MonoBehaviour, IPanel {
    #region IPanel Members
    public void Initialize(PanelData data = null) {
      // TODO: Implement
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }
    public void UpdatePanel() {
      // TODO: Implement

    }
    #endregion
  }
}
