using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    
    //Makes a array for the Points so that the enemy can follow them
    public Transform StartPoint;
    public Transform[] path;

    public int currency;


    private void Awake()
    {
        main = this; 
    }

    private void Start()
    {
        currency = 200;
    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount) 
    { 
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("poor af");
            return false;
        }
    }
}
