using UnityEngine;

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    private float gameTime = 20.0f;
    private TMPro.TextMeshProUGUI timeTMP;

    void Start() {
        timeTMP = GetComponent<TMPro.TextMeshProUGUI>();
        GameState.isTimeOut = false;
    }

    void Update() {
        gameTime -= Time.deltaTime;
        timeTMP.text = gameTime.ToString("00.0");
        if(gameTime <= 0) {
            gameTime = 20.0f;
            GameState.isTimeOut = true;
            ModalScript.ShowModal("Time is out", "Press restart", "Restart");
        }
    }
}
