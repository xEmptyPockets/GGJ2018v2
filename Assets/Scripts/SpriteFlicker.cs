using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFlicker : MonoBehaviour
{
    public float waitTime;

    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;

    private Image img;
    private IEnumerator coroutine;

    private SfxPlayer sfx;

    void Awake()
    {
        img = gameObject.GetComponent<Image>();

        GameObject sfxObj = GameObject.Find("SfxPlayer");
        sfx = sfxObj.GetComponent<SfxPlayer>();

        coroutine = Flicker(waitTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator Flicker(float waitTime)
    {
        img.sprite = spr1;
        //sfx.PlaySoundEffect("high repeating beap");
        yield return new WaitForSeconds(waitTime);
        img.sprite = spr2;
        //sfx.PlaySoundEffect("high repeating beap");
        yield return new WaitForSeconds(waitTime);
        img.sprite = spr1;
        //sfx.PlaySoundEffect("high repeating beap");
        yield return new WaitForSeconds(waitTime);
        img.sprite = spr2;
        //sfx.PlaySoundEffect("high repeating beap");
        yield return new WaitForSeconds(waitTime);
        img.sprite = spr1;
        //sfx.PlaySoundEffect("high repeating beap");
        yield return new WaitForSeconds(waitTime);
        img.sprite = spr2;
        //sfx.PlaySoundEffect("high repeating beap");
        yield return new WaitForSeconds(waitTime);
        img.sprite = spr3;
        //sfx.PlaySoundEffect("Explosion");
        yield return new WaitForSeconds(waitTime);
    }
}
