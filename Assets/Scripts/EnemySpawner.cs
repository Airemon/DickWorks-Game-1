using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Foes;
    public Transform player;
    public float numEnemies;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float spawnCooldown = 1;
    private float timeUntilSpawn = 0;

    public static Vector2 RandomAxis()
    {
        int randX = Random.Range( -1, 2 );
        int randY = 0;
        if( randX == 0 )
        {
            randY = Random.Range( -1, 2 );
        }

        return new Vector2( randX, randY );
    }

    public static Vector2 RandomDirection()
    {
        return Quaternion.Euler( 0.0f, 0.0f, Random.Range( 0.0f, 360.0f ) ) * Vector2.right;
    }

    public static Vector2 RandomPositionInCircle( Vector2 position, float radius )
    {
        return RandomDirection() * radius;
    }
    
    

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if( Foes[0] != null && timeUntilSpawn <= 0.0f )
        {
            Vector2 spawnDirection = RandomAxis();
            Vector3 spawnLocation = transform.position + (Vector3)spawnDirection;
            
            GameObject enemy = GameObject.Instantiate( Foes[0], spawnLocation, Quaternion.identity ) as GameObject;

            timeUntilSpawn = spawnCooldown;
			spawnCooldown -= 0.5f;
			if (spawnCooldown <= 1.0f) {
				spawnCooldown = 1.0f;
			}
        }
    }
}