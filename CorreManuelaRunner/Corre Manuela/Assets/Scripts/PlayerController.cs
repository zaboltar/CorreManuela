using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	private float speedMilestoneCountStore;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	public float jumpForce;
	public float jumpTime;
	
	private bool stoppedJumping;
	private bool canDoubleJump;

	private float speedIncreaseMilestoneStore;
	private float jumpTimeCounter;
	private Rigidbody2D myRB;
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	public GameManager theGameManager;

	//private Collider2D myCollider;
	private Animator myAnimator;

	void Start () {
		
		myRB = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D>();
		myAnimator = GetComponent<Animator>();
		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		stoppedJumping = true;
	}
	
	
	void Update () {

		//grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
	
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround );

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRB.velocity = new Vector2 (moveSpeed, myRB.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {

			if (grounded) {
				myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
				stoppedJumping = false;
			}

			if (!grounded && canDoubleJump)
			{
				myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
			}
			
		}

		if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping ) {
			if (jumpTimeCounter > 0) {
				myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		myAnimator.SetFloat("Speed", myRB.velocity.x);
		myAnimator.SetBool("Grounded", grounded);


	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "KillBox") {
            float highscore = PlayerPrefs.GetFloat("Highscore");
            UserDataFB user = new UserDataFB("DummyUser", highscore);
            //RestClient.Post("https://corre-manuela.firebaseio.com/.json", user);
            RestClient.Put("https://corre-manuela.firebaseio.com/userScores/"+user.userName+".json", user);
            theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}	
	}
}
