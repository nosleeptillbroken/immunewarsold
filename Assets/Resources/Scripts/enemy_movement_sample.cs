using UnityEngine;
using System.Collections;

public class enemy_movement_sample : MonoBehaviour {
	public GameObject Bullet;

	public float min=5f;
	public float max=6f;
	public float Health = 50;
	public Tower _TurretScript;
	// Use this for initialization
	void Start () {
		//Debug.Log ("HIIIIIIII",gameObject);
		min=transform.position.x;
		max=transform.position.x+6;
		//
		//
	}

	void TakeDamage(int damage){
		Health -= damage;
		if (Health <= 0) {
			//_TurretScript.SortTargetsByDistance ();
			Destroy(gameObject);
			//_TurretScript.targets.Remove(GameObject.FindGameObjectWithTag("Enemy").transform);
			//_TurretScript.selectedTarget = _TurretScript.targets [0];


			//gameObject.GetComponent<TurretScript> ().SortTargetsByDistance ();
		}
	}

	// Update is called once per frame
	void Update () {
		
			transform.position = new Vector3 (Mathf.PingPong (Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

	}

}
