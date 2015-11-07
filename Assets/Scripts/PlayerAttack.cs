using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public float bottleCharges = 3f;
	public int damageToGive;
	
	/*public float checkProjection(Vector2 a, Vector2 b){
		return Vector2.Dot(a.normalized(), b.normalized());
	}*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(bottleCharges == 0){
			GetComponent<Player>().bottleDestroyed = false;
			GetComponent<Player>().destroyOnlyOne = false;
			GetComponent<Player>().hasBottle = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Foe"){
			other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
			bottleCharges -= 1;
		}
	}
}
