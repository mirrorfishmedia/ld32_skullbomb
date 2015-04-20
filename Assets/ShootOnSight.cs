using UnityEngine;
using System.Collections;

public class ShootOnSight : MonoBehaviour {

	public GameObject bullet;
	public Transform spawnLoc;
	public float shotSpeed = 500f;
	public AudioSource shootSoundSource;
	public NavMeshAgent navAgent;
	public float fireRate = .5f;
	public bool isTurret;
	public Animator anim;

	public Color targetFogColor;

	private Color skyFogColor;
	public float targetFogDensity = .01f;
	private float skyFogDensity;
	private Color skyColor;

	private Transform target;

	private bool shooting;

	private Camera mainCam;

	// Use this for initialization
	void Awake () 
	{
		skyFogColor = RenderSettings.fogColor;
		skyFogDensity = RenderSettings.fogDensity;

		mainCam = GameObject.Find ("MainCamera").GetComponent<Camera>();
		skyColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {

		if (target != null && shooting) {
			spawnLoc.LookAt (target.transform.position);
		}
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			StartFog();
			target = other.transform;
			shooting = true;
			InvokeRepeating("Shoot",0, fireRate);
			if (navAgent !=null)
			{
				navAgent.Stop();
			}
			else
			{
				anim.speed = 0;
			}

		}

	}

	void StartFog()
	{
		RenderSettings.fogDensity = targetFogDensity;
		RenderSettings.fogColor = targetFogColor;
		
		mainCam.backgroundColor = targetFogColor;	
	}

	void EndFog()
	{
		RenderSettings.fogDensity = skyFogDensity;
		RenderSettings.fogColor = skyFogColor;
		
		mainCam.backgroundColor = Color.white;;	
	}

	void OnTriggerExit(Collider other)
	{

		if (other.gameObject.CompareTag ("Player")) {
			EndFog();
			shooting = false;
			CancelInvoke("Shoot");

			if (navAgent !=null)
			{
				navAgent.Resume();
			}
			else
			{
				anim.speed = 1;
			}
		}
	}

	void Shoot()
	{
		if (target != null && shooting) 
		{
			//transform.LookAt (target.transform.position);
			GameObject clone = Instantiate(bullet, spawnLoc.position, spawnLoc.rotation) as GameObject;
			Rigidbody bulletRb = clone.GetComponent<Rigidbody>();
			bulletRb.velocity = (target.transform.position - spawnLoc.position).normalized * shotSpeed;
			//Vector3 shotVector = new Vector3 (0,0, shotSpeed);
			//bulletRb.AddRelativeForce(shotVector);
			shootSoundSource.Play();
		}
	}
}
