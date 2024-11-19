using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool needRecalculatePigs { get; set; }
    public static bool isTimeOut { get; set; }
    public static bool isLevelCompleted { get; set; }
    public static bool isLevelFailed { get; set; }
    public static int levelIndex { get; set; }
    public static int triesCount { get; set; }
}
