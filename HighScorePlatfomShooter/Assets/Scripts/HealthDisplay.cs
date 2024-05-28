using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public HealthSystem healthSystem;
    public float orinalXscale;
    public float smoothingTime = .35f;

    // Start is called before the first frame update
    void Start()
    {
        orinalXscale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 barTransform;
        barTransform.x = orinalXscale * (healthSystem.currentHealth / healthSystem.maxHealth);
        barTransform.y = transform.localScale.y;
        barTransform.z = transform.localScale.z;

        gameObject.LeanScale(barTransform, smoothingTime).setEase(LeanTweenType.linear);
    }
}
