using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public Transform target;

    void Start()
    {
        GameObject Player = GameObject.FindWithTag( "Player" );
        if( Player != null )
        {
            target = Player.GetComponent<Transform>();
        }
    }

    void FixedUpdate()
    {
        float z = Mathf.Atan2( (target.transform.position.y - transform.position.y), (target.transform.position.x - transform.position.x) ) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3( 0, 0, z );
        GetComponent<Rigidbody2D>().AddForce( gameObject.transform.up * speed);
    }
}
