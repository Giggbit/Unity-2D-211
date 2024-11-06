using UnityEngine;

public class ArrowScriptHw : MonoBehaviour
{
    [SerializeField]
    private Transform rotationAnchor;

    void Start() {
        
    }

    void Update() {
        float dy = Input.GetAxis("Vertical");
        float angle = this.transform.eulerAngles.z;

        if(angle > 180) {
            angle -= 360;
        }
        if(-15 < angle + dy && angle + dy < 120) {
            this.transform.RotateAround(rotationAnchor.position, Vector3.forward, dy);
        }
    }
}
