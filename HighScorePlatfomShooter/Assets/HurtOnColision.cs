using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnColision : MonoBehaviour
{
    public float damage = 1;
    public float forceAmount = 1;
    public float forceRadius = 1;

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.gameObject.TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
        {
            healthSystem.TakeDamage(damage);
        }
        collision.rigidbody.AddExplosionForce(forceAmount, transform.position, forceRadius);

    }
}
