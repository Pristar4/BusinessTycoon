#region Info
// -----------------------------------------------------------------------
// BasePanel.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;
using TMPro;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class BasePanel : MonoBehaviour, IPanel {
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private GameObject panelBackground;
    public void Initialize(PanelData data) {
      titleText.text = data.title;
      panelBackground = data.background;
    }
    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }
    public void UpdatePanel() {

    }
  }
}
