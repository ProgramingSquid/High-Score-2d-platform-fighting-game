using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump : MonoBehaviour
{
    public PlayerMovment playerMovment;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            if (!playerMovment.isGrounded)
            {
                playerMovment.Land();
            }

        }
        

    }
}
