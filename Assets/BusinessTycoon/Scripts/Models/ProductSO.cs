#region Info
// -----------------------------------------------------------------------
// ProductSO.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#if ODIN_INSPECTOR
#endif
#endregion

namespace BT.Scripts.Models {
  [CreateAssetMenu(fileName = "new_product", menuName = "Production/Product",
      order = 0)]
  public class ProductSo : ScriptableObject {
    public Vector2Int PriceRange => priceRange;
    #if ODIN_INSPECTOR
    
    [ShowInInspector]
    #endif
    public int MiddlePrice => (priceRange.x + priceRange.y) / 2;

    public string ContractsAppear
      =>
          // 4 Quarters per year
          $"Y{contractsAppear / 4 + 1} Q{contractsAppear % 4 + 1}";

    #if ODIN_INSPECTOR
    
    [ShowInInspector]
    #endif
    /*public int GrowthPerQuarter =>
        // Pseudo code:
        // Retrieve the middlePrices for the last four quarters:
        // Calculate the average increase
        // Return the result
        growthPerQuarter;*/
    #region Serialized Fields
    [SerializeField]
    private Vector2Int priceRange;
    private int middlePrice;
    public int contractsAppear;
    public int productDemand;
    public int contracts;
    public int growthInPricePerQuarter;
    public int growthPerQuarter;
    public void CalculateDemand(int currentTurn) {
      // Don't increase demand until contracts appear
      if (currentTurn < contractsAppear)
        productDemand = 0;
      else
        productDemand += growthPerQuarter;

    }
    #endregion
  }
}
