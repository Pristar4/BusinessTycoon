#region Info
// -----------------------------------------------------------------------
// FactoryData.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
using System;

namespace BT.Scripts.production {
  [Serializable]
  public class FactoryData {
    public  int amount;

    public  FactorySo type;

    public FactoryData(FactorySo type, int amount) {
      this.type = type;
      this.amount = amount;
    }
  }
}
