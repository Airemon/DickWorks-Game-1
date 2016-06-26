using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public int enemyHealth;
	public GameObject deathEffect;
	public int ScoreValue = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			Instantiate(deathEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			ScoreManager.score += ScoreValue;
		}	
	}
	
	public void giveDamage(int damageToGive){
		enemyHealth -= damageToGive;
	}
}
