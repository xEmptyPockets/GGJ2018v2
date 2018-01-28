using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    private SfxPlayer sfx;

    void Awake()
    {
        GameObject sfxObj = GameObject.Find("SfxPlayer");
        sfx = sfxObj.GetComponent<SfxPlayer>();
    }

    public void StartGame()
    {
        sfx.PlaySoundEffect("bubbly waddle loop");
        SceneManager.LoadScene("MasterScene");
    }
}
