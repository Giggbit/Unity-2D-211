using UnityEngine;

public class TimeScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI timeTMP;
    private float gameTime;

    void Start() {
        timeTMP = GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0.0f;
    }

    void Update() {
        gameTime += Time.deltaTime;
        timeTMP.text = gameTime.ToString("00:00:00");
    }
}
