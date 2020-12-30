using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    /// <summary>
    /// Bombanın hızını kontrol eder.
    /// </summary>
    /// 
    //[HideInInspector]
    public float BombSpeed = 40;
    /// <summary>
    /// Atıcının hızını kontrol eder.
    /// </summary>
    /// 
    
    public float FireSpeed = 1.0f;
    public float levelSpeed = 1.0f;

    public GameObject WinPanel;
    public GameObject LosePanel;
    public void setStartValues(float bombSpeed, float fireSpeed)
    {
        this.BombSpeed += bombSpeed;
        this.FireSpeed -= fireSpeed;
    }
   
    
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    
    void Update()
    {
        
    }
}
