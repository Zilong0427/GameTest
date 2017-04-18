using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsContrrol : MonoBehaviour {
	public GameEnum.Type_Color ColorType;
	public GameObject Target;
	public float force;
	public GameObject BrokeEffect;
	Vector2 Dir;
	Rigidbody2D m_Rigidbody2D;
	// Use this for initialization
	void Start () {
		Target = GameObject.Find ("Circle");
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Dir = Target.transform.position - transform.position;
		m_Rigidbody2D.AddForce (Dir.normalized * force * Time.deltaTime, ForceMode2D.Force);

	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.GetComponent<CircleAttack> ().GetColorType () == ColorType) {
			GameObject tempEffect = (GameObject)Instantiate (BrokeEffect, transform.position, Quaternion.identity);
			Destroy (tempEffect, 1f);
			Destroy (this.gameObject);
		}
	}
}
