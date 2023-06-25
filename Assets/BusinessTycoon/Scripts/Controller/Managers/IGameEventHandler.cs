#region Info
// -----------------------------------------------------------------------
// GameEventHandler.cs
// 
// Felix Jung 22.06.2023
// -----------------------------------------------------------------------
#endregion
namespace BT.BusinessTycoon.Scripts.Controller.Managers {
  public interface IGameEventHandler {
    //end turn 
    void OnEndTurn();

    //start turn
    void OnStartTurn();
  }
}
