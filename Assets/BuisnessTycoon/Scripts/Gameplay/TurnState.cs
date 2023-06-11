#region Info
// -----------------------------------------------------------------------
// ITurnState.cs
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
    public virtual void Update() { }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
  }
  // Specific turn state classes, for example:
  [Serializable]
  public class IdleTurnState : TurnState {
    #region ITurnState Members
    public override void Update() {
      if (Keyboard.current.spaceKey.wasPressedThisFrame)
        machine.SetTurnState(machine.ProductionTurnState());
    }
    #endregion
  }
  [Serializable]
  public class ProductionTurnState : TurnState {
    private List<Company> companies;
    private UIManager uiManager;
    private PlayerManager playerManager;
    private TurnManager turnManager;
    public ProductionTurnState(List<Company> companies, UIManager uiManager,
                               PlayerManager playerManager,
                               TurnManager turnManager) {
      this.companies = companies;
      this.uiManager = uiManager;
      this.playerManager = playerManager;
      this.turnManager = turnManager;
    }
    #region ITurnState Members
    public override void Update() {
      foreach (var company in companies) company.Produce();

      uiManager.UpdateUI(playerManager.PlayerCompany,
          turnManager.CurrentTurn);
      machine.SetTurnState(machine.CreateOfferTurnState());
    }
    #endregion
  }
  [Serializable]
  public class CreateOfferTurnState : TurnState {
    private UIManager uiManager;
    private PlayerManager playerManager;
    private TurnManager turnManager;
    public CreateOfferTurnState(UIManager uiManager,
                                PlayerManager playerManager,
                                TurnManager turnManager) {
      this.uiManager = uiManager;
      this.playerManager = playerManager;
      this.turnManager = turnManager;
    }
    #region ITurnState Members
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
    #endregion
  }
  [Serializable]
  public class AiCreateOfferTurnState : TurnState {
    private List<Company> companies;
    private MarketManager marketManager;
    private UIManager uiManager;
    private PlayerManager playerManager;
    private TurnManager turnManager;
    #region ITurnState Members
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
    #endregion
  }
  [Serializable]
  public class ChooseOfferTurnState : TurnState {
    #region ITurnState Members
    public override void Update() {
      machine.SetTurnState(machine.ShowOfferTurnState());
    }
    #endregion
  }
  [Serializable]
  public class ShowOfferTurnState : TurnState {
    #region ITurnState Members
    public override void Update() {
      if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;

      machine.SetTurnState(machine.AiChooseOfferTurnState());
    }
    #endregion
  }
  [Serializable]
  public class AiChooseOfferTurnState : TurnState {
    private MarketManager marketManager;
    private UIManager uiManager;
    private PlayerManager playerManager;
    private TurnManager turnManager;
    public AiChooseOfferTurnState(MarketManager marketManager,
                                  UIManager uiManager,
                                  PlayerManager playerManager,
                                  TurnManager turnManager) {
      this.marketManager = marketManager;
      this.uiManager = uiManager;
      this.playerManager = playerManager;
      this.turnManager = turnManager;
    }
    #region ITurnState Members
    public override void Update() {
      marketManager.UpdateMarket();
      uiManager.UpdateUI(playerManager.PlayerCompany,
          turnManager.CurrentTurn);

      machine.SetTurnState(machine.OfferResultTurnState());
    }
    #endregion
  }
  [Serializable]
  public class OfferResultTurnState : TurnState {
    #region ITurnState Members
    public override void Update() {
      machine.SetTurnState(machine.DeconstructOfferTurnState());
    }
    #endregion
  }
  [Serializable]
  public class DeconstructOfferTurnState : TurnState {
    private TurnManager turnManager;
    private MarketManager marketManager;
    private UIManager uiManager;
    private PlayerManager playerManager;
    public DeconstructOfferTurnState(TurnManager turnManager,
                                     MarketManager marketManager,
                                     UIManager uiManager,
                                     PlayerManager playerManager) {
      this.turnManager = turnManager;
      this.marketManager = marketManager;
      this.uiManager = uiManager;
      this.playerManager = playerManager;
    }
    #region ITurnState Members
    public override void Update() {
      if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;

      turnManager.AdvanceTurn();
      marketManager.ClearOffers();
      uiManager.UpdateUI(playerManager.PlayerCompany,
          turnManager.CurrentTurn);
      machine.SetTurnState(machine.IdleTurnState());
    }
    #endregion
  }
}
