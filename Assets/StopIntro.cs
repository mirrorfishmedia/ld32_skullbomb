using UnityEngine;
using System.Collections;



public class StopIntro : MonoBehaviour {

	public AudioSource introSource;


	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("p"))
		{
			introSource.Stop();
		}
	}
}
