using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	public GameObject Bullet;
	public float min=5f;
	public float max=6f;
	public float Health = 50;
	// Use this for initialization
	void Start () {
		//Debug.Log ("HIIIIIIII",gameObject);
		min=transform.position.x;
		max=transform.position.x+6;
	}

	void TakeDamage(int damage){
		Health -= damage;
		if (Health <= 0) Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (Mathf.PingPong (Time.time * 6, max - min) + min, transform.position.y, transform.position.z);

	}

}
