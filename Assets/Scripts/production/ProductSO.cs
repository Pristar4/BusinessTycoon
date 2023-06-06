#region Info
// -----------------------------------------------------------------------
// product.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
using UnityEngine;

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "new_product", menuName = "Production/Product", order = 0)]
  public class ProductSo : ScriptableObject {
    [SerializeField] private  string productName;
    
  }
}
