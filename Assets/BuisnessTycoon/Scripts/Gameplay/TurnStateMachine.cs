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

    public TurnStateMachine(TurnState initialState, List<Company> companies,
                            MarketManager marketManager, UIManager uiManager,
                            PlayerManager playerManager,
                            TurnManager turnManager) {
      currentState = initialState;
      idleTurnState = new IdleTurnState();
      productionTurnState = new ProductionTurnState(companies, uiManager,
                                                    playerManager,
                                                    turnManager);
      createOfferTurnState = new CreateOfferTurnState(uiManager, playerManager,
                                                      turnManager);
      aiCreateOfferTurnState = new AiCreateOfferTurnState(companies,
                                                          marketManager,
                                                          uiManager,
                                                          playerManager,
                                                          turnManager);
      chooseOfferTurnState = new ChooseOfferTurnState();
      showOfferTurnState = new ShowOfferTurnState();
      aiChooseOfferTurnState = new AiChooseOfferTurnState(marketManager,
                                                          uiManager,
                                                          playerManager,
                                                          turnManager);
      offerResultTurnState = new OfferResultTurnState();
      deconstructOfferTurnState = new DeconstructOfferTurnState(turnManager,
                                                                marketManager,
                                                                uiManager,
                                                                playerManager);
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
