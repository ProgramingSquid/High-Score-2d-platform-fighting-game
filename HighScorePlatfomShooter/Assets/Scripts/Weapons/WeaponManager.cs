using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;
    public Transform weaponParent;
    public KeyBinds input;


    // Start is called before the first frame update
    void Start()
    {
        input = PlayerMovment.inputs;
        input.Player.Fire.started += Shoot;
    }
    void Shoot(InputAction.CallbackContext context)
    {
        if (currentWeapon != null)
        {
            currentWeapon.Shoot();
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if(weapon != null)
        {
            DropWeapon();
        }
        currentWeapon = weapon;
        currentWeapon.transform.parent = weaponParent;
        currentWeapon.transform.localPosition = Vector3.zero;
    }
    public void DropWeapon()
    {
        Destroy(currentWeapon.gameObject);
        currentWeapon = null;
    }
}
