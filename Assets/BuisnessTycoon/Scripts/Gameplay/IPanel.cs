#region Info
// -----------------------------------------------------------------------
// IPanelDisplay.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;

namespace BT.Scripts.Gameplay {
  public interface IPanel {
    void Initialize(PanelData data = null);
    void SetActive(bool isActive);
    void UpdatePanel();
  }
}
