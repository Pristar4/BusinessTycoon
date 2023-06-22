#region Info
// -----------------------------------------------------------------------
// GameEventHandler.cs
// 
// Felix Jung 22.06.2023
// -----------------------------------------------------------------------
#endregion
namespace BT.Scripts.Managers {
  public interface IGameEventHandler {
    //end turn 
    void OnEndTurn();

    //start turn
    void OnStartTurn();
  }
}
