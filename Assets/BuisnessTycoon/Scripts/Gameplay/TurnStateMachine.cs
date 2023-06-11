#region Info
// -----------------------------------------------------------------------
// TurnStateMachine.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.Gameplay.BT.Scripts.Gameplay;
using BT.Scripts.production;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
// TurnStateMachine.cs
  public class TurnStateMachine {
    private TurnState currentState;
    #region Fields
    private TurnState idleTurnState;
    private TurnState productionTurnState;
    private TurnState createOfferTurnState;
    private TurnState aiCreateOfferTurnState;
    private TurnState chooseOfferTurnState;
    private TurnState showOfferTurnState;
    private TurnState aichooseOfferTurnState;
    private TurnState offerResultTurnState;
    private TurnState deconstructOfferTurnState;
    #endregion
    #region Properties
    public TurnState IdleTurnState() {
      return idleTurnState;
    }
    public TurnState ProductionTurnState() {
      return productionTurnState;
    }
    public TurnState CreateOfferTurnState() {
      return createOfferTurnState;
    }
    public TurnState AiCreateOfferTurnState() {
      return aiCreateOfferTurnState;
    }
    public TurnState ChooseOfferTurnState() {
      return chooseOfferTurnState;
    }
    public TurnState ShowOfferTurnState() {
      return showOfferTurnState;
    }
    public TurnState AiChooseOfferTurnState() {
      return aichooseOfferTurnState;
    }
    public TurnState OfferResultTurnState() {
      return offerResultTurnState;
    }
    public TurnState DeconstructOfferTurnState() {
      return deconstructOfferTurnState;
    }
    #endregion
    public TurnStateMachine(TurnState initialState) {
      currentState = initialState;
    }
    public void SetTurnState(TurnState newState) {
      currentState.OnExit();
      currentState = newState;
      newState.OnEnter();
      Debug.Log("TurnState changed to " + newState);
    }
    public TurnState GetTurnState() {
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
