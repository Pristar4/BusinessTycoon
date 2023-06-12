using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ProductionPanel : MonoBehaviour, IPanelDisplay {

    public void Initialize() {
      Debug.Log("ProductionPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}
