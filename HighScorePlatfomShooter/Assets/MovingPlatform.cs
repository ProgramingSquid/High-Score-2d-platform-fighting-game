using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float timeTo;
    public float waitTime;
    public PlayerMovment playerMovment;
    public Collider playerCollider;
    public PhysicMaterial physicMaterialMove;
    public PhysicMaterial physicMaterial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }
    private void Update()
    {
        Collider collider = GetComponent<Collider>();
        if (Mathf.Abs(playerMovment.moveInput.x) <= 0.05f)
        {
            playerCollider.material = physicMaterialMove;
        }
        else { playerCollider.material = null; }
    }
    IEnumerator Move()
    {
        while (true)
        {   
            transform.LeanMove(pos1.position, timeTo);
            yield return new WaitForSeconds(waitTime);
            transform.LeanMove(pos2.position, timeTo);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
