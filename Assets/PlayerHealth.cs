using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

	public int hp = 100;
	public GameObject defeatMsg;
	public GameObject defeatScreen;
	public float reloadDelay = 5f;
	private AudioSource hitSource;
	private Rigidbody rb;
	public Rigidbody camRb;
	public Transform cameraTransform;
	public Collider camCollider;
	public RigidbodyFirstPersonController controllerScript;
	public bool immuneToBullets;

	public GameMgr gm;

	public bool playerDead;

	// Use this for initialization
	void Awake () {
		hitSource = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody> ();
		gm = GetComponent<GameMgr> ();
	}


	public void GotHit (int dmgAmt)
	{
		if (!immuneToBullets) {
			hp -= dmgAmt;
			hitSource.Play ();
			if (hp <= 0) {
				Die ();
			}
		}

	}

	public void Die()
	{
		camRb.isKinematic = false;
		camCollider.enabled = true;
		cameraTransform.SetParent (null);
		rb.constraints = RigidbodyConstraints.None;
		rb.mass = 0;
		controllerScript.enabled = false;
		gm.OnDeath ();
		//rb.AddTorque (Vector3.right);


	}
	
}
