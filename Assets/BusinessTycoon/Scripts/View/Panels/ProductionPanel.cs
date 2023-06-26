#region Info

// -----------------------------------------------------------------------
// ProductionPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using BT.Managers;
using TMPro;
using UnityEngine;

#endregion

namespace BT.Panels {
    public class ProductionPanel : BasePanel {
        #region Serialized Fields

        [SerializeField] private GameObject factoryPanel;
        [SerializeField] private TMP_Text totalCostText;

        #endregion

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
        }

        public override void UpdatePanel() {
            TotalCost = company.CalculateTotalCost();
            totalCostText.text = "Total Cost: " + TotalCost + "€";
        }
    }
}