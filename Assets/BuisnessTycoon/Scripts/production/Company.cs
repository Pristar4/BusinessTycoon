#region Info
// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 08.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.Gameplay;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  public class Company : MonoBehaviour {
    #region Serialized Fields
    [SerializeField] private List<ProductData> productInventory;
    [SerializeField] private List<FactoryData> factoryInventory;
    public List<ProductData> ProductInventory => productInventory;
    public List<FactoryData> FactoryInventory => factoryInventory;

    [SerializeField] private string companyName = "DefaultCompany";
    #endregion
    private FactorySo factory;

    public Company() {
      // make sure the inventory is initialized
      productInventory = new List<ProductData>();
      factoryInventory = new List<FactoryData>();
    }

    private List<Offer> Offers { get; set; } = new();

    public string CompanyName {
      get => companyName;
      set => companyName = value;
    }

    public Finance Finance { get; set; } = new();

    public void Produce() {
      foreach (var factoryData in factoryInventory) {
        factory = factoryData.type;
        string product = factory.Results[0].type.name;

        for (int i = 0; i < factoryData.amount; i++) {
          if (TryProduction(out var amountProduced)) {
            Debug.Log($"Produced {amountProduced} {product}");
          }
        }
      }
    }

    private bool TryProduction(out int amountProduced) {
      amountProduced = 0;

      if (factory.TryProduce(productInventory, out var outputResults)) {
        factory.ConsumeIngredients(ref productInventory);

        foreach (var result in outputResults) {
          UpdateProductInventory(result, ref amountProduced);
        }

        return true;
      }

      return false;
    }

    private void UpdateProductInventory(ProductData result,
                                        ref int amountProduced) {
      var existingProduct
          = productInventory.Find(data => data.type == result.type);

      if (existingProduct != null) {
        existingProduct.amount += result.amount;
      } else { productInventory.Add(result); }

      amountProduced += result.amount;
    }

    public void CreateOffer(MarketManager marketManager) {
      foreach (var product in productInventory) {
        if (product.amount <= 0)
          continue;
        var offer = new Offer(this, product, product.amount,
                              product.type.SellPrice);
        Debug.Log("Created offer from CreateOffer");
        Offers.Add(offer);
        marketManager.AddOffer(offer);
      }
    }

    public void AddMoney(decimal amount) {
      Finance.Balance += amount;

    }

    public void RemoveProduct(ProductSo productType, int quantityToBuy) {

      var product = productInventory.Find(data => data.type == productType);
      product.amount -= quantityToBuy;

      if (product.amount <= 0) { productInventory.Remove(product); }
    }
  }
  public class Offer {

    public Company company;
    public ProductData product;
    public int quantity;
    public decimal price;
    public int soldQuantity; // TODO: Remove this
    public bool isSold;

    public Offer(Company company, ProductData product, int quantity,
                 decimal price, int soldQuantity = 0, bool isSold = false) {
      this.company = company;
      this.product = product;
      this.quantity = quantity;
      this.price = price;
      this.soldQuantity = soldQuantity;
      this.isSold = isSold;
    }

    public string GetOfferDetails() {
      return "Company: " + company.CompanyName + " Product: " +
             product.type.name
             + " Quantity: " + quantity + " Price: " + price;
    }

    public void Sell(int quantityToBuy) {
      this.soldQuantity = quantityToBuy;
      this.isSold = true;
      this.quantity -= quantityToBuy;
    }
  }
}
