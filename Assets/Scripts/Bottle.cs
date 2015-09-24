using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gObj = other.gameObject;
        AudioClip clip;
        
        if (gObj.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
