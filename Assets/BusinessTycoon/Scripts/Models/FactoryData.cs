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

namespace BT.Scripts.Models {
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
        return currentOutput * factory.LaborCostPerUnit +
               factory.MaintenancePerQuarter;
      if (factory.FactoryType == FactoryType.Rent)
        return currentOutput * factory.OutsourcingFeePerUnit +
               factory.MaintenancePerQuarter;

      return 0;
    }
    public void ResetOutput() {
      currentOutput = 0;
    }
  }
}
