using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

public float speed;
public bool hasBottle;
public bool keyDown;
public bool destroyOnlyOne;
public bool bottleDestroyed = false;

	[SerializeField]
	private float _delayInSeconds = 0.5f;

	private float _keyPressDuration = -1f;

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        // "Collect bottle" keyboard handling.
		//If the key is pressed this frame, set _bottleDestroyed
		if (Input.GetKeyDown (KeyCode.E)) {
			bottleDestroyed = false;
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
		if(hasBottle == true){
			if(Input.GetKeyDown (KeyCode.E)){
				_keyPressDuration = 0f;
				keyDown = true;
			}
			if(Input.GetKeyUp(KeyCode.E)){
				_keyPressDuration += Time.deltaTime; 
			}
			if(Input.GetKeyUp(KeyCode.E)){
				_keyPressDuration = -1f;
				keyDown = false;
			}
			//Throw the Bottle!
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
		if (_keyPressDuration < _delayInSeconds || bottleDestroyed) {
			return;
		}

		// If our collision object isn't actually a bottle, do nothing.
		Bottle bottle = possibleBottle.GetComponent<Bottle> ();
		if (bottle == null) {
			return;
		}

		// Destroy the bottle.
		Destroy(possibleBottle);
		destroyOnlyOne = true;
		//GetComponent<PlayerAttack>().bottleCharges = 3f;
		if( destroyOnlyOne )
		{
			bottleDestroyed = true;
			hasBottle = true;
		}
	}

}
