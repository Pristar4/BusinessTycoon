using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ContractsPanel : MonoBehaviour, IPanelDisplay {

    public void Initialize() {
      Debug.Log("ContractsPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}
