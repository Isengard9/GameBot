using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaker : MonoBehaviour
{
    public static CoinMaker instance;

    public float angle = 10;
    public GameObject CoinPosition;
    public GameObject CoinPrefab;
    public GameObject CoinParent;
    void Start()
    {
        if (instance == null)
            instance = this;
       
        for (int i = 0; i < (360/angle); i++)
        {
            this.transform.rotation = Quaternion.Euler(0, angle*i, 0);
            var coin =  Instantiate(CoinPrefab, CoinPosition.transform.position, Quaternion.identity, CoinParent.transform);
          
        }
    }

    
    void Update()
    {
        
    }

}
