#region Info
// -----------------------------------------------------------------------
// FactorySo.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "new_factory", menuName = "Production/Factory",
      order = 0)]
  public class FactorySo : ScriptableObject {
    #region Serialized Fields
    [SerializeField] private FactoryType factoryType;
    [SerializeField] private int outputPerQuarter;
    [SerializeField] private int buildCost;
    [SerializeField] private int setupTime;
    [SerializeField] private int outsourcingFeePerUnit;
    [SerializeField] private int laborCostPerUnit;
    [SerializeField] private int maintenancePerQuarter;
    [SerializeField] private float percentageValueRetained;
    [SerializeField] private int depreciationTime;
    [SerializeField] private string depreciationMethod;
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
