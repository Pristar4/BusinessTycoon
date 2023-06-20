#region Info
// -----------------------------------------------------------------------
// ProductInfo.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
using TMPro;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ProductInfo : MonoBehaviour {
    public TMP_Text productName;
    public TMP_Text contractsAppear;
    public TMP_Text description;
    public TMP_Text priceRange;
    public TMP_Text middlePrice;
    public TMP_Text productDemand;
    public TMP_Text contracts;
    public TMP_Text growthInPricePerQuarter;
    public TMP_Text growthPerQuarter;
  }
}
