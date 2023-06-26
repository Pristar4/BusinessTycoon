#region Info

// -----------------------------------------------------------------------
// TurnStateMachine.cs
// 
// Felix Jung 22.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using BT.Managers;
using BT.Managers.BT.Scripts.Gameplay;
using UnityEngine;

#endregion

namespace BT {
// TurnStateMachine.cs
    public class TurnStateMachine {
        #region Constructors

        public TurnStateMachine(
                List<Company> companies, MarketManager marketManager,
                UIManager uiManager,
                PlayerManager playerManager, TurnManager turnManager) {
            idleTurnState = new IdleTurnState(uiManager);
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
                                                 playerManager, turnManager);
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

        #endregion

        public void SetTurnState(TurnState newState) {
            if (currentState == null || currentState == newState ||
                newState == null) {
                Debug.Log("TurnState not changed");
                return;
            }

            currentState.OnExit();
            currentState = newState;
            newState.OnEnter();
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

        private readonly TurnState aiChooseOfferTurnState;
        private readonly TurnState aiCreateOfferTurnState;
        private readonly TurnState chooseOfferTurnState;
        private readonly TurnState createOfferTurnState;
        private readonly TurnState deconstructOfferTurnState;
        private readonly TurnState idleTurnState;
        private readonly TurnState offerResultTurnState;
        private readonly TurnState productionTurnState;
        private readonly TurnState showOfferTurnState;
        private TurnState currentState;

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