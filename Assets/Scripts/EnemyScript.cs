using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    private Vector3 Player;
	private Vector2 playerDirection;
	public float speed;
    private Transform target;
	private float Xdif;
	private float Ydif;
	private bool stun = false;
	private float stunTime = 0f;

    void Start()
    {
		stunTime = 0;
		stun = false;
        GameObject Player = GameObject.FindWithTag( "Player" );
        if(Player != null && stun == false)
        {
            target = Player.GetComponent<Transform>();
        }
    }

    /*void FixedUpdate()
    {
        float z = Mathf.Atan2( (target.transform.position.y - transform.position.y), (target.transform.position.x - transform.position.x) ) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3( 0, 0, z );
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
    }*/
	
	void Update(){
		//distance = Vector2.Distance(Player, transform.position);
		Player = GameObject.Find("Player").transform.position;
		
		if(stun == false){
			Xdif = Player.x - transform.position.x;
			Ydif = Player.y - transform.position.y;
			playerDirection = new Vector2 (Xdif, Ydif);
			
			GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized * speed * Time.deltaTime);
		}
		if(stunTime > 0f){
			stunTime -= Time.deltaTime;
		}
		else{
			stun = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D playerHit){
		if(playerHit.gameObject.tag == "Player"){
			stun = true;
			stunTime = 1f;
		}
	}
}
