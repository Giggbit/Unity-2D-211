using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void RestartScene() {
        SceneManager.LoadScene(GameState.levelIndex);
    }
}
