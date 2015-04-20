using UnityEngine;
using System.Collections;

public class RobotWalk : MonoBehaviour {

	public float speed;

	private Rigidbody rb;
	private bool movingFwd;
	private bool turning;
	private Animator animator;

	public Quaternion targetRotation = new Quaternion (0, 90, 0, 0);



	// Use this for initialization
	void Awake () 
	
	{
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		movingFwd = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (movingFwd) 
		{
//			Debug.Log ("trying to move");
			Vector3 moveForce = new Vector3( 0, 0, speed);
			rb.AddRelativeForce(moveForce);
			//transform.Translate(moveForce);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("TurnTrigger") && !turning)
		{
			Debug.Log ("collided");
			turning = true;
			movingFwd = false;

			animator.SetTrigger("TurnRight");

			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
			{
				movingFwd = true;

			}

			//Vector3 moveForce = new Vector3( 0, 0, 0);
		}


	}

	void OnTriggerExit()
	{
		turning = false;
	}

	
}


