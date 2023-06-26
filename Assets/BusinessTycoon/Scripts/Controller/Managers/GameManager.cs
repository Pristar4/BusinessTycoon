#region Info
// -----------------------------------------------------------------------
// GameManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.BusinessTycoon.Scripts.Controller.Gameplay;
using BT.BusinessTycoon.Scripts.Controller.Managers.BT.Scripts.Gameplay;
using BT.BusinessTycoon.Scripts.Models;
using UnityEngine;
#endregion

namespace BT.BusinessTycoon.Scripts.Controller.Managers {
  public class GameManager : MonoBehaviour {
    private const int NpcCount = 4;
    #region Serialized Fields
    [Header("Gameplay")]
    [SerializeField] private List<Company> companies;
    [SerializeField] private Company companyPrefab;
    [SerializeField] private CompanyPreset companyPreset;
    [SerializeField] private GameState currentState;
    [Header("Managers")]
    [SerializeField] private AIManager aiManager;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private MarketManager marketManager;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private UIManager uiManager;
    #endregion
    private TurnStateMachine turnStateMachine;
    #region Constructors
    public GameManager(
        AIManager aiManager,
        PlayerManager playerManager,
        MarketManager marketManager,
        TurnManager turnManager,
        UIManager uiManager
    ) {
      this.aiManager = aiManager;
      this.playerManager = playerManager;
      this.marketManager = marketManager;
      this.turnManager = turnManager;
      this.uiManager = uiManager;
    }
    #endregion
    #region Event Functions
    private void Start() {
      Initialize();
    }
    private void Update() {
      if (currentState != GameState.Playing) return;

      turnStateMachine.Update(companies, marketManager, playerManager,
          uiManager, turnManager);
      turnStateMachine.GetTurnState();

    }
    #endregion
    private Company CreateCompany() {
      var newCompany = Instantiate(companyPrefab);
      newCompany.Finance.Balance = companyPreset.startingBalance;

      // Deep copy of the ProductData list
      newCompany.ProductInventory
          = new List<ProductData>(companyPreset.startingProductInventory);

      newCompany.FactoryInventory = new List<FactoryData>();

      foreach (var factoryData in companyPreset.startingFactoryInventory) {
        // Get the corresponding FactorySo from the FactoryData
        var factorySo = factoryData.Factory;

        // Create a new FactoryData instance and set its properties
        var newFactoryData = new FactoryData(factorySo,
            ManagerProvider.Current.TurnManager.CurrentTurn);
        newFactoryData.CurrentOutput
            = factoryData.CurrentOutput; // Set the current output if necessary
        newCompany.FactoryInventory.Add(newFactoryData);
      }

      newCompany.CompanyName = companyPreset.companyName;
      return newCompany;
    }
    private List<Company> CreateNpcCompanies(int count) {
      var npcCompanies = new List<Company>();

      for (var i = 0; i < count; i++) {
        var npc = aiManager.CreateCompany(companyPrefab, i);
        npcCompanies.Add(npc);
      }

      return npcCompanies;
    }
    private void Initialize() {
      marketManager.Initialize();
      var startup = CreateCompany();
      companies.Add(startup);
      var npcCompanies = CreateNpcCompanies(NpcCount);
      companies.AddRange(npcCompanies);
      // Initialize the TurnStateMachine
      turnStateMachine = new TurnStateMachine(companies,
          marketManager, uiManager,
          playerManager, turnManager);

      // Initialize all other managers
      aiManager.Initialize();
      playerManager.Initialize(startup);
      turnManager.Initialize();

      // Set the current state.
      currentState = GameState.Playing;

      uiManager.Initialize(startup);
    }
  }
}
