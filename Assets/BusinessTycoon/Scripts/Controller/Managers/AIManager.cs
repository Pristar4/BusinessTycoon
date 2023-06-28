#region Info

// -----------------------------------------------------------------------
// AIManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace BT.Managers {
    public class AIManager : MonoBehaviour, IManager {
        #region IManager Members

        public void Initialize() {
            // implement initialization of AI
        }

        #endregion

        public Company CreateCompany(Company companyPrefab, CompanyPreset npcCompanyPreset, int i) {
            var newCompany = Instantiate(companyPrefab);
            newCompany.CompanyName = "NPC " + i;
            newCompany.Finance.Balance = npcCompanyPreset.startingBalance;

            // Deep copy of the ProductData list
            foreach (var productData in npcCompanyPreset.startingProductInventory) {
                newCompany.AddToProductInventory(productData);
            }

            newCompany.FactoryInventory = new List<FactoryData>();

            foreach (var factoryData in npcCompanyPreset.startingFactoryInventory) {
                // Get the corresponding FactorySo from the FactoryData
                var factorySo = factoryData.Factory;

                // Create a new FactoryData instance and set its properties
                var newFactoryData = new FactoryData(factorySo,
                                                     ManagerProvider.Current.TurnManager
                                                             .CurrentTurn) {
                    CurrentOutput = factoryData.CurrentOutput, // Set the current output if necessary
                };
                newCompany.FactoryInventory.Add(newFactoryData);
            }

            return newCompany;
        }
    }
}