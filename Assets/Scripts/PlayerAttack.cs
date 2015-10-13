using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public int damageToGive;
	
	/*public float checkProjection(Vector2 a, Vector2 b){
		return Vector2.Dot(a.normalized(), b.normalized());
	}*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(checkProjection(directionToTarget, directionFacing) < .85f){
			if(Input.GetKeyUp(KeyCode.E) && keyDown == false){
			Attack();
			}	
		}
	}
	
	void Attack(){
		float distance = Vector3.Distance(target.transform.position, transform.position);
		if(distance <1.5f){
			enemyHealth eh = (enemyHealth)target.GetComponent("enemyHealth");
			eh.AdjustCurrentHealth(-10);
		}*/
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Foe"){
			other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
		}
	}
}
