using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI playButtonNameTMP;

    private static ModalScript instance;
    private string titleDefault;
    private string messageDefault;
    private string playButtonNameDefault;

    void Start() {
        instance = this;
        titleDefault = titleTMP.text; 
        messageDefault = messageTMP.text;
        playButtonNameDefault = playButtonNameTMP.text;
        GameState.isLevelFailed = false;
        
        if (content.activeInHierarchy) { 
            Time.timeScale = 0.0f;
        } else Time.timeScale = 1.0f;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (content.activeInHierarchy) { 
                content.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else {
                _Show();
            }
        }
    }

    public void OnResumeButtonClick() {
        Time.timeScale = 1.0f;
        content.SetActive(false);

        if (GameState.isTimeOut) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        if (GameState.isLevelFailed) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        else if (GameState.isLevelCompleted) {
            GameState.levelIndex += 1;
            if (GameState.levelIndex < SceneManager.sceneCountInBuildSettings) {
                SceneManager.LoadScene(GameState.levelIndex);
            }
            else {
                GameState.levelIndex = 0;
                SceneManager.LoadScene(GameState.levelIndex);
            }
        }
    }

    public void OnExitToMenuButtonClick() {
        SceneManager.LoadScene(0);
    }

    private void _Show(string title = null, string message = null, string playName = null) {
        Time.timeScale = 0.0f;
        this.content.SetActive(true);

        if (title != null) titleTMP.text = title;
        else titleTMP.text = titleDefault;

        if(message != null) messageTMP.text = message;
        else messageTMP.text = messageDefault;

        if (playName != null) playButtonNameTMP.text = playName;
        else playButtonNameTMP.text = playButtonNameDefault;
    }

    public static void ShowModal(string title = null, string message = null, string playName = null) {
        instance._Show(title, message, playName);
    } 

}
