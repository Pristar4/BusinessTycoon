#region Info
// -----------------------------------------------------------------------
// ResearchPanel.cs
// 
// Felix Jung 12.06.2023
// -----------------------------------------------------------------------
#endregion
using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ResearchPanel : MonoBehaviour, IPanelDisplay {
    #region IPanelDisplay Members
    public void Initialize() {
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