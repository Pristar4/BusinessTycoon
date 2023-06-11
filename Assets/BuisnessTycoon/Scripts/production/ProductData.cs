#region Info
// -----------------------------------------------------------------------
// ProductData.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
#endregion

namespace BT.Scripts.production {

  [Serializable]
  public class ProductData {
    #region Serialized Fields
    public int Amount { get; set; }
    public ProductSo Type { get; }
    #endregion

    public ProductData(ProductSo type, int amount) {
      Type = type;
      Amount = amount;
    }

  }
}
