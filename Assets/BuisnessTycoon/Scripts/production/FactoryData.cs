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
    public FactorySo Factory { get; }
    public int CurrentOutput { get; private set; }
    private int turnBuilt;
    public FactoryData(FactorySo factory, int currentTurn) {
      Factory = factory;
      CurrentOutput = 0;
      turnBuilt = currentTurn;
    }
    public void AdvanceTurn(int currentTurn) {
      if (Factory.FactoryType == FactoryType.Build &&
          currentTurn >= turnBuilt + Factory.SetupTime)
        CurrentOutput = Factory.OutputPerQuarter;

      if (Factory.FactoryType == FactoryType.Rent &&
          currentTurn >= turnBuilt + Factory.SetupTime)
        CurrentOutput = Factory.OutputPerQuarter;
    }
    public int CalculateProductionCost() {
      if (Factory.FactoryType == FactoryType.Build)
        return CurrentOutput * Factory.LaborCostPerUnit +
               Factory.MaintenancePerQuarter;
      if (Factory.FactoryType == FactoryType.Rent) return CurrentOutput * Factory.OutsourcingFeePerUnit + Factory.MaintenancePerQuarter;

      return 0;
    }
    public void ResetOutput() {
      CurrentOutput = 0;
    }
  }
}
