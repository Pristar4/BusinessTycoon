#region Info
// -----------------------------------------------------------------------
// ProductData.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
#region
#endregion

namespace BT.Scripts.production {
  
  [System.Serializable]
  public class ProductData {
    public int amount;
    public ProductSo type;

    public ProductData(ProductSo type, int amount) {
      this.type = type;
      this.amount = amount;
    }
    public decimal TotalValue() {
      return type.value * amount;
    }
    
    public decimal TotalProductionCost 
    {
      get { return type.ProductionCost * amount; }
    }

    public void Sell(int quantity)
    {
      if (quantity <= amount)
      {
        amount -= quantity;
      }
      else
      {
        throw new System.Exception("Not enough products to sell");
      }
    }

    public ProductData Produce() {
      throw new System.NotImplementedException();
    }
  }
}
