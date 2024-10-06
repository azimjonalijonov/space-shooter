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

        if(currentLives>0){
            StartCoroutine(RespawnCo());

        }else{

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
