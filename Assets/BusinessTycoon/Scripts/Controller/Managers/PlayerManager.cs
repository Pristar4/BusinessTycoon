#region Info
// -----------------------------------------------------------------------
// PlayerManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.BusinessTycoon.Scripts.Models;
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.Controller.Managers {
  public class PlayerManager : MonoBehaviour, IManager {
    public static PlayerManager Instance { get; }
    public Company PlayerCompany { get; private set; }
    #region IManager Members

    #endregion
    public Company GetPlayerCompany() {
      return PlayerCompany;
    }
    public void Initialize() {
      // Intentionally left blank
    }
    public void Initialize(Company startup) {
      PlayerCompany = startup;
    }
  }
}
