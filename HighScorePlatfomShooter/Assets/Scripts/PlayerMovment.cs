using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float extraGravity = 9.8f;
    public bool isFastFalling = false;
    public PlayerDash playerDash;
    public bool isGrounded = true;
    public Rigidbody rb;
    public Vector2 tempVelocity;
    public Vector2 moveInput;
    public GameObject landingParticle;
    private bool hasLanded;
    private Vector3 particlePos;
    public WeaponAimer weaponAimer;
    public static KeyBinds inputs;

    // Start is called before the first frame update
    void Awake()
    {

        /*StartCoroutine(TestCase1());*/
        inputs = new KeyBinds();
        inputs.Enable();
        inputs.Player.Dash.started += PlayerDash;
        inputs.Player.Jump.started += Jump;
        inputs.Player.Jump.canceled += FastFall;
    }
    void PlayerDash(InputAction.CallbackContext context)
    {
        if (!playerDash.IsOnCoolDown())
        {
            playerDash.StartDash();
        }
    }

    void Jump(InputAction.CallbackContext contex)
    {
        if (isGrounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed);
            isGrounded = false;
        }


    }
    void FastFall(InputAction.CallbackContext context)
    {
        if (rb.velocity.y > 0)
        {
            isFastFalling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        particlePos = transform.position;
        

        tempVelocity.x = 0;
        moveInput.x = 0;
        tempVelocity.y = rb.velocity.y;

        

        if (playerDash.IsDashing()) { tempVelocity = playerDash.HandleDash(); }
        else { Move(); }



        if (isGrounded == true) { isFastFalling = false; }

       /* if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            tempVelocity.y = jumpSpeed;
            isGrounded = false;
        }
        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0)
        {
            isFastFalling = true;
        }*/

        if (rb.velocity.y < 0) { isFastFalling = true; }

        if (isFastFalling && !playerDash.IsDashing())
        {
            tempVelocity.y -= extraGravity * Time.deltaTime;
        }
        rb.velocity = tempVelocity;
    }

    private void Move()
    {
        tempVelocity.x = speed * inputs.Player.Movment.ReadValue<float>();
    }


    IEnumerator TestCase1()
    {
        yield return new WaitForSeconds(1f);
        tempVelocity.y = jumpSpeed;
        rb.velocity = tempVelocity;
        isGrounded = false;
        yield return new WaitForSeconds(0.3f);
        playerDash.StartDash();
    }

    public void Land()
    {
        isGrounded = true;
        isFastFalling = false;
        particlePos.y = transform.position.y - 1;
        Instantiate(landingParticle, particlePos, Quaternion.identity);
    }
}
