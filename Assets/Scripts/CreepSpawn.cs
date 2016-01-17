using UnityEngine;
using System.Collections;

public class CreepSpawn : MonoBehaviour {
	public GameObject creep;
	public Vector3 spawnValues;

	public int creepCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0;i < creepCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (creep, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
