using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Animator anim;

	public GameObject Beer_Bottle_1;
	GameObject bottleInstance;

	public Renderer Rend;

	public float speed;

	public bool destroyOnlyOne;
	public bool bottleDestroyed = false;
	public bool hasBottle { get { return bottleCharges > 0; } }

	public int bottleCharges = 0;

	private float bottleSpeed = 500f;
	[SerializeField]
	private float _actionKeyDelayInSeconds = 0.5f;
	private float _actionKeyPressDuration = -1f;

	private bool _triggerAction = false;
	private bool _actionTriggered = false;
	private bool _bottleThrown = false;
	private bool Diagonal;

	[SerializeField]
	private KeyCode _actionKeyCode = KeyCode.E;

	void Start ()
	{
		anim = GetComponent<Animator>();
		Rend = GetComponent<Renderer> ();
	}

	void Update()
	{
		// Handling of the action key that is common to both throwing a bottle and picking up a bottle.

		// If the key is pressed this frame, set the key press duration to 0 (start counting).
		if (Input.GetKeyDown (_actionKeyCode)) {
			_actionKeyPressDuration = 0f;
			_actionTriggered = false;
		}

		// If the key is (still) held down, increment duration (keep counting).
		if (Input.GetKey (_actionKeyCode)) {
			_actionKeyPressDuration += Time.deltaTime;
		}

		// If the key press duration is greater than the required delay, we are going to trigger the action (potentially subject to other things, of course).
		if (_actionKeyPressDuration >= _actionKeyDelayInSeconds && !_actionTriggered) {
			_triggerAction = true;
		}

		// If the key is released, reset the duration and turn off the trigger action flag.
		if (Input.GetKeyUp (_actionKeyCode)) {
			_actionKeyPressDuration = -1f;
			_triggerAction = false;
		}

		// "Collect bottle" specific stuff. Only applicable if the player does not have a bottle.
		// Note that the triggering of the action occurs in the OnTriggerEnter and OnTriggerStay.
		// The _triggerAction flag is checked & set there.
		if (!hasBottle) {
			// If the key is pressed this frame, set _bottleDestroyed to false.
			if (Input.GetKeyDown (_actionKeyCode)) {
				bottleDestroyed = false;
			}
		}

		// "Throw bottle" specific stuff. Only applicable if the player has a bottle.
		if (hasBottle && _triggerAction) {
			// Throw bottle.
			Debug.Log("THROW BOTTLE!");

			// Put your bottle flying code here.
			bottleInstance = Instantiate(Beer_Bottle_1, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
			bottleInstance.SetActive (true);
			//bottleInstance.velocity = transform.forward * bottleSpeed * Time.deltaTime;

			bottleCharges = 0;
			_triggerAction = false;
			_actionTriggered = true;
		}


		//8-way movement animations
		if(Input.GetKey(KeyCode.W) && Diagonal == false){
			anim.SetBool("Up", true);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", true);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.D) && Diagonal == false){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", true);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", true);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.S) && Diagonal == false){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", true);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", true);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.A) && Diagonal == false){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", true);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", true);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.W) && Diagonal == false){
			anim.SetBool("RunUp", true);
		}
		else{
			anim.SetBool("RunUp", false);
		}
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
			anim.SetBool("RunUpRight", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunUpRight", false);
		}
		if(Input.GetKey(KeyCode.D) && Diagonal == false){
			anim.SetBool("RunRight", true);
		}
		else{
			anim.SetBool("RunRight", false);
		}
		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
			anim.SetBool("RunDownRight", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunDownRight", false);
		}
		if(Input.GetKey(KeyCode.S) && Diagonal == false){
			anim.SetBool("RunDown", true);
		}
		else{
			anim.SetBool("RunDown", false);
		}
		if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
			anim.SetBool("RunDownLeft", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunDownLeft", false);
		}
		if(Input.GetKey(KeyCode.A) && Diagonal == false){
			anim.SetBool("RunLeft", true);
		}
		else{
			anim.SetBool("RunLeft", false);
		}
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
			anim.SetBool("RunUpLeft", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunUpLeft", false);
		}
		Diagonal = false;

		//Attack animation
		if(hasBottle){
			if(anim.GetBool("AttackDown")){
				anim.SetBool("AttackDown", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("Down") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunDown")){
				anim.SetBool("AttackDown", true);
			}
			if(anim.GetBool("AttackDownLeft")){
				anim.SetBool("AttackDownLeft", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("DownLeft") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunDownLeft")){
				anim.SetBool("AttackDownLeft", true);
			}
			if(anim.GetBool("AttackLeft")){
				anim.SetBool("AttackLeft", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("Left") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunLeft")){
				anim.SetBool("AttackLeft", true);
			}
			if(anim.GetBool("AttackUpLeft")){
				anim.SetBool("AttackUpLeft", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("UpLeft") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunUpLeft")){
				anim.SetBool("AttackUpLeft", true);
			}
			if(anim.GetBool("AttackUp")){
				anim.SetBool("AttackUp", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("Up") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunUp")){
				anim.SetBool("AttackUp", true);
			}
			if(anim.GetBool("AttackUpRight")){
				anim.SetBool("AttackUpRight", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("UpRight") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunUpRight")){
				anim.SetBool("AttackUpRight", true);
			}
			if(anim.GetBool("AttackRight")){
				anim.SetBool("AttackRight", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("Right") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunRight")){
				anim.SetBool("AttackRight", true);
			}
			if(anim.GetBool("AttackDownRight")){
				anim.SetBool("AttackDownRight", false);
			}
			if(Input.GetKeyUp(_actionKeyCode) && anim.GetBool("DownRight") || Input.GetKeyUp(_actionKeyCode) && anim.GetBool("RunDownRight")){
				anim.SetBool("AttackDownRight", true);
			}
		}
		else{
			return;
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
		if (!_triggerAction || bottleDestroyed) {
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

		if( destroyOnlyOne ){
			bottleDestroyed = true;
			bottleCharges += 3;
			if( bottleCharges > 3 )
			{
				bottleCharges = 3;
			}
		}

		// Unset our _triggerAction and actionTriggered flags.
		_triggerAction = false;
		_actionTriggered = true;
	}

}