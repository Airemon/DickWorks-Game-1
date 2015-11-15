using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public int damageToGive;
	public bool useCharge = false;
	
	/*public float checkProjection(Vector2 a, Vector2 b){
		return Vector2.Dot(a.normalized(), b.normalized());
	}*/

	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Foe"){
			//Do damage to enemy and use a charge of the bottle weapon
			other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
			useCharge = true;
		}
		useCharge = false;
	}
}
