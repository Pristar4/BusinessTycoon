#region Info
// -----------------------------------------------------------------------
// PlayerManager.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class PlayerManager : MonoBehaviour {

    public Company PlayerCompany { get; private set; }

    public void Initialize(Company startup) {
      PlayerCompany = startup;
    }

    public Company CreateCompany(Company companyPrefab) {
      var newCompany = Instantiate(companyPrefab);
      newCompany.CompanyName = "Player";
      return newCompany;

    }
  }
}
