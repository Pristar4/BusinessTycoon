#region Info
// -----------------------------------------------------------------------
// MarketManager.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using System.Collections.Generic;
using BT.Scripts.production;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class MarketManager : SerializedMonoBehaviour {
    #region Serialized Fields
    [SerializeField]
    private List<ProductSo> products;
    #endregion
    [OdinSerialize]
    private List<Offer> offers;
    [OdinSerialize]
    private Dictionary<ProductSo, int> productDemand = new();
    public List<ProductSo> Products => products;
    public List<Offer> Offers => offers;
    public Dictionary<ProductSo, int> ProductDemand => productDemand;
    public void Initialize() {
      offers = new List<Offer>();

      //TODO: remove this test code
      SetProductDemand(products[0], 500);
      SetProductDemand(products[1], 10);


      Debug.Log("MarketManager initialized");
    }
    public void SetProductDemand(ProductSo productType, int demand) {
      productDemand[productType] = demand;

    }
    public int GetProductDemand(ProductSo productType) {
      if (productDemand.TryGetValue(productType, out var demand)) return demand;

      throw new Exception("Product" + productType +
                          "not found in productDemand");
    }
    public void UpdateMarket() {
      //TODO: improve this logic to be more efficient
      var items = new List<ProductSo>(productDemand.Keys);

      foreach (var productType in items) {
        var remainingDemand = productDemand[productType];
        var offersForProduct
            = offers.FindAll(offer => offer.product.Type == productType &&
                                      !offer.isSold);
        SortOffersByScore(offersForProduct);


        foreach (var offer in offersForProduct) {
          var quantityToBuy = Mathf.Min(remainingDemand, offer.quantity);
          remainingDemand -= quantityToBuy;


          offer.soldQuantity = quantityToBuy;
          offer.isSold = true;
          // Remove products from company
          offer.company.RemoveProduct(offer.product.Type, quantityToBuy);
          offer.soldQuantity = quantityToBuy;
          offer.quantity -= quantityToBuy;
          // Add money to company
          offer.company.AddMoney(quantityToBuy * offer.price);

          //remove offer if it is empty
          if (offer.quantity <= 0) {
            offers.Remove(offer);
            Debug.Log("Removed offer from market");
          }

          Debug.Log("Sold " + quantityToBuy + " of " + offer.product.Type.name +
                    " for " + offer.price + " each");

          if (remainingDemand <= 0) break;
        }

        productDemand[productType] = remainingDemand;
      }

      AdjustPrices();
      Debug.Log("UpdateMarket");
    }
    private void SortOffersByScore(List<Offer> offerList) {
      offerList.Sort((a, b) => a.price.CompareTo(b.price));
      //TODO: Add more factors and sorting logic in the future
    }
    private void AdjustPrices() {
      // TODO: Implement price adjustment logic based on supply and demand
    }
    public void ClearOffers() {
      offers.Clear();
    }
    public void AddOffer(Offer offer) {
      offers.Add(offer);
    }
    public decimal GetSales(Company company) {
      decimal sales = 0;

      foreach (var offer in offers)
        if (offer.company == company && offer.isSold)
          sales += offer.price * offer.soldQuantity;

      return sales;
    }
    public IReadOnlyList<Offer> GetOffers() {
      return offers.AsReadOnly();
    }
  }
}
