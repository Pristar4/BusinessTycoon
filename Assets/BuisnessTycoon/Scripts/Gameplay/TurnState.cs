#region Info
// -----------------------------------------------------------------------
// TurnState.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using System.Collections.Generic;
using BT.Scripts.Gameplay.BT.Scripts.Gameplay;
using BT.Scripts.production;
using UnityEngine.InputSystem;
#endregion

namespace BT.Scripts.Gameplay {
  public abstract class TurnState {
    protected TurnStateMachine machine;

    public virtual void Initialize(TurnStateMachine stateMachine) {
      machine = stateMachine;
    }

    public virtual void Update() {}
    public virtual void OnEnter() {}
    public virtual void OnExit() {}
  }
  // Specific turn state classes, for example:
  [Serializable]
  public class IdleTurnState : TurnState {
    public override void Update() {
      if (Keyboard.current.spaceKey.wasPressedThisFrame)
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
      foreach (var company in companies) company.Produce();

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
      if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;

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
        if (company.CompanyName != "Player")
          company.CreateOffer(marketManager);

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
      if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;

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

    public DeconstructOfferTurnState(TurnManager turnManager,
                                     MarketManager marketManager,
                                     UIManager uiManager,
                                     PlayerManager playerManager) {
      this.turnManager = turnManager;
      this.marketManager = marketManager;
      this.uiManager = uiManager;
      this.playerManager = playerManager;
    }

    public override void Update() {
      if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;

      turnManager.AdvanceTurn();
      marketManager.ClearOffers();
      uiManager.UpdateUI(playerManager.PlayerCompany,
                         turnManager.CurrentTurn);
      machine.SetTurnState(machine.IdleTurnState());
    }
  }
}