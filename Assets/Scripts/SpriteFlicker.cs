using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlicker : MonoBehaviour
{
    public float waitTime;

    private IEnumerator coroutine;

    void Awake()
    {
        coroutine = Flicker(waitTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator Flicker(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
