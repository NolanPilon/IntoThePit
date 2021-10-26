using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    //Movement Vars
    float moveSpeed = 6.0f;
    float jumpSpeed = 6.0f;
    private float jumpTimer;
    private bool isJumping;
    public float jumpTime;
    float xMovement;
    private bool isGrounded;
    public LayerMask isThisGround;
    public float checkRadius;

    //Render/Animation Vars

    public SpriteRenderer playerRenderer;
    public Transform feetPos;
    public Rigidbody2D playerBody;
    public Animator playerAnimator;
    public Rigidbody2D deadPlayer;
    public GameObject deadUI;

    //Shooting Vars

    public Rigidbody2D bullet;
    private int ammo = 3;
    public SpriteRenderer ammoBar;
    public Sprite ammofull;
    public Sprite ammoOne;
    public Sprite ammoTwo;
    public Sprite ammoEmpty;
    public GameObject flash;
    float flashTimer = 0;

    //Audio

    AudioSource playerSound;
    public AudioClip shoot;
    public AudioClip jump;
    public AudioClip walk;
    public float volume=0.5f;



    void Start()
    {
        flash.SetActive(false);
        deadUI.SetActive(false);
        playerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard input

        xMovement = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isThisGround);

        //Jump

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            playerBody.velocity = Vector2.up * jumpSpeed;
            playerSound.PlayOneShot(jump, volume);
            isJumping = true;
            jumpTimer = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true) 
        {
            if (jumpTimer > 0)
            {
                playerBody.velocity = Vector2.up * jumpSpeed;
                jumpTimer -= Time.deltaTime;
            }
            else 
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            isJumping = false;
        }

        //Flip & animate

        if (Input.GetKeyDown(KeyCode.D))
        {
            
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
       
        if (xMovement < 0 || xMovement > 0) 
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

        if (isGrounded == false)
        {
            playerAnimator.SetBool("inAir", true);
        }
        else 
        {
            playerAnimator.SetBool("inAir", false);
            ammo = 3;
        }

        //Shooting
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
        }
        else if (flashTimer <= 0) 
        {
            flash.SetActive(false);
        }

        if (isGrounded == false && ammo > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D clone;
            clone = Instantiate(bullet, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector2.down * 40);
            playerBody.AddForce(transform.up * 300);
            flash.SetActive(true);
            flashTimer += 0.05f;
            playerSound.PlayOneShot(shoot, volume);
            ammo--;
        }

        switch (ammo)
        {
            case 3:
                ammoBar.sprite = ammofull;
                break;
            case 2:
                ammoBar.sprite = ammoOne;
                break;
            case 1:
                ammoBar.sprite = ammoTwo;
                break;
            case 0:
                ammoBar.sprite = ammoEmpty;
                break;
        }

    }

    private void FixedUpdate()
    {
        //Movement
        Vector2 movement = new Vector2(xMovement * moveSpeed, playerBody.velocity.y);
        playerBody.velocity = movement;

    }

    //Enemy Collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Hazard")
        {
            deadUI.SetActive(true);
            Instantiate(deadPlayer, transform.position, transform.rotation);
            GameObject.Find("TimerObject").SendMessage("Died");
            Destroy(gameObject);
        }
    }

    private void FootStep() 
    {
        playerSound.PlayOneShot(walk, volume);
    }
}
