#region Info
// -----------------------------------------------------------------------
// PanelData.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#endregion

namespace BT.Scripts.Models {
  [CreateAssetMenu(menuName = "Panel Data")]
  public class PanelData : ScriptableObject {
    #region Serialized Fields
    public string title;
    public GameObject background;
    #endregion
    // Add more as needed...
  }
}
