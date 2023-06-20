#region Info
// -----------------------------------------------------------------------
// ProductData.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  [Serializable]
  public class ProductData {
    [SerializeField]
    private int amount;

    [SerializeField]
    private ProductSo type;

    public int Amount {
      get => amount;
      set => amount = value;
    }

    public ProductSo Type => type;

    public ProductData(ProductSo type, int amount) {
      this.type = type;
      this.amount = amount;
    }
  }
}
