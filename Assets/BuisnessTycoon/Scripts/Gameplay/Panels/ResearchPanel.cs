#region Info
// -----------------------------------------------------------------------
// ResearchPanel.cs
// 
// Felix Jung 12.06.2023
// -----------------------------------------------------------------------
#endregion
using System;
using BT.Scripts.production;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ResearchPanel : MonoBehaviour, IPanel {
    #region IPanelDisplay Members
    public void Initialize(PanelData data = null) {
      Debug.Log("ResearchPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
    #endregion
  }
}
