using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] layouts;
    public GameObject currentLayout;
    public bool changeLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLayout = layouts[Random.Range(0, layouts.Length)];
        currentLayout.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(changeLevel == true)
        {
            GameObject layout = currentLayout;
            for (int i = 0; i < 50; i++)
            {
                layout = layouts[Random.Range(0, layouts.Length)];
                if(layout != currentLayout) { break; }
            }

            layout.SetActive(true);
            currentLayout.SetActive(false);
            currentLayout = layout;
            changeLevel = false;
        }
    }
}
