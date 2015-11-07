using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour 
{
	public static GameObject WalkedOverObject;

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object Entered the Trigger");
		GameObject gObj = other.gameObject;	
    }
}
