using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ReportsPanel : MonoBehaviour, IPanelDisplay {

    public void Initialize() {
      Debug.Log("ReportsPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}