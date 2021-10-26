using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isDead = false;
    static public float t;
    void Start()
    {
        startTime = Time.time;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + " : " + seconds;
    }

    public void Died() 
    {
        isDead = true;
    }
}
