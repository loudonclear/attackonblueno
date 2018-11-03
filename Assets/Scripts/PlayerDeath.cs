using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {

    // Use this for initialization
    private int PlayerLives = 3;
    private SpriteRenderer spriteRenderer;
    private Canvas canvas;
    private GameObject canvasGameObject;
    private GameObject RestartButton;
    private GameObject MainMenuButton;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        canvas = FindObjectOfType<Canvas>();
        canvasGameObject = GameObject.FindGameObjectWithTag("CanvasTag");
        canvasGameObject.GetComponentInChildren<Text>().enabled = false;

        RestartButton = GameObject.FindGameObjectWithTag("RestartButtonTag");
        RestartButton.GetComponent<Image>().enabled = false;
        RestartButton.GetComponent<Button>().enabled = false;
        RestartButton.GetComponentInChildren<Text>().enabled = false;

        MainMenuButton = GameObject.FindGameObjectWithTag("MainMenuButtonTag");
        MainMenuButton.GetComponent<Image>().enabled = false;
        MainMenuButton.GetComponent<Button>().enabled = false;
        MainMenuButton.GetComponentInChildren<Text>().enabled = false;

        PlayerLives = 3;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void PlayerDied()
    {
        this.gameObject.SetActive(false);
        canvasGameObject.GetComponentInChildren<Text>().enabled = true;
        RestartButton.GetComponent<Image>().enabled = true;
        RestartButton.GetComponent<Button>().enabled = true;
        RestartButton.GetComponentInChildren<Text>().enabled = true;
        MainMenuButton.GetComponent<Image>().enabled = true;
        MainMenuButton.GetComponent<Button>().enabled = true;
        MainMenuButton.GetComponentInChildren<Text>().enabled = true;
    }

    public void RemoveLife()
    {
        PlayerLives--;
        print("Lives Left: " + PlayerLives);
    }

    public int GetLifeCount()
    {
        return PlayerLives;
    }
}
