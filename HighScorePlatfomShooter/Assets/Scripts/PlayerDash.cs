using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashDuration = .25f;
    public float dashTimer = .25f;
    public float dashCoolDown = 1;
    public float dashCoolDownTimer;
    public AnimationCurve dashCurve;
    Vector2 dashDir;
    public LayerMask dashMask;
    public float bounceDelay = .05f;
    public float bounceDelayTimer = 0;

    public float DashCoyoateTimer;
    public float DashCoyoateTime;

    public PlayerMovment player;
    public HealthSystem health;
    Vector2 tempVelocity;
    public MeshRenderer meshRenderer;
    public Vector2 HandleDash()
    {
        tempVelocity = dashDir * dashSpeed * dashCurve.Evaluate(1 - (dashTimer / dashDuration));

        Debug.DrawLine(transform.position, dashDir);
        dashTimer -= Time.deltaTime;
        bounceDelayTimer -= Time.deltaTime;
        if (dashTimer <= 0) 
        {
            health.isInvincible = false;
            meshRenderer.material.color = Color.white;

            DashCoyoateTimer -= Time.deltaTime;
            if(DashCoyoateTimer <= 0)
            {
                tempVelocity = EndDash(tempVelocity);
                DashCoyoateTimer = DashCoyoateTime;
            }
        }

        return tempVelocity;
    }
   

    private Vector2 EndDash(Vector2 tempVelocity)
    {
        tempVelocity.y = 0;
        
        return tempVelocity;
    }
    public void StartDash()
    {
        health.isInvincible = true;
        Vector2 dir = player.weaponAimer.aim.position - transform.position;
        dashDir = dir.normalized;
        meshRenderer.material.color = Color.green;
        dashCoolDownTimer = dashCoolDown;
        dashTimer = dashDuration;
    }
    public bool IsDashing()
    {
        return dashTimer > 0;
    }
    public bool IsOnCoolDown()
    {
        return dashCoolDownTimer > 0;
    }
    private void Update()
    {
        if (IsOnCoolDown())
        {
            dashCoolDownTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsDashing())
        {
            if (bounceDelayTimer <= 0)
            {
                dashDir = Vector3.Reflect(dashDir, collision.GetContact(0).normal);
                Debug.DrawRay(collision.GetContact(0).point, collision.GetContact(0).normal, Color.cyan, 4);
                Debug.DrawRay(collision.GetContact(0).point, dashDir, Color.black, 4);
                bounceDelayTimer = bounceDelay;
            }
        }
    }
}
