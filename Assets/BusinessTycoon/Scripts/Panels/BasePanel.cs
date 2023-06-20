#region Info
// -----------------------------------------------------------------------
// BasePanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.Interfaces;
using BT.Scripts.Models;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Panels {
  public class BasePanel : MonoBehaviour, IPanel {
    #region Serialized Fields
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private GameObject panelBackground;
    #endregion
    #region IPanel Members
    public void Initialize(PanelData data) {
      titleText.text = data.title;
      panelBackground = data.background;
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }
    public void UpdatePanel() { }
    #endregion
  }
}
