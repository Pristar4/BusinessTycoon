#region Info
// -----------------------------------------------------------------------
// GameManager.cs
// 
// Felix Jung 09.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.AI;
using BT.Scripts.production;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
#endregion

namespace BT.Scripts.Gameplay {
  public class GameManager : MonoBehaviour {
    private const int NpcCount = 4;
    #region Serialized Fields
    [SerializeField] private List<Company> companies;
    [SerializeField] private Company companyPrefab;
    [FoldoutGroup("Managers")]
    [SerializeField] private AIManager aiManager;
    [FoldoutGroup("Managers")]
    [SerializeField] private PlayerManager playerManager;
    [FoldoutGroup("Managers")]
    [SerializeField] private MarketManager marketManager;
    [FoldoutGroup("Managers")]
    [SerializeField] private TurnManager turnManager;
    [FoldoutGroup("Managers")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] [ReadOnly]
    private GameState currentState;
    [FormerlySerializedAs("currentTurnState")]
    // private TurnState OLD_currentTurnState = TurnState.Idle;
    [SerializeField] [ReadOnly]
    private string serializedTurnState;
    #endregion

    private ITurnState currentTurnState = new IdleTurnState();
    private TurnStateContext turnStateContext;
    #region Event Functions
    private void Start() {
      // Initialize the market
      marketManager.Initialize();

      // Initialize the list of Companies
      companies = new List<Company>();
      var startup = CreateCompany();
      companies.Add(startup);

      var npcCompanies = CreateNpcCompanies(NpcCount);
      companies.AddRange(npcCompanies);

      // Initialize all other managers
      uiManager.Initialize(startup);
      aiManager.Initialize(npcCompanies);
      playerManager.Initialize(startup);
      turnManager.Initialize();

      // Set the current state.
      currentState = GameState.Playing;
      turnStateContext = new TurnStateContext(currentTurnState);
      serializedTurnState = currentTurnState.ToString();
    }

    private void Update() {
      if (currentState != GameState.Playing) { return; }

      turnStateContext.Update(companies, marketManager, playerManager,
                              uiManager, turnManager);
      currentTurnState = turnStateContext.GetTurnState();
      serializedTurnState
          = currentTurnState.GetType().ToString().Split('.')[^1];
      /* deprecated
       switch (OLD_currentTurnState) {
      case TurnState.Idle:
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
          OLD_currentTurnState = TurnState.Production;
        }

        break;
      case TurnState.Production:
        foreach (var company in companies) { company.Produce(); }

        uiManager.UpdateUI(playerManager.PlayerCompany,
                           turnManager.CurrentTurn);
        Debug.Log("Production");
        OLD_currentTurnState = TurnState.CreateOffer;



        break;
      case TurnState.CreateOffer:
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
          OLD_currentTurnState = TurnState.AICreateOffer;
        }

        uiManager.UpdateUI(playerManager.PlayerCompany,
                           turnManager.CurrentTurn);
        // The player creates an offer
        break;
      case TurnState.AICreateOffer:
        // Remove player from the list of companies
        foreach (var company in companies) {
          company.CreateOffer(marketManager);
        }

        uiManager.UpdateUI(playerManager.PlayerCompany,
                           turnManager.CurrentTurn);
        OLD_currentTurnState = TurnState.ChooseOffer;
        break;
      case TurnState.ChooseOffer:
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
          OLD_currentTurnState = TurnState.AIChooseOffer;
        }

        break;
      case TurnState.AIChooseOffer:
        // The AI chooses an offer
        //remove player from the list of companies

        marketManager.UpdateMarket();
        uiManager.UpdateUI(playerManager.PlayerCompany,
                           turnManager.CurrentTurn);
        OLD_currentTurnState = TurnState.OfferResult;

        break;
      case TurnState.OfferResult:
        uiManager.UpdateUI(playerManager.PlayerCompany,
                           turnManager.CurrentTurn);
        OLD_currentTurnState = TurnState.DeconstructOffer;
        break;
      case TurnState.DeconstructOffer:
        marketManager.ClearOffers();
        uiManager.UpdateUI(playerManager.PlayerCompany,
                           turnManager.CurrentTurn);
        turnManager.AdvanceTurn();
        OLD_currentTurnState = TurnState.Idle;
        break;
      default:
        throw new ArgumentOutOfRangeException();
      }*/
    }
    #endregion

    private List<Company> CreateNpcCompanies(int count) {
      var npcCompanies = new List<Company>();

      for (int i = 0; i < count; i++) {
        var npc = aiManager.CreateCompany(companyPrefab, i);
        npcCompanies.Add(npc);
      }

      return npcCompanies;
    }

    private Company CreateCompany() {
      return playerManager.CreateCompany(companyPrefab);
    }
  }

  public enum GameState {
    Playing,
    Paused,
    Ended,
  }
  /* deprecated
  public enum TurnState {
    Idle,
    Production,
    CreateOffer,
    AICreateOffer,
    ChooseOffer,
    AIChooseOffer,
    OfferResult,
    DeconstructOffer,

  }*/
}
