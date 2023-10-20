using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int playerHealth = 10;
    //[SerializeField] private int damage = 1;
    [SerializeField] private string enemyTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == enemyTag)
        {
            Debug.Log("Hit");
            playerHealth--;
            Destroy(gameObject);
        }

    }
}
