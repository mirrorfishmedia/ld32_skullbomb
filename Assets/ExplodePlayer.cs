using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExplodePlayer : MonoBehaviour {

	public Slider bombSlider;
	public int bombTimerMax = 300;
	public GameObject playerExplosionPf;
	public PlayerHealth healthScript;


	private int bombTimer;

	void Awake()
	{
		healthScript = GetComponent<PlayerHealth> ();

	}


	// Use this for initialization
	void Start () {
		bombSlider.maxValue = bombTimerMax;
	
	}
	
	// Update is called once per frame
	void Update () {

		Mathf.Clamp(bombTimer,0,bombTimerMax);

		if (Input.GetButton ("Fire1")) {
		
			bombTimer ++;
			Mathf.Clamp(bombTimer,0,bombTimerMax);
			Debug.Log("timer" + bombTimer);
			if (bombTimer == bombTimerMax) {
				Debug.Log("exploding");
				healthScript.immuneToBullets = true;
				Instantiate(playerExplosionPf, transform.position, transform.rotation);
				Invoke ("DieOnExplode", 10f);
			}

		} else {
			bombTimer = 0;
			Mathf.Clamp(bombTimer,0,bombTimerMax);

		}

		bombSlider.value = bombTimer;


	
	}

	void DieOnExplode()
	{
		healthScript.Die ();
	}
}
