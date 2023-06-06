#region Info
// -----------------------------------------------------------------------
// Product.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
#region
#endregion

namespace BT.Scripts.production {
  public struct ProductData {
    public int amount;
    public ProductSo type;

    public ProductData(ProductSo type, int amount) {
      this.type = type;
      this.amount = amount;
    }
  }
}
