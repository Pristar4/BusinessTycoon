#region Info
// -----------------------------------------------------------------------
// GameManager.cs
// 
// Felix Jung 07.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.production;
using UnityEngine;
using UnityEngine.InputSystem;
#endregion

namespace BT.Scripts {
  public class GameManager : MonoBehaviour {
    #region Serialized Fields
    [SerializeField] private List<Company> companies;
    [SerializeField] private Company companyPrefab;
    [SerializeField] private AIManager aiManager;
    [SerializeField] private PlayerManager playerManager;
    #endregion
    private GameState currentState;

    [SerializeField] private MarketManager marketManager;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private UIManager uiManager;
    #region Event Functions
    private void Start() {
      // Initialize the market
      marketManager.Initialize();

      // Initialize the list of Companies
      companies = new List<Company>();
      var startup = CreateCompany();
      companies.Add(startup);
      startup.Finance.Balance = 1000;
      startup.Finance.Income = 100;
      startup.Finance.Expense = 50;
      
      var npcCompanies = CreateNpcCompanies(4);
      companies.AddRange(npcCompanies);

      // Initialize all other managers
      uiManager.Initialize(startup);
      aiManager.Initialize(npcCompanies);
      playerManager.Initialize(startup);
      turnManager.Initialize();

      // Set the current state.
      currentState = GameState.Playing;
    }

    private void Update() {
      if (currentState == GameState.Playing) {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
          turnManager.AdvanceTurn();
          Debug.Log("Turn: " + turnManager.CurrentTurn);
          UpdateGame();
        }
      }
    }
    #endregion

    private void UpdateGame() {
      foreach (var company in companies) {
        company.Produce();
      }

      foreach (var company in companies) {
        // company.CreateOffer(marketManager);
      }
      

      marketManager.UpdateMarket();
      uiManager.UpdateUI(playerManager.PlayerCompany, turnManager.CurrentTurn);
    }
    

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
}
