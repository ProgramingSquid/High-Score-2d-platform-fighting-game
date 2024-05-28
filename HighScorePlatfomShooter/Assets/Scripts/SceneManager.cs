using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public float animationDuration;

    public void SwapScenes(int Sceneindex)
    {
        StartCoroutine(Wait(Sceneindex));
    }
    public IEnumerator Wait(int Sceneindex)
    {
        gameObject.LeanScale(new Vector3(1.1f, 1.1f, 1), animationDuration);
        yield return new WaitForSeconds(animationDuration);
        Application.LoadLevel(Sceneindex);

    }

    
}
