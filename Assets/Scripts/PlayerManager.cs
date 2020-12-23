using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isReverse = false;
    float angle = 0;
    public float speed = 60;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(isReverse == true)
        {
            this.transform.rotation = Quaternion.Euler(0, angle, 0);
            angle -= Time.deltaTime * speed;
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, angle, 0);
            angle += Time.deltaTime * speed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isReverse = !isReverse;
        }
    }
}
