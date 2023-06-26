#region Info
// -----------------------------------------------------------------------
// FactoryData.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.Models {
  [Serializable]
  public class FactoryData {
    #region Serialized Fields
    [SerializeField]
    private FactorySo factory;
    [SerializeField] private int initialOutput;
    [SerializeField]
    private int currentOutput;
    [SerializeField]
    private int turnBuilt;
    #endregion
    public FactoryData(FactorySo factory, int currentTurn) {
      this.factory = factory;
      initialOutput = factory.OutputPerQuarter;
      currentOutput = initialOutput;
      turnBuilt = currentTurn;
    }
    public FactorySo Factory => factory;
    public int InitialOutput => initialOutput;

    public int CurrentOutput {
      get => currentOutput;
      set => currentOutput = value;
    }

    public int TurnBuilt => turnBuilt;
    public int EndSetupTurn => turnBuilt + factory.SetupTime;
    public void AdvanceTurn(int currentTurn) {
      if (factory.FactoryType == FactoryType.Build &&
          currentTurn >= EndSetupTurn)
        currentOutput = factory.OutputPerQuarter;

      if (factory.FactoryType == FactoryType.Rent &&
          currentTurn >= EndSetupTurn)
        currentOutput = factory.OutputPerQuarter;
    }
    public int CalculateProductionCost() {
      if (factory.FactoryType == FactoryType.Build)
        return currentOutput * factory.LaborCostPerUnit + currentOutput *
               factory.productProduced.MaterialCostPerUnit +
               factory.MaintenancePerQuarter;
      if (factory.FactoryType == FactoryType.Rent)
        return currentOutput * factory.OutsourcingFeePerUnit + currentOutput *
               factory.productProduced.MaterialCostPerUnit +
               factory.MaintenancePerQuarter;

      return 0;
    }
    public void ResetOutput() {
      currentOutput = 0;
    }
    public int CalculateMaterialCost() {
      return currentOutput * Factory.productProduced.MaterialCostPerUnit;

    }
    public float CalculateLaborCost() {
      // 110€ per hour divided by 1000 to make everything in 1000s
      var wage = 0.11f;
      // 8 hours per day, 22 days per month, 3 months per quarter = 528 hours per quarter
      var hoursPerQuarter = 528;
      return Factory.LaborForce * hoursPerQuarter * wage;

    }
  }
}
