using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Portal seen as the endpoint to each level, once entered the required values are checked and then reset within
//the level manager, alongside this this is where the scene is reloaded
public class Portal : MonoBehaviour
{
    private LevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            levelManager.CollectCoinsInLevelCheck();
            levelManager.ResetValues();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
