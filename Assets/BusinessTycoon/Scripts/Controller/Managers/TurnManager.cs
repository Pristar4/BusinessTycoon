#region Info
// -----------------------------------------------------------------------
// TurnManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.Controller.Managers {
  public class TurnManager : MonoBehaviour, IManager {
    public int CurrentTurn { get; private set; }
    #region IManager Members
    public void Initialize() {
      CurrentTurn = 1;
    }
    #endregion
    public void AdvanceTurn() {
      CurrentTurn++;
    }
  }
}
