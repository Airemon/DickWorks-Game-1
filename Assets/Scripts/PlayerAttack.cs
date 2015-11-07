using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public float bottleCharges = 3f;
	public int damageToGive;
	
	/*public float checkProjection(Vector2 a, Vector2 b){
		return Vector2.Dot(a.normalized(), b.normalized());
	}*/

	void Start () {
	
	}
	
	void Update () {
		if(bottleCharges > 3){
			bottleCharges = 3;
		}
		if(bottleCharges <= 0){
			//Make it so the player can no longer attack until picking up another bottle
			GetComponent<Player>().bottleDestroyed = false;
			GetComponent<Player>().destroyOnlyOne = false;
			GetComponent<Player>().hasBottle = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Foe"){
			//Do damage to enemy and use a charge of the bottle weapon
			other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
			bottleCharges -= 1;
		}
	}
}
