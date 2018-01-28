using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmConsole : MonoBehaviour
{
    public GameObject player;
    public GameObject UIPanel;
    public Camera helmCamera;

    public float interactDistance = 2f;

    // Use this for initialization
    void Awake()
    {
        helmCamera = GameObject.Find("helmCamera").GetComponent<Camera>();
        UIPanel = GameObject.Find("HelmPanel");
        player = GameObject.Find("Player");
        UIPanel.SetActive(false);
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && Vector2.Distance(this.transform.position, player.transform.position) < interactDistance)
        {
            UIPanel.SetActive(true);
            Camera.main.enabled = false;
            helmCamera.enabled = true;

            player.GetComponent<PlayerControl>().is_valid = false;
        }
    }

    public void ExitConsole()
    {
        UIPanel.SetActive(false);
        helmCamera.enabled = false;
        Camera.main.enabled = true;
    }
}
