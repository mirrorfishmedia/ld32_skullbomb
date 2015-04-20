using UnityEngine;
using System.Collections;

public class ExplodeBuilding : MonoBehaviour {

	public GameObject explodedBldgPf;
	private bool exploded;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Bullet") && !exploded) 
		{
			exploded = true;
			Instantiate(explodedBldgPf, transform.position, transform.rotation);
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Explosion") && !exploded) 
		{
			exploded = true;

			Instantiate(explodedBldgPf, transform.position, transform.rotation);
			gameObject.SetActive(false);
		}
	}
}
