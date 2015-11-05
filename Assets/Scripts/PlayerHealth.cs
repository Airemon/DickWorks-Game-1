using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public GameObject deathEffect;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	private SpriteRenderer healthbar;
	private Vector3 healthscale;
	[SerializeField]
	private float Health = 40f;
	private float hitTime;
	
	Animator anim;
	bool damaged;
	

	// Use this for initialization
	void Start () {
		healthbar = GameObject.Find ("Healthbar").GetComponent<SpriteRenderer> ();
		healthscale = healthbar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0){
			Instantiate(deathEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		if(Health > 40){
			Health = 40;
		}
		HealthUpdate ();
		if(damaged){
			damageImage.color = flashColor;
		}
		else{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
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
			damaged = true;
			healthSlider.value = Health;
		}
	}
}
