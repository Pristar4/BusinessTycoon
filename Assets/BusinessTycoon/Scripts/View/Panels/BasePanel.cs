#region Info
// -----------------------------------------------------------------------
// BasePanel.cs
// 
// Felix Jung 25.06.2023
// -----------------------------------------------------------------------
#endregion
using System;
using BT.Scripts.Models;
using UnityEngine;

namespace BT.Scripts.View.Panels {
  public class BasePanel : MonoBehaviour, IPanel {
    public virtual void Initialize(PanelData data = null) {
      throw new NotImplementedException();
    }
    public virtual void Open() {
      gameObject.SetActive(true);
    }
    public virtual void Close() {
      gameObject.SetActive(false);
    }
    public virtual void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}
