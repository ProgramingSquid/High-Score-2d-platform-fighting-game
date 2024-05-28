using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEnemyMovment : MonoBehaviour
{
    public float minXPos, maxXPos;
    public float direction;
    public float horizontailSpeed = 7;
    public float VirticlelSpeed = 5;
    public float yDistance;
    public GameObject player;
    public bool updateScreenBordersEveryFrame;

    // Start is called before the first frame update
    void Start()
    {
        minXPos = Camera.main.ScreenToWorldPoint(new Vector3(-(Screen.width / 2), 0, 15)).x;
        maxXPos = (-minXPos);
    }

    // Update is called once per frame
    void Update()
    {   
        ZigZagAcrossScreen();

    }

    private void ZigZagAcrossScreen()
    {
        if(updateScreenBordersEveryFrame == true)
        {
            minXPos = Camera.main.ScreenToWorldPoint(new Vector3(-(Screen.width / 2), 0, 15)).x;
            maxXPos = (-minXPos);
        }
        if (transform.position.x < minXPos)
        {
            direction = 1;
        }
        if (transform.position.x > maxXPos)
        {
            direction = -1;
        }

        if (transform.position.y < player.transform.position.y + yDistance && transform.position.y > player.transform.position.y - yDistance)
        {
            transform.Translate(new Vector3(horizontailSpeed * direction * Time.deltaTime, 0, 0));
        }
        else if (transform.position.y > player.transform.position.y + yDistance)
        {
            transform.Translate(new Vector3(horizontailSpeed * direction * Time.deltaTime, -VirticlelSpeed * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(new Vector3(horizontailSpeed * direction * Time.deltaTime, VirticlelSpeed * Time.deltaTime, 0));
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
