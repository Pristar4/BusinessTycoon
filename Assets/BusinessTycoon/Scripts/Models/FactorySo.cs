#region Info
// -----------------------------------------------------------------------
// FactorySo.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using Sirenix.OdinInspector;
using UnityEngine;
#endregion

namespace BT.Scripts.Models {
  [CreateAssetMenu(fileName = "new_factory", menuName = "Production/Factory",
      order = 0)]
  public class FactorySo : ScriptableObject {
    #region Serialized Fields
    [SerializeField] public ProductSo productProduced;
    #endregion
    [ShowInInspector] private int buildCost;
    [ShowInInspector] private string depreciationMethod;
    [ShowInInspector] private int depreciationTime;
    [ShowInInspector] private FactoryType factoryType;
    [ShowInInspector] private int laborCostPerUnit;
    [ShowInInspector] private int laborForce = 1000;
    [ShowInInspector] private int maintenancePerQuarter;
    [ShowInInspector] private int outputPerQuarter;
    [ShowInInspector] private int outsourcingFeePerUnit;
    [ShowInInspector] private float percentageValueRetained;
    [ShowInInspector] private int setupTime;
    public FactoryType FactoryType => factoryType;
    public int LaborForce => laborForce;
    public int OutputPerQuarter => outputPerQuarter;
    public int BuildCost => buildCost;
    public int SetupTime => setupTime;
    public int OutsourcingFeePerUnit => outsourcingFeePerUnit;
    public int LaborCostPerUnit => laborCostPerUnit;
    public int MaintenancePerQuarter => maintenancePerQuarter;
    public float PercentageValueRetained => percentageValueRetained;
    public int DepreciationTime => depreciationTime;
    public string DepreciationMethod => depreciationMethod;
    public bool CanBenefitFromRD => FactoryType == FactoryType.Build;
    
  }
  public enum FactoryType {
    Build,
    Rent
  }
}
