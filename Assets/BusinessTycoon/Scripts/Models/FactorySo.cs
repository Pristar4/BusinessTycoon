#region Info
// -----------------------------------------------------------------------
// FactorySo.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#if ODIN_INSPECTOR
#endif
#endregion

namespace BT.Scripts.Models {
  [CreateAssetMenu(fileName = "new_factory", menuName = "Production/Factory",
      order = 0)]
  public class FactorySo : ScriptableObject {
    #region Serialized Fields
    [SerializeField] public ProductSo productProduced;
    #region Odin Inspector
    #if ODIN_INSPECTOR
    [ShowInInspector] private int buildCost;
    [ShowInInspector] private string depreciationMethod;
    [ShowInInspector] private int depreciationTime;
    [ShowInInspector] private FactoryType factoryType;
    [ShowInInspector] private int laborCostPerUnit;
    [ShowInInspector] private int maintenancePerQuarter;
    [ShowInInspector] private int outputPerQuarter;
    [ShowInInspector] private int outsourcingFeePerUnit;
    [ShowInInspector] private float percentageValueRetained;
    [ShowInInspector] private int setupTime;
    #endif
    #endregion
    #if !ODIN_INSPECTOR
    private int buildCost;
    [SerializeField] private string depreciationMethod;
    [SerializeField] private int depreciationTime;
    [SerializeField] private FactoryType factoryType;
    [SerializeField] private int laborCostPerUnit;
    [SerializeField] private int maintenancePerQuarter;
    [SerializeField] private int outputPerQuarter;
    [SerializeField] private int outsourcingFeePerUnit;
    [SerializeField] private float percentageValueRetained;
    [SerializeField] private int setupTime;
    #endif
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
