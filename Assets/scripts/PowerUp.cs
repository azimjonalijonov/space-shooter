using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isShield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            Destroy(gameObject);
            if(isShield){
                HealthManager.instance.ActivateShield();
            }
        }
    }
}
