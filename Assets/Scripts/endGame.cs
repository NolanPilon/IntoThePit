using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public GameObject E;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            E.SetActive(true);
            if (Input.GetKey(KeyCode.E)) 
            {
                GameObject.Find("TimerObject").SendMessage("Died");
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            E.SetActive(false);
        }
    }
}
