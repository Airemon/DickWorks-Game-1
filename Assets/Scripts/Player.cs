﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

public float speed;
public bool hasBottle;
public bool keyDown;

	[SerializeField]
	private float _delayInSeconds = 0.5f;
	[SerializeField]
	private bool _destroyOnlyOne = true;

	private float _keyPressDuration = -1f;
	private bool _bottleDestroyed = false;

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown( 0 ) )
        {
            anim.SetTrigger( "Attack" );
        }

		// "Collect bottle" keyboard handling.
		//If the key is pressed this frame, set _bottleDestroyed
		if (Input.GetKeyDown (KeyCode.E)) {
			_bottleDestroyed = false;
			_keyPressDuration = 0f;
			keyDown = true;
		}
		//If the key is (still) held down, increment duration
		if (Input.GetKey (KeyCode.E)) {
			_keyPressDuration += Time.deltaTime;
		}
		//If the key is released, reset the duration
		if (Input.GetKeyUp (KeyCode.E)) {
			_keyPressDuration = -1f;
			keyDown = false;
		}

    }
	
	void FixedUpdate() 
    {

	}

	// Need to have bottle collision checked in both onTriggerStay and onTriggerEnter!
	void OnTriggerStay2D(Collider2D other)
	{
		attemptToDestroyBottle (other.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		attemptToDestroyBottle (other.gameObject);
	}

	private void attemptToDestroyBottle(GameObject possibleBottle)
	{
		// If the key hasn't been down long enough, or if a bottle is
		// already destroyed, do nothing.
		if (_keyPressDuration < _delayInSeconds || _bottleDestroyed) {
			return;
		}

		// If our collision object isn't actually a bottle, do nothing.
		Bottle bottle = possibleBottle.GetComponent<Bottle> ();
		if (bottle == null) {
			return;
		}

		// Destroy the bottle.
		Destroy(possibleBottle);
		if( _destroyOnlyOne )
		{
			_bottleDestroyed = true;
			hasBottle = true;
		}
	}

}
