using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float speed = 20;
    public Vector3 PlayerPos;
    
    void Start()
    {
        this.transform.LookAt(PlayerPos);
        Destroy(this.gameObject, 5);
    }

    
    void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;
    }
   
    private void OnTriggerEnter(Collider collision)
    { 
        //Debug.Log("bomba çarptı" + collision.name);
        if(collision.gameObject.tag == "Player")
        {
           
            Destroy(collision.gameObject);
            GameManager.instance.OnLevelFailed();
        }
    }
}
