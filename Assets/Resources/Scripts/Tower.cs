using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Tower Class
// One in every tower. Stores all information needed for detecting enemies. Stores range, speed, damage it inflicts
public class Tower : MonoBehaviour
{
    // List of towers in use (STATIC: list is the same for all towers)
    static List<Tower> towerList = new List<Tower>(128);
    // Count of towers (STATIC)
    static int towerCount = 0;
    // Tower ID in list;
    int id = -1;

    public int range;
    public float fireSpeed;
    public float damage;

    // Returns a tower from towerList
    public static Tower GetTowerByIndex(int i)
    {
        return towerList[i];
    }

    // Returns the number of towers currently alive
    public static int NumTowers()
    {
        return towerCount;
    }

    // Returns the current tower's ID
    public int Id()
    {
        return id;
    }

    // Use this for initialization
    void Start()
    {
        towerList.Add(this);
        id = towerList.Count-1;
        gameObject.name = "Tower " + Id() + " (" + gameObject.name + ")";
    }

    void OnDestroy()
    {
        towerList.Remove(this);
        towerCount -= 1;
        id = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionInfo)
    {

    }
}
