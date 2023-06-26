using UnityEngine;
using UnityEngine.SceneManagement;

namespace BT {
    public class MainMenu : MonoBehaviour {
        #region Serialized Fields

        [SerializeField] private GameObject resolutionPanel;

        #endregion

        public void PlayerGame() {
            SceneManager.LoadScene("Game");
        }

        public void OpenSettings() {
            resolutionPanel.SetActive(true);
        }

        public void CloseSettings() {
            resolutionPanel.SetActive(false);
        }

        public void QuitGame() {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}