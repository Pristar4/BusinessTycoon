#region Info
// -----------------------------------------------------------------------
// ProductInfo.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using TMPro;
using UnityEngine;
#endregion

namespace BT.Scripts.Controller.Gameplay {
  public class ProductInfo : MonoBehaviour {
    #region Serialized Fields
    public TMP_Text productName;
    public TMP_Text contractsAppear;
    public TMP_Text description;
    public TMP_Text priceRange;
    public TMP_Text middlePrice;
    public TMP_Text productDemand;
    public TMP_Text contracts;
    public TMP_Text growthInPricePerQuarter;
    public TMP_Text growthPerQuarter;
    #endregion
  }
}
