using BT.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BT.Molecules {
    public class FactoryView : MonoBehaviour {
        [SerializeField] private Button viewDetailsButton;
        [SerializeField] private TMP_Text factoryNameText;
        [SerializeField] private TMP_Text factoryOutputText;

        public void SetFactory(FactoryData factory,ProductionPanel productionPanel) {
            factoryNameText.text = factory.Factory.FactoryName;
            factoryOutputText.text = factory.CurrentOutput.ToString();
            viewDetailsButton.onClick.AddListener(() => {
                productionPanel.ViewFactoryDetails(factory);
            });
        }

        private void OnDestroy() {
            viewDetailsButton.onClick.RemoveAllListeners();
        }
    }
}