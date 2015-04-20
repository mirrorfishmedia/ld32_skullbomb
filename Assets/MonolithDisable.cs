using UnityEngine;
using System.Collections;

public class MonolithDisable : MonoBehaviour {


	public GameMgr gm;

	void OnDisable()
	{
		gm.monolithDestroyed = true;
		gm.OnDeath ();

	}


}
