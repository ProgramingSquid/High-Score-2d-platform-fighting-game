using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float timer = 0;
    public float timeBetweenShots = .5f;
    public Projectile projectile;
    public float spreadAngle = 0;
    public int bulletsPerShot = 1;
    public Vector2 bulletSpeedMod = Vector2.one;
    [Space(30)]
    public float timeBetweenShotsDecrease = .5f;
    public float minTimebetweenShots;
    [Space(20)]
    public float spreadAngleDecrease = 0;
    [Space(20)]
    public float minSpreadAngle = 0;
    [Space(20)]
    public int bulletsPerShotIncrease = 1;
    public Vector2 bulletSpeedModIncrease = Vector2.one;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }
    public void Shoot() 
    {
        if( timer <= 0)
        {
            timer = timeBetweenShots;
            for (int i = 0; i < bulletsPerShot; i++)
            {
                SpawnBullet();
            }

        }
    }

    private void SpawnBullet()
    {
        float spread = Random.Range(-spreadAngle / 2, spreadAngle / 2);
        float angle = transform.rotation.eulerAngles.z + spread;
        float speedMod = Random.Range(bulletSpeedMod.x, bulletSpeedMod.y);
        Projectile p = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, angle));
        p.SetSpeedMod(speedMod);
    }
}
