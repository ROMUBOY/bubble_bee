using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float playerRange = 10f;

    public Rigidbody2D theRB;

    public GameObject player;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < playerRange)
        {
            Vector3 playerDirection = player.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }
}
