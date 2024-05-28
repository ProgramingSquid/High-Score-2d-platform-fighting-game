using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapon weapon;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out WeaponManager player))
        {
            Weapon spawnedWeapon = Instantiate(weapon, player.weaponParent.position, player.weaponParent.rotation);
            player.EquipWeapon(spawnedWeapon);
            Destroy(gameObject);
        }
    }

}
