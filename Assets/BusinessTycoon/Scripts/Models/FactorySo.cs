#region Info
// -----------------------------------------------------------------------
// FactorySo.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.Models {
  [CreateAssetMenu(fileName = "new_factory", menuName = "Production/Factory",
      order = 0)]
  public class FactorySo : ScriptableObject {
    #region Serialized Fields
    [SerializeField] public ProductSo productProduced;
    #endregion
    [SerializeField] private int buildCost;
    [SerializeField] private string depreciationMethod;
    [SerializeField] private int depreciationTime;
    [SerializeField] private FactoryType factoryType;
    [SerializeField] private int laborCostPerUnit;
    [SerializeField] private int laborForce;
    [SerializeField] private int maintenancePerQuarter;
    [SerializeField] private int outputPerQuarter;
    [SerializeField] private int outsourcingFeePerUnit;
    [SerializeField] private float percentageValueRetained;
    [SerializeField] private int setupTime;
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
