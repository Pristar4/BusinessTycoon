using UnityEngine;
using UnityEngine.SceneManagement;

namespace BT.Scripts.View {
  public class MainMenu : MonoBehaviour {
    [SerializeField]
    private GameObject resolutionPanel;
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
