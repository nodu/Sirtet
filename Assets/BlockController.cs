using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float upwardForce = 100;
    public float downwardForce = 1000;
    public float lateralForce = 300;
    public float torqueForce = 10;
    public int[] masses = {10, 50 ,300};
    public bool randomMassEnabled = false;
    public Color[] colors = {Color.white, Color.gray, Color.black};
    public bool disconnected = false;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private bool downwardUsed = false;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();

        index = randomMassEnabled ? Random.Range(0, 3) : 1;
        myRigidbody.mass = masses[index];
        mySpriteRenderer.color = colors[index];
    }

    // Update is called once per frame
    void Update()
    {
      /* TODO Keypresses do not continue after the block gameObject is disconnected (collision) from the controller. User has to depress input then press again. */
        if (!disconnected) {
            if (Input.GetKeyDown(KeyCode.W)) {
                myRigidbody.AddForce(Vector2.up * upwardForce * masses[index]);
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                myRigidbody.AddForce(Vector2.left * lateralForce * masses[index]);
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                myRigidbody.AddForce(Vector2.right * lateralForce * masses[index]);
            }

            if (!downwardUsed && Input.GetKeyDown(KeyCode.S)) {
                myRigidbody.AddForce(Vector2.down * downwardForce * masses[index]);
                downwardUsed = true;
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                myRigidbody.AddTorque(torqueForce * masses[index]);
            }

            if (Input.GetKeyDown(KeyCode.Q)) {
                myRigidbody.AddTorque(-1 * torqueForce * masses[index]);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log(collision.gameObject.name);

      switch(collision.gameObject.name)
      {
        case "Floor":
            if (!disconnected ) {
                disconnected = true;
            }
            break;
        case "Block(Clone)":
            if (!disconnected ) {
                disconnected = true;
            }
          break;
        case "RightWall":
            Debug.Log("Ouch, right wall");
            break;
        case "LeftWall":
            Debug.Log("Ouch, left wall");
            break;
        default:
            break;
      }
    }
}
