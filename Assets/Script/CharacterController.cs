using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float speed = 4.0f;
    public float jumpSpeed = 3.0f;

    bool grounded = false;
    public Transform groundCheck;
    float groundradius = 0.2f;
    public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
        
    }
	
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundradius, whatIsGround);

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }
}
