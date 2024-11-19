using TMPro;
using UnityEngine;

public class PigsCountScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI pigsCountTMP;

    void Start() {
        pigsCountTMP.GetComponent<TextMeshProUGUI>();
        GameState.needRecalculatePigs = true;
    }

    void Update() {
        if(GameState.needRecalculatePigs) {
            int pigsCount = GameObject.FindGameObjectsWithTag("Pig").Length;
            pigsCountTMP.text = pigsCount.ToString();

            GameState.needRecalculatePigs = false;
            GameState.isLevelCompleted = false;

            if(pigsCount == 0 ) {
                GameState.isLevelCompleted = true;
                ModalScript.ShowModal("Victory", "All enemies are destroyed", "Continue");
            }
        }
    }
}
