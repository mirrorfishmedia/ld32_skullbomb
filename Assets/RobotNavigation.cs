using UnityEngine;
using System.Collections;

public class RobotNavigation : MonoBehaviour {

	public Transform[] destinations;

	public Transform destTemp;

	public float navDistance = 30f;


	private NavMeshAgent agent;

	// Use this for initialization
	void Awake () 
	{

		agent = GetComponent<NavMeshAgent> ();

	}

	void Start()
	{
		SetRandomDest ();
	}

	void SetRandomDest()
	{
		int randomPick = Random.Range (0, destinations.Length);
		//Debug.Log ("randompick" + randomPick);
		destTemp = destinations[randomPick];
		agent.SetDestination(destTemp.position);
		//Debug.Log ("destTemp" + destTemp);
		                  

	}

	void Update()
	{
		if (agent.remainingDistance < navDistance) 
		{
			//agent.Stop ();
			SetRandomDest ();
		}
	}
}
