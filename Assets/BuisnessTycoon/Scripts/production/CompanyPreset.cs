﻿#region Info
// -----------------------------------------------------------------------
// CompanyPreset.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "New CompanyPreset", menuName = "CompanyPreset",
      order = 0)]
  public class CompanyPreset : ScriptableObject {
    // preset for inventory of company
    [SerializeField]
    public List<ProductData> startingProductInventory;
    [SerializeField]
    public int startingBalance;
    [SerializeField]
    public string companyName;
    public CompanyPreset(List<ProductData> startingProductInventory,
                         int startingBalance, string companyName) {
      this.startingProductInventory = startingProductInventory;
      this.startingBalance = startingBalance;
      this.companyName = companyName;
    }
  }
}