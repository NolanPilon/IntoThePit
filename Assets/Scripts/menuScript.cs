using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    float timerTransition = 1f;
    bool startedGame = false;
    AudioSource start;
    public AudioClip startSound;
    void Start()
    {
        start = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startedGame == true) 
        {
            timerTransition -= Time.deltaTime;
        }

        if (timerTransition <= 0) 
        {
            startedGame = false;
            timerTransition = 1f;
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void quitGame() 
    {
        Application.Quit();
    }

    public void startGame() 
    {
        start.PlayOneShot(startSound, 0.5f);
        startedGame = true;   
    }
}
