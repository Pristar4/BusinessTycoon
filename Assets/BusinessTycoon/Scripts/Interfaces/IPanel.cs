#region Info
// -----------------------------------------------------------------------
// IPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.Models;
#endregion

namespace BT.Scripts.Interfaces {
  public interface IPanel {
    void Initialize(PanelData data = null);
    void SetActive(bool isActive);
    void UpdatePanel();
  }
}
