#region Info
// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 08.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using System.Linq;
using BT.Scripts.Gameplay;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  public class Company : MonoBehaviour {
    #region Serialized Fields
    [SerializeField] private List<ProductData> inventory;
    public List<ProductData> Inventory => inventory;
    
    [SerializeField] private string companyName = "DefaultCompany";
    #endregion
    private FactorySo factory;

    public Company() {
      // make sure the inventory is initialized
      inventory = new List<ProductData>();
    }

    public List<Offer> Offers { get; set; } = new();

    public string CompanyName {
      get => companyName;
      set => companyName = value;
    }

    [SerializeField] public Finance Finance { get; set; } = new();

    private List<ProductData> GetFactories() {
      inventory ??= new List<ProductData>();

      var foundFactories = inventory
          .FindAll(data => data.type is FactorySo)
          .Select(data => new ProductData(data.type, data.amount)).ToList();

      return foundFactories;

    }

    public void RunTurn(MarketManager marketManager) {

      // Production
      
      foreach (var productData in GetFactories()) {
        var product = productData.Produce();
        // Add the product to the inventory
      }

      // Sales
      foreach (var product in inventory) {
        
        marketManager.AddOffer(new Offer(this, product, product.amount, product.type.SellPrice));
        Debug.Log("Added offer to market from RunTurn");
        
        // Check the demand for the product in the market and sell it
        // Update the company's finances based on the revenue
      }

      // Calculate expenses and profits
      Finance.CalculateExpensesAndProfits();

      // Check for random events
      CheckRandomEvents();
      
    }

    
    private void CheckRandomEvents() {
      // throw new System.NotImplementedException();
    }

    public void Produce() {
      var factories = GetFactories();

      foreach (var factoryData in factories) {
        if (factoryData.type is not FactorySo so)
          continue;
        factory = so;
        string product = factory.Results[0].type.name;

        int amount = 0;


        for (int i = 0; i < factoryData.amount; i++) {
          if (factory.TryProduce(inventory, out var outputResults)) {

            factory.ConsumeIngredients(ref inventory);

            foreach (var result in outputResults) {
              var existingProduct
                  = inventory.Find(data => data.type == result.type);

              if (existingProduct != null) {
                existingProduct.amount += result.amount;
                amount += result.amount;
              } else { inventory.Add(result); }
            }
          }

          Debug.Log("Produced " + amount + " " + product);
          amount = 0;
        }
      }
    }

    public void CreateOffer(MarketManager marketManager) {
      foreach (var product in inventory) {
        if (product.amount > 0 && product.type is not FactorySo) {
          
          var offer = new Offer(this, product, product.amount,
                                product.type.SellPrice);
          Debug.Log("Created offer from CreateOffer");
          Offers.Add(offer);
          marketManager.AddOffer(offer);
        }
      }
    }


    public void AddMoney(decimal amount) {
      Finance.Balance += amount;
      
    }

    public void RemoveProduct(ProductSo productType, int quantityToBuy) {
      
      var product = inventory.Find(data => data.type == productType);
      product.amount -= quantityToBuy;
      if (product.amount <= 0) {
        inventory.Remove(product);
      }
    }
  }
  public class Offer {


    public Company company;
    public ProductData product;
    public int quantity;
    public decimal price;
    public int soldQuantity; // TODO: Remove this
    public bool isSold;

    
    

    public Offer(Company company, ProductData product, int quantity, decimal price, int soldQuantity = 0, bool isSold = false) {
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
  }
}
