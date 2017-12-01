using UnityEngine;
using System.Collections;

public class player_movement: MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.
	public Vector2 jumpHeight;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private bool moving_forward;
	private bool grounded;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
    }

	void Update(){
		if ( !moving_forward ) {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
		}	
		else {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
		}


		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) && grounded)  //makes player jump
		{
			if( !moving_forward	 && jumpHeight.x > 0){
				jumpHeight.x *= -1;
			}

			rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
		}
	}
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");
		//Set movement to forward/backwards
		if (moveHorizontal < 0) {
				moving_forward = false;
		}
		else if (moveHorizontal > 0) { 		
				moving_forward = true;
		}

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		     // Cast a ray straight down.
			 RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);
			 
			 // If it hits something...
			 if (hit != null) {
				 grounded = true;
			 }
			 else { grounded = false; }
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);

    }
}
