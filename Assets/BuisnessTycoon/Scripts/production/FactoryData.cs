#region Info
// -----------------------------------------------------------------------
// FactoryData.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
#endregion

namespace BT.Scripts.production {
  [Serializable]
  public class FactoryData {
    #region Serialized Fields
    public int amount;

    public FactorySo type;
    #endregion

    public FactoryData(FactorySo type, int amount) {
      this.type = type;
      this.amount = amount;
    }
  }
}