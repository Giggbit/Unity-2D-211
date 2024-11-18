using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private ForceScript forceScript;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject.Find("ForceCanvasIndicator").GetComponent<ForceScript>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            float forceFactor = 1000.0f;
            if(forceScript != null) { 
                forceFactor *= forceScript.forceFactor + 0.5f;
            }
            else {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);
        }
    }
}
