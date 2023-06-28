#region Info

// -----------------------------------------------------------------------
// MarketManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

namespace BT.Managers {
    public class MarketManager : MonoBehaviour, IManager {
        #region Serialized Fields

        [SerializeField] private List<ProductSo> products;

        #endregion

        public List<ProductSo> Products => products;
        public List<Offer> Offers { get; private set; }

        public Dictionary<ProductSo, int> ProductDemand { get; } = new();

        #region IManager Members

        public void Initialize() {
            Offers = new List<Offer>();
            foreach (var product in products)
                ProductDemand.Add(product, product.productDemand);
        }

        #endregion

        public void SetProductDemand(ProductSo productType, int demand) {
            ProductDemand[productType] = demand;
        }

        public int GetProductDemand(ProductSo productType) {
            if (ProductDemand.TryGetValue(productType, out int demand)) return demand;

            throw new Exception("Product" + productType +
                                "not found in productDemand");
        }

        public void UpdateMarket() {
            var items = new List<ProductSo>(ProductDemand.Keys);


            foreach (var productType in items) {
                int remainingDemand = ProductDemand[productType];
                var offersForProduct
                        = Offers.FindAll(offer => offer.product.Type == productType &&
                                                  !offer.isSold);
                SortOffersByScore(offersForProduct);


                foreach (var offer in offersForProduct) {
                    int quantityToBuy = Mathf.Min(remainingDemand, offer.quantity);
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
                    if (offer.quantity <= 0) Offers.Remove(offer);
                    // Debug.Log(offer.company.CompanyName + " Sold " + quantityToBuy +
                    //           " of " + offer.product.Type.name +
                    //           " for " + offer.price + " each");

                    if (remainingDemand <= 0) break;
                }

                ProductDemand[productType] = remainingDemand;
            }

            AdjustPrices();
            // Debug.Log("UpdateMarket");
        }

        private void SortOffersByScore(List<Offer> offerList) {
            offerList.Sort((a, b) => a.price.CompareTo(b.price));
            //TODO: Add more factors and sorting logic in the future
        }

        private void AdjustPrices() {
            // TODO: Implement price adjustment logic based on supply and demand
        }

        public void ClearOffers() {
            Offers.Clear();
        }

        public void AddOffer(Offer offer) {
            Offers.Add(offer);
        }

        public decimal GetSales(Company company) {
            decimal sales = 0;

            foreach (var offer in Offers)
                if (offer.company == company && offer.isSold)
                    sales += offer.price * offer.soldQuantity;

            return sales;
        }

        public IReadOnlyList<Offer> GetOffers() {
            return Offers.AsReadOnly();
        }

        public ProductSo GetProductByName(string productName) {
            var product = products.Find(p => p.name == productName);
            if (product != null) return product;
            throw new Exception($"Product {productName} not found");
        }
    }
}