using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTrigger : MonoBehaviour
{
    public GameObject UI;
    float uiTimer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiTimer -= Time.deltaTime;

        if (uiTimer <= 0) 
        {
            UI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            UI.SetActive(true);
            uiTimer = 2;
        }
    }
}
