using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public GameObject credits;
    public GameObject buttons;
    //public GameObject titleCard;

    public void Start()
    {
        credits = GameObject.Find("Credits");
        buttons = GameObject.Find("Buttons");
        //titleCard = GameObject.Find("TitleCard");

        credits.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        // titleCard.SetActive(false);
        buttons.SetActive(false);
        credits.SetActive(true);
    }
    public void CreditsBack()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
