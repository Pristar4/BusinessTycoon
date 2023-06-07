#region Info
// -----------------------------------------------------------------------
// TurnManager.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
using UnityEngine;

namespace BT.Scripts {
  public class TurnManager : MonoBehaviour {

    public int CurrentTurn { get; set; }

    public void Initialize() {
      CurrentTurn = 0;
    }

    public void AdvanceTurn() {
      CurrentTurn++;
    }
  }
}
