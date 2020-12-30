using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public GameObject BombPrefab;
    public GameObject BombPosition;
    public GameObject BombParent;
 
    public float waittime = 0;
    public float standartwaittime = 0;

    int randomPlayer = 0;
    public AudioClip BombClip;
    //LevelManager lm;

    void Start()
    {
        //lm = GameObject.Find("Game Manager").GetComponent<LevelManager>();
        //standartwaittime = lm.FireSpeed;
        standartwaittime = LevelManager.instance.FireSpeed;
    }

    
    void Update()
    {
        if (!GameManager.isGameStarted || GameManager.isGameEnded || GameManager.isGamePaused)
            return;


       

        if( waittime >= standartwaittime)
        {
            randomPlayer = Random.Range(0, PlayerManager.instance.PlayerPositions.Count);

            this.transform.LookAt(PlayerManager.instance.PlayerPositions[randomPlayer].transform.position);


            GameObject Bomb = Instantiate(BombPrefab, BombPosition.transform.position, Quaternion.identity, BombParent.transform);
            Bomb.GetComponent<BombController>().PlayerPos = PlayerManager.instance.PlayerPositions[randomPlayer].transform.position;
            Bomb.GetComponent<BombController>().speed = LevelManager.instance.BombSpeed;
            waittime = 0;
            GameManager.PlayClip(BombClip);
        }
        else if(waittime < standartwaittime)
        {
            waittime += Time.deltaTime;
        }
    }
}
