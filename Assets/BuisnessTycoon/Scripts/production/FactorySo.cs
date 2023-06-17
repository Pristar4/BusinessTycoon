#region Info
// -----------------------------------------------------------------------
// FactorySo.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using Sirenix.OdinInspector;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "new_factory", menuName = "Production/Factory",
      order = 0)]
  public class FactorySo : ScriptableObject {
    #region Serialized Fields
    [ShowInInspector] private FactoryType factoryType;
    [ShowInInspector] private int outputPerQuarter;
    [ShowInInspector] private int buildCost;
    [ShowInInspector] private int setupTime;
    [ShowInInspector] private int outsourcingFeePerUnit;
    [ShowInInspector] private int laborCostPerUnit;
    [ShowInInspector] private int maintenancePerQuarter;
    [ShowInInspector] private float percentageValueRetained;
    [ShowInInspector] private int depreciationTime;
    [ShowInInspector] private string depreciationMethod;
    [SerializeField] public ProductSo productProduced;
    #endregion
    public FactoryType FactoryType => factoryType;
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
