#region Info

// -----------------------------------------------------------------------
// TurnState.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using BT.Managers;
using BT.Managers.BT.Scripts.Gameplay;
using UnityEngine;

#endregion

namespace BT {
    public abstract class TurnState {
        protected TurnStateMachine machine;

        public virtual void Initialize(TurnStateMachine stateMachine) {
            machine = stateMachine;
        }

        public virtual void Update() {}
        public virtual void OnEnter() {}
        public virtual void OnExit() {}
    }
    [Serializable]
    public class IdleTurnState : TurnState {
        public IdleTurnState(UIManager uiManager) {
            uiManager.OnEndTurnPressed += EndTurn;
        }

        public override void Update() {}

        private void EndTurn() {
            machine.SetTurnState(machine.ProductionTurnState());
        }
    }

    [Serializable]
    public class ProductionTurnState : TurnState {
        private List<Company> companies;
        private PlayerManager playerManager;
        private TurnManager turnManager;
        private UIManager uiManager;

        public ProductionTurnState(List<Company> companies, UIManager
                                           uiManager,
                                   PlayerManager playerManager,
                                   TurnManager turnManager) {
            this.companies = companies;
            this.uiManager = uiManager;
            this.playerManager = playerManager;
            this.turnManager = turnManager;
        }

        public override void Update() {
            foreach (var company in companies) {
                if (company.State == CompanyState.Active) {
                    company.Produce();
                    
                }
            }

            uiManager.UpdateUI(playerManager.PlayerCompany,
                               turnManager.CurrentTurn);
            machine.SetTurnState(machine.CreateOfferTurnState());
        }
    }
    [Serializable]
    public class CreateOfferTurnState : TurnState {
        private PlayerManager playerManager;
        private TurnManager turnManager;
        private UIManager uiManager;

        public CreateOfferTurnState(UIManager uiManager,
                                    PlayerManager playerManager,
                                    TurnManager turnManager) {
            this.uiManager = uiManager;
            this.playerManager = playerManager;
            this.turnManager = turnManager;
        }

        public override void Update() {
            uiManager.UpdateUI(playerManager.PlayerCompany, turnManager.CurrentTurn);

            machine.SetTurnState(machine.AiCreateOfferTurnState());
        }

        public override void OnEnter() {
            // show offer panel
        }

        public override void OnExit() {
            // hide offer panel
        }
    }
    [Serializable]
    public class AiCreateOfferTurnState : TurnState {
        private List<Company> companies;
        private MarketManager marketManager;
        private PlayerManager playerManager;
        private TurnManager turnManager;
        private UIManager uiManager;

        public AiCreateOfferTurnState(List<Company> companies,
                                      MarketManager marketManager,
                                      UIManager uiManager,
                                      PlayerManager playerManager,
                                      TurnManager turnManager) {
            this.companies = companies;
            this.marketManager = marketManager;
            this.uiManager = uiManager;
            this.playerManager = playerManager;
            this.turnManager = turnManager;
        }

        public override void Update() {
            foreach (var company in companies)
                if (company.State == CompanyState.Active) {
                    company.CreateOffer(marketManager);
                }

            uiManager.UpdateUI(playerManager.PlayerCompany,
                               turnManager.CurrentTurn);

            machine.SetTurnState(machine.ChooseOfferTurnState());
        }
    }
    [Serializable]
    public class ChooseOfferTurnState : TurnState {
        public override void Update() {
            machine.SetTurnState(machine.ShowOfferTurnState());
        }
    }
    [Serializable]
    public class ShowOfferTurnState : TurnState {
        public override void Update() {
            machine.SetTurnState(machine.AiChooseOfferTurnState());
        }
    }
    [Serializable]
    public class AiChooseOfferTurnState : TurnState {
        private MarketManager marketManager;
        private PlayerManager playerManager;
        private TurnManager turnManager;
        private UIManager uiManager;

        public AiChooseOfferTurnState(MarketManager marketManager,
                                      UIManager uiManager,
                                      PlayerManager playerManager,
                                      TurnManager turnManager) {
            this.marketManager = marketManager;
            this.uiManager = uiManager;
            this.playerManager = playerManager;
            this.turnManager = turnManager;
        }

        public override void Update() {
            marketManager.UpdateMarket();
            uiManager.UpdateUI(playerManager.PlayerCompany,
                               turnManager.CurrentTurn);

            machine.SetTurnState(machine.OfferResultTurnState());
        }
    }
    [Serializable]
    public class OfferResultTurnState : TurnState {
        public override void Update() {
            machine.SetTurnState(machine.DeconstructOfferTurnState());
        }
    }
    [Serializable]
    public class DeconstructOfferTurnState : TurnState {
        private MarketManager marketManager;
        private PlayerManager playerManager;
        private TurnManager turnManager;
        private UIManager uiManager;
        private List<Company> companies;

        public DeconstructOfferTurnState(TurnManager turnManager,
                                         MarketManager marketManager,
                                         UIManager uiManager,
                                         PlayerManager playerManager, List<Company> companies) {
            this.turnManager = turnManager;
            this.marketManager = marketManager;
            this.uiManager = uiManager;
            this.playerManager = playerManager;
            this.companies = companies;
        }

        public override void Update() {
            // costs applied
            foreach (var company in companies) {
                if (company.State == CompanyState.Active) {
                    company.ApplyCosts();
                    
                }
            }

            turnManager.AdvanceTurn();
            marketManager.ClearOffers();

            uiManager.UpdateUI(playerManager.PlayerCompany,
                               turnManager.CurrentTurn);
            machine.SetTurnState(machine.IdleTurnState());
        }
    }
}