using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    HealthController healthController;

    Rigidbody2D playerRigidbody;

    Transform playerPos;

    GameObject player;

    GameManager gameManager;

    AudioSource source;
    //sounds
    public AudioClip playerHurtSound;

    bool takingDamage;


    //var playerMaterialRenderer;

    Vector3 dir;

    public int damage;

    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        //var playerMaterialRenderer = player.GetComponent<Renderer>();

        source = GetComponent<AudioSource>();

        playerPos = GameObject.Find("Player").GetComponent<Transform>();

        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        healthController = GameObject.Find("Player").GetComponent<HealthController>();

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        dir = (playerPos.position - transform.position).normalized;

        if (takingDamage)
        {
            healthController.currentHealth -= damage;

            //playerPos.position += dir  * 0.1f;

            playerRigidbody.AddForce(dir * thrust, ForceMode2D.Impulse);
            
            if(gameManager.okToFlash == true)
                player.GetComponent<SpriteRenderer>().color = new Color(2, 0, 0);

        }
        else
        {
            Invoke("NormalColour", 5.0f);
            healthController.currentHealth -= 0;

        }
    }

    void NormalColour()
    {
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.name == "Player" && !source.isPlaying)
        {
            takingDamage = true;

            //healthController.currentHealth -= damage;


            source.PlayOneShot(playerHurtSound, 0.1f);





        }
        
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            takingDamage = false;

            source.Stop();
        }
    }
    
    
}
