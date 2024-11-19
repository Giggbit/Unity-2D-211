using UnityEngine;

public class TimeScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI timeTMP;
    private float gameTime;

    void Start() {
        timeTMP = GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0.0f;
        GameState.isTimeOut = false;
    }

    void Update() {
        gameTime += Time.deltaTime;
        timeTMP.text = gameTime.ToString("00:00:00");
        if(gameTime >= 20.0f) {
            gameTime = 0.0f;
            GameState.isTimeOut = true;
            ModalScript.ShowModal("Time is out", "Press restart", "Restart");
        }
    }
}
