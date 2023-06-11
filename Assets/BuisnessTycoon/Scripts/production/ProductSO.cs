#region Info
// -----------------------------------------------------------------------
// ProductSO.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "new_product", menuName = "Production/Product",
                   order = 0)]
  public class ProductSo : ScriptableObject {
    #region Serialized Fields
    [SerializeField] private string productName;
    public int value;
    #endregion

    public int ProductionCost { get; set; }

    //serialize SellPrice
    [ShowInInspector]
    public int SellPrice { get; set; }

    public float Demand { get; set; }
    public int ProductionTime { get; set; }
    public List<RawMaterial> RawMaterialsRequired { get; set; }
  }
  public class RawMaterial {}
}