using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private float _moveRate;
	Animator anim;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
		_moveRate = speed * Time.deltaTime;
				
        if(Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
            transform.Translate (Vector2.right * _moveRate);
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
            transform.Translate (-Vector2.up * _moveRate);
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
            transform.Translate (-Vector2.right * _moveRate);
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.AngleAxis(0f, Vector3.forward);
            transform.Translate (Vector2.up * _moveRate);
        }
        
        if( Input.GetMouseButtonDown( 0 ) )
        {
            anim.SetTrigger( "Attack" );
        }
    }
}
