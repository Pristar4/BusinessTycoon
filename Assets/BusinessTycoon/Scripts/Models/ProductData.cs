#region Info
// -----------------------------------------------------------------------
// ProductData.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using UnityEngine;
#endregion

namespace BT.Scripts.Models {
  [Serializable]
  public class ProductData {
    #region Serialized Fields
    [SerializeField]
    private int amount;
    [SerializeField]
    private ProductSo type;
    #endregion
    public ProductData(ProductSo type, int amount) {
      this.type = type;
      this.amount = amount;
    }

    public int Amount {
      get => amount;
      set => amount = value;
    }

    public ProductSo Type => type;
  }
}
