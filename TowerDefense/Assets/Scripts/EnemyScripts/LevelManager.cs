using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    
    //Makes a array for the Points so that the enemy can follow them
    public Transform StartPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this; 
    }

}
