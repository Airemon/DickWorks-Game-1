using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	[SerializeField]
	private Player _player;

	public int damageToGive;

	/*public float checkProjection(Vector2 a, Vector2 b){
		return Vector2.Dot(a.normalized(), b.normalized());
	}*/

	void Start () {
		_player = GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Foe"){
			//Do damage to enemy and use a charge of the bottle weapon
			other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
			if(_player.bottleCharges > 0){
				_player.bottleCharges --;
			}
		}
	}
}