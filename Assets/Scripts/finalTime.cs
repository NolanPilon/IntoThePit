using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class finalTime : MonoBehaviour
{
    public Text finalTimeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string finalMinutes = ((int)timerScript.t / 60).ToString();
        string finalSeconds = (timerScript.t % 60).ToString("f2");
        finalTimeText.text = "YOU MADE IT TO THE BOTTOM IN " + finalMinutes + " : " + finalSeconds + " !";
    }
}
