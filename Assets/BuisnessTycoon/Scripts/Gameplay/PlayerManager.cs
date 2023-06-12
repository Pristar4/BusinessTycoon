#region Info
// -----------------------------------------------------------------------
// PlayerManager.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using BT.Scripts.production;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class PlayerManager : MonoBehaviour {

    public Company PlayerCompany { get; private set; }

    public void Initialize(Company startup) {
      PlayerCompany = startup;
    }

  }
}
