using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int playerHealth = 10;
    [SerializeField] private int damage = 1;
    [SerializeField] private string enemyTag;
    [SerializeField] private GameObject DeathPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag) && playerHealth >= 0)
        {
            playerHealth -= damage;
        }
        if (playerHealth <= 0) 
        {
            DeathPanel.SetActive(true);
        }
    }

}
