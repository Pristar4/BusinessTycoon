#region Info
// -----------------------------------------------------------------------
// GameManager.cs
// 
// Felix Jung 22.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.Gameplay;
using BT.Scripts.Managers.BT.Scripts.Gameplay;
using BT.Scripts.Models;
using UnityEngine;
#if ODIN_INSPECTOR
#endif
#endregion
namespace BT.Scripts.Managers {
  public class GameManager : MonoBehaviour {
    private const int NpcCount = 4;
    #region Serialized Fields
    [SerializeField] private List<Company> companies;
    [SerializeField] private Company companyPrefab;
    [SerializeField] private CompanyPreset companyPreset;
    #if ODIN_INSPECTOR 
    [FoldoutGroup("Managers")]
    #endif
    [SerializeField] private AIManager aiManager;
    #if ODIN_INSPECTOR 
    [FoldoutGroup("Managers")]
    #endif
    [SerializeField] private PlayerManager playerManager;
    #if ODIN_INSPECTOR 
    [FoldoutGroup("Managers")]
    #endif
    [SerializeField] private MarketManager marketManager;
    #if ODIN_INSPECTOR 
    [FoldoutGroup("Managers")]
    #endif
    [SerializeField] private TurnManager turnManager;
    #if ODIN_INSPECTOR 
    [FoldoutGroup("Managers")]
    #endif
    [SerializeField] private UIManager uiManager;
    #if ODIN_INSPECTOR
    [ReadOnly]
    #endif
    [SerializeField] 
  
    private GameState currentState;
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
                ManagerProvider.Current.TurnManager.CurrentTurn);
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
