using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] weapons;
    public Transform[] spawners;
    public float spawnTimmer = 3;
    float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        spawnTime = spawnTimmer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            SpawnWeapon();
            spawnTime = spawnTimmer;
        }
    }

    public void SpawnWeapon()
    {
        int Weaponindex = Random.Range(0, weapons.Length);
        int spawnIndex = Random.Range(0, spawners.Length);
        GameObject weaponGameObject =  Instantiate(weapons[Weaponindex], spawners[spawnIndex].position, Quaternion.identity);
        Weapon weapon = weaponGameObject.GetComponent<WeaponPickUp>().weapon;

        weapon.timeBetweenShots = Mathf.Max(weapon.minTimebetweenShots, weapon.timeBetweenShots - weapon.timeBetweenShotsDecrease);
        weapon.bulletSpeedMod += weapon.bulletSpeedModIncrease;
        weapon.spreadAngle = Mathf.Max(weapon.minSpreadAngle, weapon.spreadAngle - weapon.spreadAngleDecrease);
        weapon.bulletsPerShot += weapon.bulletsPerShotIncrease;
    }
}
