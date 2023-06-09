#region Info
// -----------------------------------------------------------------------
// ITurnState.cs
// 
// Felix Jung 09.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using System.Collections.Generic;
using BT.Scripts.production;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
#endregion

namespace BT.Scripts.Gameplay {
  public interface ITurnState {
    void Update(TurnStateContext context, List<Company> companies,
                MarketManager marketManager, PlayerManager playerManager,
                UIManager uiManager, TurnManager turnManager);
  }
  // Specific turn state classes, for example:

  [Serializable]
  public class IdleTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      if (Keyboard.current.spaceKey.wasPressedThisFrame) {
        context.SetTurnState(new ProductionTurnState());
      }
    }
    #endregion
  }
  [Serializable]
  public class ProductionTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {


      // if (!Keyboard.current.spaceKey.wasPressedThisFrame)
      //   return;

      foreach (var company in companies) { company.Produce(); }

      uiManager.UpdateUI(playerManager.PlayerCompany,
                         turnManager.CurrentTurn);
      context.SetTurnState(new CreateOfferTurnState());

    }
    #endregion
  }
  [Serializable]
  public class CreateOfferTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      // Make player create offer

      /*if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;*/
      playerManager.PlayerCompany.CreateOffer(marketManager);
      uiManager.UpdateUI(playerManager.PlayerCompany, turnManager.CurrentTurn);
      context.SetTurnState(new AICreateOfferTurnState());

    }
    #endregion
  }
  [Serializable]
  public class AICreateOfferTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      /*if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;*/

      foreach (var company in companies) {
        if (company.CompanyName != "Player") {
          company.CreateOffer(marketManager);
        }
      }

      uiManager.UpdateUI(playerManager.PlayerCompany,
                         turnManager.CurrentTurn);

      context.SetTurnState(new ChooseOfferTurnState());

    }
    #endregion
  }
  [Serializable]
  public class ChooseOfferTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      // if (!Keyboard.current.spaceKey.wasPressedThisFrame)
      //   return;
      context.SetTurnState(new AIChooseOfferTurnState());
    }
    #endregion
  }
  [Serializable]
  public class AIChooseOfferTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      //TODO 6/9/2023 felix: make AI choose offer

      // if (!Keyboard.current.spaceKey.wasPressedThisFrame)
      //   return;
      marketManager.UpdateMarket();
      uiManager.UpdateUI(playerManager.PlayerCompany,
                         turnManager.CurrentTurn);
      context.SetTurnState(new OfferResultTurnState());
    }
    #endregion
  }
  [Serializable]
  public class OfferResultTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      // if (!Keyboard.current.spaceKey.wasPressedThisFrame)
      //   return;
      context.SetTurnState(new DeconstructOfferTurnState());
    }
    #endregion
  }
  [Serializable]
  public class DeconstructOfferTurnState : ITurnState {
    #region ITurnState Members
    public void Update(TurnStateContext context, List<Company> companies,
                       MarketManager marketManager, PlayerManager playerManager,
                       UIManager uiManager, TurnManager turnManager) {
      if (!Keyboard.current.spaceKey.wasPressedThisFrame)
        return;
      turnManager.AdvanceTurn();
      marketManager.ClearOffers();
      uiManager.UpdateUI(playerManager.PlayerCompany,
                         turnManager.CurrentTurn);
      context.SetTurnState(new IdleTurnState());
    }
    #endregion
  }

}
