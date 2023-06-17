#region Info
// -----------------------------------------------------------------------
// AIManager.cs
// 
// Felix Jung 17.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.production;
using UnityEngine;
#endregion

namespace BT.Scripts.AI {
  internal class AIManager : MonoBehaviour {
    public void Initialize(List<Company> companies) {
      // implement initialization of AI
    }
    public Company CreateCompany(Company companyPrefab, int i) {
      var newCompany = Instantiate(companyPrefab);
      newCompany.CompanyName = "NPC " + i;
      return newCompany;
    }
  }
}
