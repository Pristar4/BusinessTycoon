#region Info
// -----------------------------------------------------------------------
// GameManager.cs
// 
// Felix Jung 11.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.AI;
using BT.Scripts.Gameplay.BT.Scripts.Gameplay;
using BT.Scripts.production;
using Sirenix.OdinInspector;
using UnityEngine;
#endregion

namespace BT.Scripts.Gameplay {
  public class GameManager : MonoBehaviour {
    private const int NpcCount = 4;
    #region Serialized Fields
    [SerializeField] public List<Company> companies;
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
    #endregion

    private TurnState currentTurnState = new IdleTurnState();
    private TurnStateMachine turnStateMachine;
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
      turnStateMachine = new TurnStateMachine(currentTurnState, companies,
                                              marketManager, uiManager,
                                              playerManager, turnManager);

    }

    private void Update() {
      if (currentState != GameState.Playing) { return; }

      turnStateMachine.Update(companies, marketManager, playerManager,
                              uiManager, turnManager);
      currentTurnState = turnStateMachine.GetTurnState();
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
}