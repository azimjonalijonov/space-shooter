using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLives=3;
    public float respawnTime=2f;

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
}
