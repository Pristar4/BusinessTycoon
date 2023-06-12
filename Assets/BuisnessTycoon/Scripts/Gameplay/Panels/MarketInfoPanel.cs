using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class MarketInfoPanel : MonoBehaviour, IPanelDisplay {

    private static MarketManager GetMarketManager
      => ManagerProvider.Current.MarketManager;

    #region IPanelDisplay Members
    public void Initialize() {
      Debug.Log("MarketInfoPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      throw new NotImplementedException();
    }
    #endregion
  }
}
