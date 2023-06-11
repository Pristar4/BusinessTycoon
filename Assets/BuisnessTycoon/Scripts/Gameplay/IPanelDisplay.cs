#region Info
// -----------------------------------------------------------------------
// IPanelDisplay.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;

namespace BT.Scripts.Gameplay {
  public interface IPanelDisplay {
    void Initialize(Company company = null);

    void UpdateUI();
    
    void SetActive(bool isActive);
    
  }
}
