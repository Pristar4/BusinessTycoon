using System;
using BT.Scripts.production;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class FinancingPanel : MonoBehaviour, IPanel {
    public void Initialize(PanelData data = null) {
      Debug.Log("FinancingPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}
