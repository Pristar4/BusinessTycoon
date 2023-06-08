#region Info
// -----------------------------------------------------------------------
// MarketManager.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
using BT.Scripts.production;
using UnityEngine;

namespace BT.Scripts {
  public class MarketManager: MonoBehaviour {

    public Market Market { get; set; }

    public void Initialize() {
      Market = new Market();
    }

    public void UpdateMarket() {
      Market.UpdateMarket();
    }
  }
}
