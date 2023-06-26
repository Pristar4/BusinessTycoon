#region Info
// -----------------------------------------------------------------------
// AIManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.BusinessTycoon.Scripts.Models;
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.Controller.Managers {
  public class AIManager : MonoBehaviour, IManager {
    #region IManager Members
    public void Initialize() {
      // implement initialization of AI
    }
    #endregion
    public Company CreateCompany(Company companyPrefab, int i) {
      var newCompany = Instantiate(companyPrefab);
      newCompany.CompanyName = "NPC " + i;
      return newCompany;
    }
  }
}
