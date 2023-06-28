using System;
using UnityEngine;
using UnityEngine.UI;

namespace BT.Atom {
    public class AtomButton : MonoBehaviour {
        #region Properties
        public Button Button { get; private set; }

        #endregion

        #region Event Functions

        private void Awake() {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(HandleButtonClick);
        }

        #endregion

        public event Action OnButtonClicked;

        private void HandleButtonClick() {
            OnButtonClicked?.Invoke();
        }
    }
}