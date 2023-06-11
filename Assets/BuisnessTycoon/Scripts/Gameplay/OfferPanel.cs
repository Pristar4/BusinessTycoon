#region Info
// -----------------------------------------------------------------------
// OfferPanel.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.production;
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class OfferPanel : MonoBehaviour, IPanelDisplay {
    #region Serialized Fields
    [SerializeField]
    private Transform offerContainer;
    [SerializeField]
    private GameObject offerItemPrefab;
    #endregion
    private IReadOnlyList<Offer> offers;

    private static MarketManager GetMarketManager => ManagerProvider.Current.MarketManager;
    #region IPanelDisplay Members
    public void Initialize() {
      Debug.Log("OfferPanel initialized");
    }

    public void SetActive(bool isActive) {
      gameObject.SetActive(isActive);

    }

    public void UpdatePanel() {
      // Clear existing offer items
      foreach (Transform child in offerContainer) { Destroy(child.gameObject); }


      offers = GetMarketManager.GetOffers();

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