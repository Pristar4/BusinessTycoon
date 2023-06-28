#region Info

// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using BT.Managers;
using UnityEngine;

#endregion

namespace BT {
    public enum CompanyState {
        Active,
        Bankrupt,
        Disabled,
    }

    
    public class Company : MonoBehaviour {
        #region Serialized Fields

        [SerializeField] private Finance finance;
        [SerializeField] private List<ProductData> productInventory;
        [SerializeField] private List<FactoryData> factoryInventory;
        [SerializeField] private string companyName = "DefaultCompany";

        #endregion

        //public get private set

        [SerializeField]
        private CompanyState state = CompanyState.Active;

        public CompanyState State
        {
            get => state;
            private set => state = value;
        }

        public List<ProductData> ProductInventory => productInventory;

        public List<FactoryData> FactoryInventory
        {
            get => factoryInventory;
            set => factoryInventory = value;
        }

        private List<Offer> Offers { get; } = new();

        public string CompanyName
        {
            get => companyName;
            set => companyName = value;
        }

        public Finance Finance
        {
            get => finance;
            set => finance = value;
        }

        public void ApplyCosts() {
            float totalCost = CalculateTotalCost();
            decimal decTotalCost = (decimal)totalCost;

            if (decTotalCost > Finance.Balance) {
                // If total costs exceed the balance, set the balance to 0 and make the company bankrupt
                Finance.Balance = 0;
                Debug.Log($"<color=red>Company {companyName} is bankrupt </color>", this);
                State = CompanyState.Bankrupt;
            } else {
                // If total costs do not exceed the balance, remove the appropriate amount of money
                RemoveMoney(decTotalCost);
            }
        }

        public void Disable() {
            if (state == CompanyState.Bankrupt) {
                state = CompanyState.Disabled;
            } else {
                Debug.LogError("Cannot disable active or nonexistent entity");
            }
        }

        public void AddToProductInventory(ProductData product) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot add to inventory. Company is not in active state.");
                return;
            }

            if (product == null) {
                Debug.LogError("Product is null");
                return;
            }

            productInventory.Add(product);
        }

        public void RemoveFromProductInventory(ProductData productData) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot remove to inventory. Company is not in active state.");
                return;
            }

            productInventory.Remove(productData);
        }

        public void BuyFactory(FactorySo factorySo, int currentTurn) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot buy factory. Company is not in active state.");
                return;
            }
            var newFactory = new FactoryData(factorySo, currentTurn);
            factoryInventory.Add(newFactory);
        }

        public float EstimateTotalCostAfterBuying(FactorySo newFactory, int currentTurn) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot estimate total cost. Company is not in active state.");
                return 0f;
            }
            var tempInventory = new List<FactoryData>(factoryInventory);
            tempInventory.Add(new FactoryData(newFactory, currentTurn));

            float totalCost = 0f;
            foreach (var factoryData in tempInventory)
                totalCost += factoryData.CalculateProductionCost();

            return totalCost;
        }


        public void Produce() {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot produce. Company is not in active state.");
                return;
            }
            foreach (var factoryData in FactoryInventory) {
                if (factoryData.EndSetupTurn >
                    ManagerProvider.Current.TurnManager.CurrentTurn)
                    continue;
                // This assumes that one factory always produces one unit of output per quarter
                AddProductToInventory(factoryData.Factory.productProduced.name,
                                      factoryData.CurrentOutput);
#if UNITY_EDITOR
                // Debug.Log(
                //         $"Produced {factoryData.CurrentOutput} units of {factoryData.Factory.productProduced.name}");
#endif
            }
        }

        private void AddProductToInventory(string productType, int amountProduced) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot add product to inventory. Company is not in active state.");
                return;
            }
            var existingProduct
                    = productInventory.Find(data => data.Type.name == productType);

            if (existingProduct != null) {
                existingProduct.Quantity += amountProduced;
            } else {
                // Assuming that you have a reference to the MarketManager
                var newProductSo
                        = ManagerProvider.Current.MarketManager.GetProductByName(
                                productType);
                productInventory.Add(new ProductData(newProductSo, amountProduced));
            }
        }

        public void CreateOffer(MarketManager marketManager) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot create offer. Company is not in active state.");
                return;
            }
            foreach (var product in productInventory) {
                if (product.Quantity <= 0) continue;
                var offer = new Offer(this, product, product.Quantity,
                                      product.Type.MiddlePrice);
                Offers.Add(offer);
                marketManager.AddOffer(offer);
            }
        }

        public void AddMoney(decimal amount) {
            Finance.Balance += amount;
        }

        public void RemoveMoney(decimal amount) {
            Finance.Balance -= amount;
        }

        public void RemoveProduct(ProductSo productType, int quantityToBuy) {
            if (state != CompanyState.Active) {
                Debug.LogError("Cannot remove product. Company is not in active state.");
                return;
            }
            var product = productInventory.Find(data => data.Type == productType);
            product.Quantity -= quantityToBuy;

            if (product.Quantity <= 0) productInventory.Remove(product);
        }

        public float CalculateTotalCost() {
            float totalCost = 0f;
            foreach (var factoryData in factoryInventory)
                totalCost += factoryData.CalculateProductionCost();

            return totalCost;
        }
    }
}