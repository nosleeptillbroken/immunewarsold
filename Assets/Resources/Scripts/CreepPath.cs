using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Specifies a path (or paths) that creeps can follow.
/// </summary>
public class CreepPath : MonoBehaviour {

    public List<Vector3> points = new List<Vector3>();

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < points.Count-1; i++)
        {
            Debug.DrawLine(points[i], points[i + i], Color.blue);
        }

    }

}