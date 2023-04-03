using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float lateralForce;
    public float torqueForce;
    public bool disconnected = false;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disconnected && myCollider.IsTouchingLayers()) {
            disconnected = true;
        }

        if (!disconnected) {
            if (Input.GetKeyDown(KeyCode.W)) {
                myRigidbody.AddForce(Vector2.up * 100);
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                myRigidbody.AddForce(Vector2.left * lateralForce);
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                myRigidbody.AddForce(Vector2.right * lateralForce);
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                myRigidbody.AddTorque(torqueForce);
            }

            if (Input.GetKeyDown(KeyCode.Q)) {
                myRigidbody.AddTorque(-1 * torqueForce);
            }
        }
    }
}
