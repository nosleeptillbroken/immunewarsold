using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerSpawner : MonoBehaviour
{
    
    // The current tower to spawn. Switch this tower to a different name, and create a new prefab in the Assets/Prefabs folder with the same name to change the tower
    public string towerName = "GenericTower";

    static GameObject ghost;

    static bool first = true;

    void Start()
    {
        if (first)
        {
            first = false;

            // Load the ghost from the tower prefab
            ghost = Instantiate(Resources.Load<GameObject>(Game.GetPrefabLocation(towerName)));

            // Destroy tower components so it's not functional
            Destroy(ghost.GetComponent<CapsuleCollider>());
            Destroy(ghost.GetComponent<Tower>());

            // 
            ghost.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Transparent/Diffuse"));
            ghost.name = "Tower Ghost";
            ghost.layer = 1;

        }
    }



    void Update()
    {
        // Raycast once per frame for tower location and for displaying tower ghost
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // If raycast collides
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~LayerMask.GetMask("Towers"))) // ignore towers in raycast so they don't obstruct terrain
        {
            // Make the ghost appear
            ghost.SetActive(true);

            // Set the ghost's position to the collision point of the ray
            ghost.transform.position = hit.point;

            // Orient the ghost so it's facing in the normal direction of the surface
            Quaternion YY = Quaternion.FromToRotation(Vector3.up, Vector3.forward);
            ghost.transform.rotation = Quaternion.LookRotation(hit.normal) * YY;


            // Load the new tower's prefab
            GameObject newTowerObj = Resources.Load<GameObject>(Game.GetPrefabLocation(towerName));

            // Check if the tower would collide with any other towers
            bool collidesWithtower = false;
            if (newTowerObj != null)
            {
                // Get tower's collider component
                CapsuleCollider collider = newTowerObj.GetComponent<CapsuleCollider>();

                // Casts a sphere at the collision point that is the same radius as the tower's collider
                // Returns true if colliding with tower
                collidesWithtower = Physics.CheckSphere(hit.point, collider.radius * newTowerObj.transform.localScale.z, ~LayerMask.GetMask("Terrain")/*ignore terrain colliders*/);

                // if tower does not collide
                if (!collidesWithtower)
                {
                    // set ghost color to green to indicate tower can be placed
                    ghost.GetComponent<MeshRenderer>().material.color = new Color(0, 0.75f, 0, 0.5f);

                    // if mouse button is pressed
                    if (Input.GetMouseButtonDown(0))
                    {
                        // place the tower according to the ghost
                        GameObject newTower = Instantiate(newTowerObj);
                        newTower.transform.position = ghost.transform.position;
                        newTower.transform.rotation = ghost.transform.rotation;
                    }
                }
                else // otherwise
                {
                    // set ghost color to red
                    ghost.GetComponent<Renderer>().material.color = new Color(0.75f, 0, 0, 0.5f);
                }
            }
        }
        else
        {
            // Turn off ghost if ray does not hit any objects
            ghost.SetActive(false);
        }
    }
}
