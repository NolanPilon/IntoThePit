using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 camPosition = transform.position;
            camPosition.x = (player.position + offset).x;
            transform.position = camPosition;
        }
    }
}
