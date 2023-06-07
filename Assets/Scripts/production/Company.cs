#region Info
// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  public class Company : MonoBehaviour {
    [SerializeField] private List<ProductData> inventory;

    [SerializeField] private string companyName = "DefaultCompany";
    private FactorySo factory;

    public Company() {
      // make sure the inventory is initialized
      inventory = new List<ProductData>();
    }

    public string CompanyName {
      get => companyName;
      set => companyName = value;
    }

    [SerializeField] public Finance Finance { get; set; } = new Finance();

    public List<ProductData> GetFactories() {
      if (inventory == null) { inventory = new List<ProductData>(); }

      var foundFactories = inventory
          .FindAll(data => data.type is FactorySo)
          .Select(data => new ProductData(data.type, data.amount)).ToList();
      
      return foundFactories;

    }

    public void RunTurn(Market market) {

      // Production
      foreach (var factory in GetFactories()) {
        ProductData product = factory.Produce();
        // Add the product to the inventory
      }

      // Sales
      foreach (var product in inventory) {
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
      return;
    }

    public void Produce() {
      var factories = GetFactories();

      foreach (var factoryData in factories) {
        if (factoryData.type is FactorySo) {
          factory = factoryData.type as FactorySo;

          for (int i = 0; i < factoryData.amount; i++) {
            if (factory.TryProduce(inventory, out var outputResults)) {

              factory.ConsumeIngredients(ref inventory);

              foreach (var result in outputResults) {
                var existingProduct
                    = inventory.Find(data => data.type == result.type);

                if (existingProduct != null) {
                  existingProduct.amount += result.amount;
                } else { inventory.Add(result); }

              }

              Debug.Log("Produced " + outputResults.Count + " products");

            }

          }

        }


      }
    }

    public void CreateOffer(MarketManager marketManager) {
      throw new System.NotImplementedException();
    }
  }
}
