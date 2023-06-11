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
    public int Amount { get; }

    public FactorySo Type { get; }
    #endregion

    public FactoryData(FactorySo type, int amount) {
      Type = type;
      Amount = amount;
    }
  }
}
