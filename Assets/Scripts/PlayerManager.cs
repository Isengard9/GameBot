using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    bool isReverse = false;
    float angle = 0;
    public float speed = 60;
    bool isGameStarted = false;
   
    public List<GameObject> PlayerPositions = new List<GameObject>();

   
    public AudioClip CoinClip;
    //public GameObject coin;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    
    void Update()
    {
        if (isGameStarted == false && Input.GetMouseButtonDown(0))
            isGameStarted = true;

        if (isGameStarted == false)
            return;


            if (isReverse == true)
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

            if (isReverse == false)
            {
                this.transform.GetChild(0).transform.localRotation = Quaternion.Euler(15.5f, 190, 0);
            }

            else
                this.transform.GetChild(0).transform.localRotation = Quaternion.Euler(-5.5f, -7.125f, 0);
            
                
           
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            
            other.transform.parent = null;
           // Debug.Log(GameManager.instance.score);
            
            Destroy(other.gameObject);

            GameManager.instance.OnCoinGet();
            GameManager.AddScore();

            GameManager.PlayClip(CoinClip);
        }
    }
}
