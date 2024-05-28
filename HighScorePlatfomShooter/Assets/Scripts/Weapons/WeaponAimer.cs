using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAimer : MonoBehaviour
{
    public Camera camera;
    public Rigidbody playerRb;
    public Transform aim;
    public KeyBinds input;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        input = PlayerMovment.inputs;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = input.Player.Mouse.ReadValue<Vector2>();
        Vector3 worldPosition = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - camera.transform.position.z));
        Vector2 difernce = worldPosition - transform.position;
        float angle = Mathf.Atan2(difernce.y, difernce.x);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);


    }
    public void Dash(float speed)
    {
        playerRb.AddRelativeForce(aim.right * speed, ForceMode.Impulse);
        Debug.Log("Dash!");
    }
}
