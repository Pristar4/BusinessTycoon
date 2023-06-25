#region Info
// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.Controller.Managers;
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
    public float CalculateTotalCost() {
      var totalCost = 0f;
      foreach (var factoryData in factoryInventory)
        totalCost += factoryData.CalculateProductionCost();

      return totalCost;
    }
  }
}
