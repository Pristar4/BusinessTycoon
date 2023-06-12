using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class FinancingPanel : MonoBehaviour, IPanelDisplay {

    public void Initialize() {
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