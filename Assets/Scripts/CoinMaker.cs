using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaker : MonoBehaviour
{
    
    public float angle = 10;
    public GameObject CoinPosition;
    public GameObject CoinPrefab;

    void Start()
    {
        var CoinParent = new GameObject();
        CoinParent.name = "CoinParent";
        for (int i = 0; i < (360/angle); i++)
        {
            this.transform.rotation = Quaternion.Euler(0, angle*i, 0);
            Instantiate(CoinPrefab, CoinPosition.transform.position, Quaternion.identity, CoinParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
