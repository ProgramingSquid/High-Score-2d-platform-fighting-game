using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float speedMod = 1;
    public float lifeTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rb.velocity = transform.right * speed * speedMod;
    }

    public void SetSpeedMod(float newSpeedMod)
    {
        speedMod = newSpeedMod;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
