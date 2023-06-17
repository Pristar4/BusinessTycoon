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
    [SerializeField] private List<Company> companies;
    [SerializeField] private Company companyPrefab;
    [SerializeField] private CompanyPreset companyPreset;
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
    private TurnStateMachine turnStateMachine;
    #region Event Functions
    private void Start() {
      // TODO: refactor so the order of initialization is not important

      // Initialize the market
      marketManager.Initialize();

      // Initialize the list of Companies
      companies = new List<Company>();
      var startup = CreateCompany();
      companies.Add(startup);

      // Initialize
      var npcCompanies = CreateNpcCompanies(NpcCount);
      companies.AddRange(npcCompanies);

      // Initialize all other managers
      aiManager.Initialize(npcCompanies);
      playerManager.Initialize(startup);
      turnManager.Initialize();

      // Set the current state.
      currentState = GameState.Playing;
      // Initialize the TurnStateMachine before the UIManager.
      turnStateMachine = new TurnStateMachine(companies,
          marketManager, uiManager,
          playerManager, turnManager);

      uiManager.Initialize(startup);
    }
    private void Update() {
      if (currentState != GameState.Playing) { return; }

      turnStateMachine.Update(companies, marketManager, playerManager,
          uiManager, turnManager);
      turnStateMachine.GetTurnState();
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
      var newCompany = Instantiate(companyPrefab);
      newCompany.Finance.Balance = companyPreset.startingBalance;
      // Deep copy of the ProductData list
      newCompany.ProductInventory = new List<ProductData>();
      foreach (var product in companyPreset.startingProductInventory) {
        var newProductData
            = new ProductData(product.Type, product.Amount);
        newCompany.ProductInventory.Add(newProductData);
      }
      newCompany.FactoryInventory = new List<FactoryData>();
      foreach (var factory in companyPreset.startingFactoryInventory) {
        var newFactoryData
            = new FactoryData(factory.Factory,
                ManagerProvider.Current.TurnManager.CurrentTurn +
                factory.EndSetupTurn);
        newCompany.FactoryInventory.Add(newFactoryData);
      }
      newCompany.CompanyName = companyPreset.companyName;
      return newCompany;
    }
  }
  public enum GameState {
    Playing,
    Paused,
    Ended,
  }
}
