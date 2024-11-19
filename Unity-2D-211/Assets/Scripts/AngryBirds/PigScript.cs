using UnityEngine;

public class PigScript : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("PigDestroy")) {
            GameObject.Destroy(this.gameObject);
            GameState.needRecalculatePigs = true;
        }
    }
}
