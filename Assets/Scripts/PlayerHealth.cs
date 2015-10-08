using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public float Health = 100f;
	private SpriteRenderer healthbar;
	private Vector3 healthscale;
	
	private float hitTime;
	

	// Use this for initialization
	void Start () {
		healthbar = GameObject.Find ("Healthbar").GetComponent<SpriteRenderer> ();
		healthscale = healthbar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0){
			Application.Quit ();
			Debug.Log ("The game should quit now");
		}
		if(Health > 100){
			Health = 100;
		}
		HealthUpdate ();
	}
	
	void HealthUpdate (){
		healthbar.transform.localScale = new Vector3 (healthscale.x * Health * 0.01f, 1, 1);
	}
	
	void OnCollisionEnter2D (Collision2D enemyHit){
		if (enemyHit.gameObject.tag == "Foe"){
			
			if (hitTime + 0.5f < Time.time){
				hitTime = Time.time;
				Health -= 10;
			
				float verticalPush = enemyHit.gameObject.transform.position.y - transform.position.y;
				float horizontalPush = enemyHit.gameObject.transform.position.x - transform.position.x;
			
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalPush, -verticalPush)* 2000);
			}
		}
	}
}
