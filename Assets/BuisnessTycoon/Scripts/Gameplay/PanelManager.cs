#region Info
// -----------------------------------------------------------------------
// PanelManager.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
using System.Collections.Generic;
using BT.Scripts.production;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class PanelManager : MonoBehaviour {
    private readonly Dictionary<string, IPanel> panels = new();
    public void RegisterPanel(string panelId, IPanel panel) {
      panels[panelId] = panel;
    }
    public void OpenPanel(string panelId, PanelData data) {
      if (panels.TryGetValue(panelId, out var panel)) {
        panel.Initialize(data);
        panel.SetActive(true);
      }
    }
  }
}
