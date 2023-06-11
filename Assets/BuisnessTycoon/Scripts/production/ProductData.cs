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
    public int amount;
    public ProductSo type;
    #endregion

    public ProductData(ProductSo type, int amount) {
      this.type = type;
      this.amount = amount;
    }
  }
}