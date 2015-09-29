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
			transform.Translate (Vector2.right * speed);
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate (Vector2.down * speed);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate (Vector2.left * speed);
		}
		
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate (Vector2.up * speed);
		}
		
		if( Input.GetMouseButtonDown( 0 ) )
        {
            anim.SetTrigger( "Attack" );
        }
	
	}
}
