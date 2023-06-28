using BT.Managers;
using BT.Managers.BT.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BT.Atom {
    public class EndTurnButton : MonoBehaviour
    {
        [SerializeField] private AtomButton atomButton;
        private UIManager uiManager;

        private void Awake()
        {
            atomButton.OnButtonClicked += HandleButtonClicked;
            uiManager = ManagerProvider.Current.UIManager;
        }

        private void OnDestroy()
        {
            atomButton.OnButtonClicked -= HandleButtonClicked;
        }

        private void HandleButtonClicked()
        {
            
            uiManager.EndTurnPressed();
        }
    }

}