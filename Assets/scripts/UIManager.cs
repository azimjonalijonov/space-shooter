using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour

{
public static UIManager instance;
public GameObject gameOverScreen;
public TextMeshProUGUI livesText;
public Slider healthBar;

private void Awake(){
    instance=this;
}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void quitToMain(){

    }
}
