using BT.Scripts.production;
using TMPro;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class MarketInfoPanel : MonoBehaviour, IPanel {
    
    

    private static MarketManager GetMarketManager
      => ManagerProvider.Current.MarketManager;

    [SerializeField]
    private TMP_Text productDemandText;

    #region IPanelDisplay Members
    public void Initialize(PanelData data = null) {
      Debug.Log("MarketInfoPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);
    }

    public void UpdatePanel() {
      var demandInfo = "";
      var productDemands = GetMarketManager.ProductDemand;
      foreach (var productDemand in productDemands)
        demandInfo
            += $"{productDemand.Key.name}, Demand: {productDemand.Value}\n";

      productDemandText.text = demandInfo;
    }
    #endregion
  }
}
