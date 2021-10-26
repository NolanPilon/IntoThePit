using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int enemyHp = 3;
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    private UnityEngine.Object explosionRef;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        explosionRef = Resources.Load("Explode");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet") 
        {
            enemyHp--;
            sr.material = matWhite;
            if (enemyHp <= 0)
            {
                KillSelf();
            }
            else 
            {
                Invoke("ResetMaterial", 0.1f);
            }
        }
    }

    void ResetMaterial() 
    {
        sr.material = matDefault;
    }
    private void KillSelf() 
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        Destroy(gameObject);
    }
}
