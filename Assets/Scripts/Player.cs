using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

public float speed;
public bool hasBottle;

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown( 0 ) )
        {
            anim.SetTrigger( "Attack" );
        }
		if(Input.GetKeyDown(KeyCode.E) && Bottle.WalkedOverObject)
		{
			Destroy(Bottle.WalkedOverObject);
		}
    }
	
	void FixedUpdate() 
    {

	}
}
