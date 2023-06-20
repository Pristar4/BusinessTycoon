#region Info
// -----------------------------------------------------------------------
// PanelData.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
using UnityEngine;

namespace BT.Scripts.production {
  [CreateAssetMenu(menuName = "Panel Data")]
  public class PanelData : ScriptableObject {
    public string title;
    public GameObject background;
    // Add more as needed...
  }
}
