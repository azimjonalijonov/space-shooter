using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currenthealth;
    public int maxHealth;

    public GameObject deathEffect;
    private float invincibleLength=2f;
    private float invinceCounter;
    public SpriteRenderer theSR;
    public int shieldPwr;
    public int shieldMaxPwr=3;
    public GameObject theShield;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // ActivateShield();
        currenthealth = maxHealth;
        UIManager.instance.healthBar.maxValue=maxHealth;
        UIManager.instance.healthBar.value=currenthealth;
    }

    // Update is called once per frame
    void Update()
    {

      if(invinceCounter>=0){
        invinceCounter -=Time.deltaTime;
        if(invinceCounter<=0){
                    theSR.color=new Color(theSR.color.r,theSR.color.g,theSR.color.b, 1f);

        }
      }
    }

    public void HurtPlayer()
    {
        if(invinceCounter<=0){


        if(theShield.activeInHierarchy){
        shieldPwr--;
        if(shieldPwr<=0){
            theShield.SetActive(false);
        }
        }else{
        currenthealth--;
                UIManager.instance.healthBar.value=currenthealth;


        if (currenthealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            GameManager.instance.KillPlayer();
            WaveManager.instance.canSpawnWaves=false;
        }
        }
        }
    }
    public void Respawn(){
        gameObject.SetActive(true);
        currenthealth=maxHealth;
                UIManager.instance.healthBar.value=currenthealth;

        invinceCounter=invincibleLength;
        theSR.color=new Color(theSR.color.r,theSR.color.g,theSR.color.b, .5f);
    }
    public void ActivateShield(){
        theShield.SetActive(true);
        shieldPwr=shieldMaxPwr;
    }
}