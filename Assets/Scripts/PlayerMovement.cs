using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private float _moveRate;
	private Vector2 _moveDirection;
	Animator anim;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
		_moveDirection = new Vector2(0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
	
		_moveRate = speed * Time.deltaTime;
		
		_moveDirection.x = 0f;
        _moveDirection.y = 0f;

        if (Input.GetKey (KeyCode.D)) {
            _moveDirection += Vector2.right;
        }
        if (Input.GetKey (KeyCode.A)) {
            _moveDirection -= Vector2.right;
        }
        if (Input.GetKey (KeyCode.W)) {
            _moveDirection += Vector2.up;
        }
        if (Input.GetKey (KeyCode.S)) {
            _moveDirection -= Vector2.up;
        }

        if (_moveDirection.x != 0f || _moveDirection.y != 0f) {
            transform.Translate (_moveDirection.normalized * speed * Time.deltaTime);
        }
				
        /*if(Input.GetKey(KeyCode.D))
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
        }*/
    }
}
