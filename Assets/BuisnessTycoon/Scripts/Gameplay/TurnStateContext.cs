#region Info
// -----------------------------------------------------------------------
// TurnStateContext.cs
// 
// Felix Jung 09.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.production;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {

// TurnStateContext.cs

  public class TurnStateContext {
    private ITurnState currentState;

    public TurnStateContext(ITurnState initialState) {
      currentState = initialState;
    }

    public void SetTurnState(ITurnState newState) {
      currentState = newState;
      Debug.Log("TurnState changed to " + newState);
    }

    public ITurnState GetTurnState() {
      return currentState;

    }

    public void Update(List<Company> companies, MarketManager marketManager,
                       PlayerManager playerManager, UIManager uiManager,
                       TurnManager turnManager) {
      currentState.Update(this, companies, marketManager, playerManager,
                          uiManager,
                          turnManager);
    }
  }

}
