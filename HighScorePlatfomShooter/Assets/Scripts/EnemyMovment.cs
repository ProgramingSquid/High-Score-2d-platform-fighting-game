using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 5;
    public Vector3 tempVelocity;
    public Enemy enemy;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tempVelocity.y = rb.velocity.y;
        if(transform.position.x - enemy.player.position.x > 0)
        {
            tempVelocity.x = -speed;
        }
        else
        {
            tempVelocity.x = speed;
        }
        rb.velocity = tempVelocity;
    }
}
