using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{

    void Start()
    {
        Invoke( "Die", 1f );
        GetComponent<AudioSource>().Play();
    }

    void Die()
    {
        Destroy( gameObject );

    }
}
