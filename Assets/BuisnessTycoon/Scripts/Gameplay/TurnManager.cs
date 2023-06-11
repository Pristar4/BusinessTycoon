#region Info
// -----------------------------------------------------------------------
// TurnManager.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class TurnManager : MonoBehaviour {

    public int CurrentTurn { get; private set; }

    public void Initialize() {
      CurrentTurn = 0;
    }

    public void AdvanceTurn() {
      CurrentTurn++;
    }
  }
}