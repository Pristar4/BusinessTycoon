#region Info

// -----------------------------------------------------------------------
// ProductionPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using BT.Managers;
using BT.Molecules;
using TMPro;
using UnityEngine;

#endregion

namespace BT.Panels {
    public class ProductionPanel : BasePanel {
        #region Serialized Fields

        [SerializeField] private FactoryDetailsPanel factoryDetailsPanel;
        [SerializeField] private GameObject factoryPanel;
        [SerializeField] private TMP_Text totalCostText;
        [SerializeField] private GameObject factoryViewPrefab;
        [SerializeField] private Transform factoryViewContainer;

        #endregion

        private readonly List<FactoryView> factoryViews = new List<FactoryView>();
        private FactoryData selectedFactory;
        private Company company;
        public float TotalCost { set; get; }

        public override void Initialize(PanelData data = null) {
            company = ManagerProvider.Current.PlayerManager.GetPlayerCompany();
        }

        public override void Open() {
            gameObject.SetActive(true);
            factoryPanel.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
            factoryPanel.SetActive(false);
            factoryDetailsPanel.Close();
        }

        public override void UpdatePanel() {
            // Clear previous views
            foreach (var view in factoryViews) {
                Destroy(view.gameObject);
            }

            factoryViews.Clear();

            // Create views for each factory
            foreach (var factory in company.FactoryInventory) {
                var viewObj = Instantiate(factoryViewPrefab, factoryViewContainer);
                var view = viewObj.GetComponent<FactoryView>();
                view.SetFactory(factory, this);
                factoryViews.Add(view);
            }

            TotalCost = company.CalculateTotalCost();
            totalCostText.text = "Total Cost: " + TotalCost + "€";
        }

        public void ViewFactoryDetails(FactoryData factory) {
            Debug.Log("ViewFactoryDetails");
            // Activate the detailed factory panel and populate it with factory data
            factoryDetailsPanel.SetFactory(factory);
            factoryDetailsPanel.Open();
        }
    }
}