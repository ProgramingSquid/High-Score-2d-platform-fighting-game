using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float shootTimer = 0;
    public float shootDelay = 3;
    public GameObject projectile;
    public float spreadAngle = 10;


    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         

        if(shootTimer <= 0)
        {
            float spread = Random.Range(-spreadAngle / 2, spreadAngle / 2);
            GameObject p = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle + spread));
            shootTimer = shootDelay;
        }

        shootTimer -= Time.deltaTime;

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
