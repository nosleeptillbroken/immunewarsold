using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public bool hit = false;
	public float min=1f;
	public float max=12f;
	public Tower _TurretScript;
	public Vector3 bulletman;

	// Use this for initialization
	void Start () {
		min=transform.position.x;
		max=transform.position.x+6;
		//bulletman = _TurretScript.selectedTarget.transform.position;
	}



	// Update is called once per frame
	 void Update () 
	{
		
		//transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);

	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag("Enemy")){
			// call the function TakeDamage(10) in the hit object, if any
			//i need to call the specific bullet, otherwise all enemies take damage. take not for future sessions
			//transform.position = Vector3.Lerp (transform.position, bulletman, _TurretScript.speed * Time.deltaTime);
			col.gameObject.SendMessage("TakeDamage", 10, SendMessageOptions.DontRequireReceiver);
		}
		Destroy(gameObject); // bullet suicides after hitting anything
	}
}
