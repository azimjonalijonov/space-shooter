using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLives=3;
    public int currentScore;
    public float respawnTime=2f;
    private int highScore=500;

    public void Awake(){
        instance=this;
    }
    public void KillPlayer(){
        currentLives--;
        UIManager.instance.livesText.text="x "+currentLives;

        if(currentLives>0){
            StartCoroutine(RespawnCo());

        }else{
    UIManager.instance.gameOverScreen.SetActive(true);
    WaveManager.instance.canSpawnWaves=false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
                UIManager.instance.livesText.text="x "+currentLives;
                UIManager.instance.scoreText.text="Score: "+currentScore;
                       
                       highScore=PlayerPrefs.GetInt("Record");
                            UIManager.instance.highScoreText.text="Record: "+highScore;


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator RespawnCo(){
        yield return new WaitForSeconds(respawnTime);
        HealthManager.instance.Respawn();
                     WaveManager.instance.continueSpawning();


    }

    public void AddScore(int scoreToAdd){
        currentScore+=scoreToAdd;
        UIManager.instance.scoreText.text="Score: "+currentScore;
        if(currentScore>highScore){
            highScore=currentScore;
            UIManager.instance.highScoreText.text="Record: "+highScore;
       
       
              PlayerPrefs.SetInt("Record",highScore);
        }

    }
}
