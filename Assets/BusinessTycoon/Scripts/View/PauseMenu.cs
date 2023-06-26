using BT.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BT {
    public class PauseMenu : MonoBehaviour {
        #region Serialized Fields

        // Reference to the pause menu panel
        [SerializeField] private GameObject resolutionPanel;
        [SerializeField] private GameObject pauseMenuPanel;

        #endregion

        private InputManager inputManager;

        #region Event Functions

        private void Start() {
            inputManager = ManagerProvider.Current.InputManager;
            inputManager.OnCancelEvent += ToggleGame;
        }

        #endregion

        public void ToggleGame() {
            if (pauseMenuPanel.activeSelf)
                ResumeGame();
            else
                PauseGame();
        }

        public void OpenSettings() {
            resolutionPanel.SetActive(true);
        }

        public void CloseSettings() {
            resolutionPanel.SetActive(false);
        }

        public void LoadMenu() {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame() {
            Application.Quit();
        }

        private void ResumeGame() {
            pauseMenuPanel.SetActive(false);
            if (resolutionPanel.activeSelf) resolutionPanel.SetActive(false);
            Time.timeScale = 1;
        }

        private void PauseGame() {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}