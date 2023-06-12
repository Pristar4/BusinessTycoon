using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class BudgetingPanel : MonoBehaviour, IPanelDisplay {

    public void Initialize() {
      Debug.Log("BudgetingPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
  }
}