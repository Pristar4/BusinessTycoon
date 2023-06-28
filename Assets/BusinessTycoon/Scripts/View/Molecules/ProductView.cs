using BT.Atom;
using BT.Managers.BT.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace BT.Molecules {
    public class ProductView : MonoBehaviour {
        [SerializeField] private AtomButton sellButton;
        [SerializeField] private Text productNameText;
        [SerializeField] private Text productQuantityText;
        [SerializeField] private UIManager uiManager;

        public void SetProduct(ProductData product) {
            productNameText.text = product.Type.name;
            productQuantityText.text = product.Quantity.ToString();
            sellButton.Button.onClick.AddListener(() => {
                uiManager.SellProduct(product);
            });
        }

        private void OnDestroy() {
            sellButton.Button.onClick.RemoveAllListeners();
        }
    }
}

