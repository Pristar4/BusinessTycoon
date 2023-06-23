#region Info
// -----------------------------------------------------------------------
// PanelDarkGeo.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#endregion

namespace BT.Plugins.GUI_Kit___Dark_Geo.Scripts {
  public class PanelDarkGeo : MonoBehaviour {
    #region Serialized Fields
    [SerializeField] private GameObject[] otherPanels;
    #endregion
    #region Event Functions
    public void OnEnable() {
      for (int i = 0; i < otherPanels.Length; i++)
        otherPanels[i].SetActive(true);
    }

    public void OnDisable() {
      for (int i = 0; i < otherPanels.Length; i++)
        otherPanels[i].SetActive(false);
    }
    #endregion
  }
}