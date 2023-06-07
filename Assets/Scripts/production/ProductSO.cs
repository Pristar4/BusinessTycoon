#region Info
// -----------------------------------------------------------------------
// product.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
using System.Collections.Generic;
using UnityEngine;

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "new_product", menuName = "Production/Product", order = 0)]
  public class ProductSo : ScriptableObject {
    [SerializeField] private  string productName;
    public int value;

    public int ProductionCost { get; set; }
    public int SellPrice { get; set; }
    public float Demand { get; set; }
    public int ProductionTime { get; set; }
    public List<RawMaterial> RawMaterialsRequired { get; set; }

  }
  public class RawMaterial {}
}
