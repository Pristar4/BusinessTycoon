#region Info
// -----------------------------------------------------------------------
// TurnStateMachine.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
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

    public TurnStateMachine(
        List<Company> companies, MarketManager marketManager,
        UIManager uiManager, PlayerManager playerManager,
        TurnManager turnManager) {
      idleTurnState = new IdleTurnState();
      idleTurnState.Initialize(this);

      productionTurnState
          = new ProductionTurnState(companies, uiManager, playerManager,
                                    turnManager);
      productionTurnState.Initialize(this);
      createOfferTurnState
          = new CreateOfferTurnState(uiManager, playerManager, turnManager);
      createOfferTurnState.Initialize(this);
      aiCreateOfferTurnState
          = new AiCreateOfferTurnState(companies, marketManager, uiManager,
                                       playerManager,
                                       turnManager);
      aiCreateOfferTurnState.Initialize(this);
      chooseOfferTurnState = new ChooseOfferTurnState();
      chooseOfferTurnState.Initialize(this);
      showOfferTurnState = new ShowOfferTurnState();
      showOfferTurnState.Initialize(this);
      aiChooseOfferTurnState
          = new AiChooseOfferTurnState(marketManager, uiManager, playerManager,
                                       turnManager);
      aiChooseOfferTurnState.Initialize(this);
      offerResultTurnState = new OfferResultTurnState();
      offerResultTurnState.Initialize(this);
      deconstructOfferTurnState
          = new DeconstructOfferTurnState(turnManager, marketManager, uiManager,
                                          playerManager);
      deconstructOfferTurnState.Initialize(this);
      currentState = idleTurnState;
    }

    public void SetTurnState(TurnState newState) {
      if (currentState == null || currentState == newState ||
          newState == null) {
        Debug.Log("TurnState not changed");
        return;
      }

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
      currentState.Update();
    }

    #region Fields
    private readonly TurnState idleTurnState;
    private readonly TurnState productionTurnState;
    private readonly TurnState createOfferTurnState;
    private readonly TurnState aiCreateOfferTurnState;
    private readonly TurnState chooseOfferTurnState;
    private readonly TurnState showOfferTurnState;
    private readonly TurnState aiChooseOfferTurnState;
    private readonly TurnState offerResultTurnState;
    private readonly TurnState deconstructOfferTurnState;
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
      return aiChooseOfferTurnState;
    }

    public TurnState OfferResultTurnState() {
      return offerResultTurnState;
    }

    public TurnState DeconstructOfferTurnState() {
      return deconstructOfferTurnState;
    }
    #endregion
  }
}
