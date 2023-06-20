#region Info
// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.Managers;
using UnityEngine;
#endregion

namespace BT.Scripts.Models {
  public class Company : MonoBehaviour {
    #region Serialized Fields
    [SerializeField] private Finance finance;
    [SerializeField] private List<ProductData> productInventory;
    [SerializeField] private List<FactoryData> factoryInventory;
    [SerializeField] private string companyName = "DefaultCompany";
    #endregion
    private FactorySo factory;

    public List<ProductData> ProductInventory {
      get => productInventory;
      set => productInventory = value;
    }

    public List<FactoryData> FactoryInventory {
      get => factoryInventory;
      set => factoryInventory = value;
    }

    private List<Offer> Offers { get; } = new();

    public string CompanyName {
      get => companyName;
      set => companyName = value;
    }

    public Finance Finance { get => finance; set => finance = value; }
    public void Produce() {
      foreach (var factoryData in FactoryInventory) {
        if (factoryData.EndSetupTurn >
            ManagerProvider.Current.TurnManager.CurrentTurn)
          continue;
        // This assumes that one factory always produces one unit of output per quarter
        AddProductToInventory(factoryData.Factory.productProduced.name,
            factoryData.CurrentOutput);
        Debug.Log(
            $"Produced {factoryData.CurrentOutput} units of {factoryData.Factory.productProduced.name}");
      }
    }
    private void AddProductToInventory(string productType, int amountProduced) {
      var existingProduct
          = productInventory.Find(data => data.Type.name == productType);

      if (existingProduct != null) {
        existingProduct.Amount += amountProduced;
      } else {
        // Assuming that you have a reference to the MarketManager
        var newProductSo
            = ManagerProvider.Current.MarketManager.GetProductByName(
                productType);
        productInventory.Add(new ProductData(newProductSo, amountProduced));
      }
    }
    public void CreateOffer(MarketManager marketManager) {
      foreach (var product in productInventory) {
        if (product.Amount <= 0) continue;
        var offer = new Offer(this, product, product.Amount,
            product.Type.MiddlePrice);
        Offers.Add(offer);
        marketManager.AddOffer(offer);
      }
    }
    public void AddMoney(decimal amount) {
      Finance.Balance += amount;
    }
    public void RemoveProduct(ProductSo productType, int quantityToBuy) {

      var product = productInventory.Find(data => data.Type == productType);
      product.Amount -= quantityToBuy;

      if (product.Amount <= 0) productInventory.Remove(product);
    }
  }
  public class Offer {
    public Company company;
    public bool isSold;
    public decimal price;
    public ProductData product;
    public int quantity;
    public int soldQuantity; // TODO: Remove this
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
             product.Type.name
             + " Quantity: " + quantity + " Price: " + price;
    }
    public void Sell(int quantityToBuy) {
      soldQuantity = quantityToBuy;
      isSold = true;
      quantity -= quantityToBuy;
    }
  }
}
