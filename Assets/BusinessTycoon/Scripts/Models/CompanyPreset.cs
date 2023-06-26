#region Info

// -----------------------------------------------------------------------
// CompanyPreset.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace BT {
    [CreateAssetMenu(fileName = "New CompanyPreset", menuName = "CompanyPreset",
                     order = 0)]
    public class CompanyPreset : ScriptableObject {
        #region Serialized Fields

        // preset for inventory of company
        [SerializeField] public List<ProductData> startingProductInventory;
        [SerializeField] public List<FactoryData> startingFactoryInventory;
        [SerializeField] public int startingBalance;
        [SerializeField] public string companyName;

        #endregion

        public CompanyPreset(List<ProductData> startingProductInventory,
                             List<FactoryData> startingFactoryInventory,
                             int startingBalance, string companyName) {
            this.startingProductInventory = startingProductInventory;
            this.startingFactoryInventory = startingFactoryInventory;
            this.startingBalance = startingBalance;
            this.companyName = companyName;
        }
    }
}