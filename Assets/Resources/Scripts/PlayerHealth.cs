using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public Slider healthBar;	// sets up healthBar to be associated with UI Slider Graphic 

	void Start () 
	{
		healthBar.value = 100;	// initializes player health at 100%
	}
		
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.C))	//	Temporary function to test health decrease
		{
			healthBar.value -=5;		// If the C button is pressed, health decreases by 5pts
		}	
	}
}
