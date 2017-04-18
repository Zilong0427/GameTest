using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {
	[Header("這邊放東西用的")]
	public GameObject[] EnsPrefabs;
	public Transform[] InsPositions;

	int r_Ens,r_Pos;
	float r_Time;
	float r_Force;
	bool canIns=true;
	// Use this for initialization
	void Start () {
		r_Time = Random.Range (0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (canIns) {
			StartCoroutine (Ins (r_Time));
		}
	}

	IEnumerator Ins(float t)
	{
		canIns = false;
		r_Ens = (int)Random.Range (0, 2);
		r_Pos = (int)Random.Range (0, 4);
		r_Force = Random.Range (20, 40);
		GameObject temp= (GameObject)Instantiate (EnsPrefabs [r_Ens], InsPositions [r_Pos].position, Quaternion.identity);
		temp.GetComponent<EnsContrrol> ().force = r_Force;
		yield return new WaitForSeconds (t);

		r_Time = Random.Range (1, 3);
		canIns = true;

	}
}
