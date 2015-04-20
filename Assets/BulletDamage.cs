using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	public int dmg = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) 
	{
		if (other.gameObject.CompareTag ("Player")) {
			PlayerHealth healthScript = other.gameObject.GetComponent<PlayerHealth> ();
			healthScript.GotHit (dmg);

		}
		//Debug.Log ("bullet collided with " + other.gameObject);
		gameObject.SetActive(false);
	}
}
