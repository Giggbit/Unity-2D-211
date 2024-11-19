using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private ForceScript forceScript;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float shotTimeout = 10.0f;
    private float shotTime;
    private bool isShot;

    void Start() {
        shotTime = 0.0f;
        isShot = false;
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject.Find("ForceCanvasIndicator").GetComponent<ForceScript>();
    }

    void Update() {
        if (Time.timeScale == 0.0f) return;

        if(Input.GetKeyDown(KeyCode.Space) && !isShot) {
            float forceFactor = 1000.0f;
            if(forceScript != null) { 
                forceFactor *= forceScript.forceFactor + 0.5f;
            }
            else {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);
            isShot = true;
            shotTime = shotTimeout;
        }
        if(isShot) { 
            shotTime -= Time.deltaTime;
            if(shotTime <= 0.0f) { 
                isShot = false;
                // Start Position
                this.transform.position = startPosition;
                this.transform.rotation = startRotation;
                // Stop
                rb2d.linearVelocity = Vector2.zero;
                rb2d.angularVelocity = 0.0f;
            }
        }
    }
}
