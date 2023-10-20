using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    
    [Header("atributes")]
    [SerializeField] private float moveSpeed= 2f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        //Gives the enemy the point to move to 
        target = LevelManager.main.path[pathIndex];
    }
    private void Update()
    {
        //gives the enemy the point to walk to
       if (Vector2.Distance(target.position, transform.position) <= 0.1f)
       {
            //Adds 1 to the point, so that the enemy moves to the next point
            pathIndex++;


            if(pathIndex == LevelManager.main.path.Length)
            {
                // When the enemy reaches the end it gets destroyed 
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                //It keeps the PathIndex updated 
                target = LevelManager.main.path[pathIndex];
            }
       }
    }

    private void FixedUpdate()
    {
        //It gives the enemy a movement speed and direction
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
