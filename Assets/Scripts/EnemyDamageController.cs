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
    }

    // Update is called once per frame
    void Update()
    {
        dir = (playerPos.position - transform.position).normalized;

        if (takingDamage)
        {
            healthController.currentHealth -= damage;
            playerRigidbody.AddForce(dir * thrust, ForceMode2D.Impulse);

            //if()
                

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player" && !source.isPlaying)
        {
            takingDamage = true;

            source.PlayOneShot(playerHurtSound, 0.1f);





        }
        
    }

    

    //IEnumerator Flasher()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        player.material.color = blue;
    //        yield return new WaitForSeconds(.1f);
    //        player.material.color = green;
    //        yield return new WaitForSeconds(.1f);
    //    }
    //}
}
