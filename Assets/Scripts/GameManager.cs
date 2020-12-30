using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;
    public static bool isGamePaused = false;

    public Button nextButton;
    public Button continueButton;
    public Text levelText;
    public Text ScoreText;
    public Text BestScoreText;
    public int score = 0;
    public int BestScore = 0;
    public AudioSource Asource;
    int levelNumber = 1;

    
    void Awake()
    {
        if (instance == null)
            instance = this;



        isGameStarted = true;
        isGameEnded = false;
        isGamePaused = false;

        levelNumber = PlayerPrefs.GetInt("LevelNo", 1);
        levelText.text = "Level " + levelNumber;
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = "Best Score : " + BestScore;
        if(levelNumber == 1)
        {
            //default değerler uygulanır.
            score = 0;
            BestScore = PlayerPrefs.GetInt("BestScore", 0);
        }
        else
        {
            //ilerletilmiş değerler uygulanır.
            LevelManager.instance.setStartValues(2.5f, 0.02f);
            score = PlayerPrefs.GetInt("Score" , 0);
            BestScore = PlayerPrefs.GetInt("BestScore", 0);
        }
    }

    

    public void OnCoinGet()
    {
        if (CoinMaker.instance.CoinParent.transform.childCount == 0)
        {
            instance.OnLevelSuccessed();
        }
    }

    public void OnLevelSuccessed()
    {
        isGameEnded = true;
        LevelManager.instance.WinPanel.SetActive(true);

        levelNumber++;
        //Debug.Log(levelNumber);
        //levelText.text = "Level " + levelNumber;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("LevelNo", levelNumber);
        BestScore = BestScore + score;
        ScoreText.text = "Score : " + score;
        
        
    } 

    public void OnLevelFailed()
    {
        LevelManager.instance.LosePanel.SetActive(true);
        isGameEnded = true;
        levelNumber = 1;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("LevelNo", levelNumber);
    }

    public void nextButtonActive()
    {
        LevelManager.instance.WinPanel.SetActive(false);
        SceneManager.LoadScene(0);
        //Debug.Log("sonraki levele geçildi");


    }
    public void restartButtonActive()
    {
        LevelManager.instance.LosePanel.SetActive(false);
        levelText.text = "Level " + levelNumber;
        SceneManager.LoadScene(0);
    }

    public static void AddScore()
    {
        if (instance == null)
            return;

        instance.score++;
        if(instance.BestScore < instance.score)
        {
            instance.BestScore = instance.score;
            instance.BestScoreText.text = "Best Score : " + instance.BestScore;
            PlayerPrefs.SetInt("BestScore", instance.BestScore);
        }

        instance.ScoreText.text = "Score : " + instance.score;

    }


    public static void PlayClip(AudioClip clip)
    {
        instance.Asource.PlayOneShot(clip);
    }
    
}
