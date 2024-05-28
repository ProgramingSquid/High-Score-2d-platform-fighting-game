using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public float damage = 10;
    public bool detroyOnCollide = true;

    private void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent(out HealthSystem target))
        {
            target.TakeDamage(damage);
            
        }
        if(detroyOnCollide == true)
        {
            Destroy(gameObject);
        }
    }
}
