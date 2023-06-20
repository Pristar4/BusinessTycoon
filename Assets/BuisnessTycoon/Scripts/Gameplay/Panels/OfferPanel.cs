#region Info
// -----------------------------------------------------------------------
// OfferPanel.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.production;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class OfferPanel : MonoBehaviour, IPanel {
    #region Serialized Fields
    [SerializeField]
    private Transform offerContainer;
    [SerializeField]
    private GameObject offerItemPrefab;
    #endregion

    private static MarketManager GetMarketManager
      => ManagerProvider.Current.MarketManager;

    #region IPanelDisplay Members
    public void Initialize(PanelData data = null) {
      Debug.Log("OfferPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);

    }

    public void UpdatePanel() {
      // Clear existing offer items
      foreach (Transform child in offerContainer) { Destroy(child.gameObject); }


      var offers = GetMarketManager.GetOffers();

      // Instantiate offer items for  all offers in market
      foreach (var offer in offers) {
        // Instantiate offer item prefab
        var offerItem = Instantiate(offerItemPrefab, offerContainer);

        // Set offer details in TMP Text component
        var offerText = offerItem.GetComponentInChildren<TMP_Text>();
        offerText.text = offer.GetOfferDetails();
      }
    }
    #endregion
  }
}
