using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("Refrences")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private int TurretCost = 100;
    
    private GameObject tower;
    private bool IsPlotFull = false;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = hoverColor;

    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        if(IsPlotFull == false && LevelManager.main.currency >= 100) 
        { 
            GameObject towerToBuild = BuildManager.main.GetSelectedTower();
            LevelManager.main.SpendCurrency(TurretCost);
            Instantiate(towerToBuild, transform.position, Quaternion.identity);
            IsPlotFull = true;
        }
        if(IsPlotFull == true) 
        {
            return;
        }
        
    }

}
