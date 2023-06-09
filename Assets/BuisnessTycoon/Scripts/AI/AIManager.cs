#region Info
// -----------------------------------------------------------------------
// AIManager.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
using System.Collections.Generic;
using BT.Scripts.production;
using UnityEngine;

namespace BT.Scripts.AI {
  internal class AIManager : MonoBehaviour {

    private List<Company> npcCompanies;

    public void Initialize(List<Company> npcCompanies) {
      this.npcCompanies = npcCompanies;
    }

    public Company CreateCompany(Company companyPrefab, int i) {
      var newCompany = Instantiate(companyPrefab);
      newCompany.CompanyName = "NPC " + i;
      return newCompany;
    }
  }
}
