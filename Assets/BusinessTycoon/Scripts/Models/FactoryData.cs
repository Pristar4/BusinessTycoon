using System;
using UnityEngine;

namespace BT
{
    /// <summary>
    /// Holds data for a factory.
    /// </summary>
    [Serializable] public class FactoryData 
    {
        #region Serialized Fields

        [SerializeField] private FactorySo factory;
        [SerializeField] private int initialOutput;
        [SerializeField] private int currentOutput;
        [SerializeField] private int turnBuilt;

        #endregion

        private const float WagePerHour = 0.11f;
        private const int HoursPerQuarter = 528;

        public FactoryData(FactorySo factory, int currentTurn)
        {
            this.factory = factory;
            initialOutput = factory.OutputPerQuarter;
            currentOutput = initialOutput;
            turnBuilt = currentTurn;
        }

        public FactorySo Factory => factory;
        public int InitialOutput => initialOutput;

        public int CurrentOutput
        {
            get => currentOutput;
            set => currentOutput = value;
        }

        public int TurnBuilt => turnBuilt;
        public int EndSetupTurn => turnBuilt + factory.SetupTime;

        public void AdvanceTurn(int currentTurn)
        {
            if ((factory.FactoryType == FactoryType.Build || factory.FactoryType == FactoryType.Rent) && currentTurn >= EndSetupTurn)
            {
                currentOutput = factory.OutputPerQuarter;
            }
        }

        public int CalculateProductionCost()
        {
            if (factory.FactoryType == FactoryType.Build || factory.FactoryType == FactoryType.Rent)
            {
                int perUnitCost = currentOutput * factory.productProduced.MaterialCostPerUnit;
                int costMultiplicator = factory.FactoryType == FactoryType.Build ? factory.LaborCostPerUnit : factory.OutsourcingFeePerUnit;
                return currentOutput * costMultiplicator + perUnitCost + factory.MaintenancePerQuarter;
            }

            return 0;
        }

        public void ResetOutput()
        {
            currentOutput = 0;
        }

        public int GetMaterialCost()
        {
            return currentOutput * Factory.productProduced.MaterialCostPerUnit;
        }

        public float GetLaborCost()
        {
            return Factory.LaborForce * HoursPerQuarter * WagePerHour;
        }
    }
}