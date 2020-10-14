using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public HealthController healthController;

    public Rigidbody2D playerRigidbody;

    public Transform playerPos;

    public GameObject player;

    //var playerMaterialRenderer;

    Vector3 dir;

    public int damage;

    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        //var playerMaterialRenderer = player.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = (playerPos.position - transform.position).normalized;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        healthController.currentHealth -= damage;

        Debug.Log("getting hit");

        playerRigidbody.AddForce(dir * thrust, ForceMode2D.Impulse);
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
