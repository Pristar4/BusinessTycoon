#region Info
// -----------------------------------------------------------------------
// Company.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  public class Company : MonoBehaviour {
    [SerializeField] private readonly List<ProductData> inventory;

    public List<ProductData> GetFactories() {
      return inventory.FindAll(data => data.type is FactorySo);
    }
    
  }
}
