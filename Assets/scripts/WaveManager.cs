// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WaveManager : MonoBehaviour
// {
//     public static WaveManager instance;
//     public WaveObject[] waves;
//     public int currentWave;
//     public float timeToNextWave;
//     // Start is called before the first frame update

//     private void Awake(){
//      instance=this;
//     }
//     void Start()
//     {
//         timeToNextWave=waves[0].timeToSpawn;
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         timeToNextWave -=Time.deltaTime;
//         if(timeToNextWave<=0){
//             Instantaite(waves[currentWave].theWave,transform.position, transform.rotation);
//             currentWave++;
//             timeToNextWave=waves[currentWave].timeToSpawn;
//         }
        
//     }
// }

// [System.Serializable]
// public class WaveObject{
//     public float timeToSpawn;
//     public EnemyWave theWave;
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public WaveObject[] waves;
    public int currentWave;
    public float timeToNextWave;
    public bool canSpawnWaves;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (waves.Length > 0)
        {
            timeToNextWave = waves[0].timeToSpawn;
        }
        else
        {
            Debug.LogWarning("No waves set in the WaveManager.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawnWaves){
        if (currentWave < waves.Length)
        {
            timeToNextWave -= Time.deltaTime;
            if (timeToNextWave <= 0)
            {
                Instantiate(waves[currentWave].theWave, transform.position, transform.rotation); // Corrected 'Instantaite' typo
                currentWave++;
                if (currentWave < waves.Length-1)
                {
                    currentWave++;
                    timeToNextWave = waves[currentWave].timeToSpawn;
                }
                else
                {
                    canSpawnWaves=false;
                }
            }
        }
    }
}

public void continueSpawning(){
    if(currentWave<waves.Length-1 && timeToNextWave>0){
        canSpawnWaves=true;
    }
}
}

[System.Serializable]
public class WaveObject
{
    public float timeToSpawn;
    public EnemyWave theWave;
}
