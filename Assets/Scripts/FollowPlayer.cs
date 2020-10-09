using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    public float eastBoundary, southBoundary, westBoundary, northBoundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

        CameraBoundaries();
    }

    void CameraBoundaries()
    {
        if (player.position.x >= eastBoundary)
        {
            transform.position = new Vector3(eastBoundary, player.position.y, player.position.z + offset.z);

            if (player.position.y >= northBoundary)
            {
                transform.position = new Vector3(eastBoundary, northBoundary, player.position.z + offset.z);

            }

            if (player.position.y <= southBoundary)
            {
                transform.position = new Vector3(eastBoundary, southBoundary, player.position.z + offset.z);

            }
        }

        if (player.position.x <= westBoundary)
        {
            transform.position = new Vector3(westBoundary, player.position.y, player.position.z + offset.z);

            if (player.position.y >= northBoundary)
            {
                transform.position = new Vector3(westBoundary, northBoundary, player.position.z + offset.z);

            }

            if (player.position.y <= southBoundary)
            {
                transform.position = new Vector3(westBoundary, southBoundary, player.position.z + offset.z);

            }
        }

        if (player.position.x > westBoundary && player.position.x < eastBoundary)
        {
            transform.position = new Vector3(player.position.x, player.position.y, player.position.z + offset.z);

            if (player.position.y >= northBoundary)
            {
                transform.position = new Vector3(player.position.x, northBoundary, player.position.z + offset.z);

            }

            if (player.position.y <= southBoundary)
            {
                transform.position = new Vector3(player.position.x, southBoundary, player.position.z + offset.z);

            }
        }
    }
}
