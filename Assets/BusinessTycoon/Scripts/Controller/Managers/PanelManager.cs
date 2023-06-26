#region Info

// -----------------------------------------------------------------------
// PanelManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using BT.Panels;
using UnityEngine;

#endregion

namespace BT.Managers {
    public class PanelManager : MonoBehaviour, IManager {
        private readonly Dictionary<string, IPanel> panels = new();

        #region IManager Members

        public void Initialize() {
            // Intentionally left blank
        }

        #endregion

        public void RegisterPanel(string panelId, IPanel panel) {
            panels[panelId] = panel;
        }

        public void OpenPanel(string panelId, PanelData data) {
            if (panels.TryGetValue(panelId, out var panel)) {
                panel.Initialize(data);
                panel.Open();
            }
        }
    }
}