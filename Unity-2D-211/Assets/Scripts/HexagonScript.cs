using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    private Rigidbody2D rb2d;   // ссылка на объект компонента
    public float speed;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() { 
        if(Input.GetKeyDown(KeyCode.Space)) {
            rb2d.AddForce(Vector2.up * 300);
        }

        if(Input.GetKeyDown(KeyCode.D)) {
            rb2d.AddForce(Vector2.right * 100);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            rb2d.AddForce(Vector2.left * 100);
        }
        
        if(Input.GetKeyDown(KeyCode.S)) {
            rb2d.AddTorque(speed, ForceMode2D.Force);
        }

        if( Input.GetKeyDown(KeyCode.Escape)) { 
            rb2d.angularVelocity = 0;
            rb2d.linearVelocity = new Vector2(0, 0);
        }
    }

}

/*
 Пример кодироваки
 */
