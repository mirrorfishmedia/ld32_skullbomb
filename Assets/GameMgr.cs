using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

	public GameObject victoryMsg;
	public GameObject defeatMsg;
	public GameObject defeatScreen;
	public float reloadDelay = 10f;

	public bool monolithDestroyed;

	PlayerHealth healthScript;

	// Use this for initialization
	void Awake () 
	{
		healthScript = GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDeath()
	{
		if (monolithDestroyed)
			Victory ();
		else {
			Defeat();
		}
	}

	public void Defeat()
	{
		defeatMsg.SetActive (true);
		defeatScreen.SetActive (true);
		Invoke ("Reload", reloadDelay);
	}

	public void Victory()
	{
		victoryMsg.SetActive (true);
		Time.timeScale = .5f;
		Invoke ("Title", (reloadDelay*2));
	}
	


	void Title()
	{
		Application.LoadLevel (0);
	}

	void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
