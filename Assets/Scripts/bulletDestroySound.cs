using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroySound : MonoBehaviour
{
    AudioSource bulletHit;
    public AudioClip groundHit;
    public float volume = 0.1f;
    void Start()
    {
       bulletHit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") 
        {
            bulletHit.PlayOneShot(groundHit, volume);
        }
    }

}
