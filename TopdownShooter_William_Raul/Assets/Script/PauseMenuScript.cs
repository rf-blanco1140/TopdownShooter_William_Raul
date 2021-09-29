using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    //Menu
    public GameObject mainMenu;
    public Image crossHair;
    public bool menuOn;

    private Shooting _shooting;

    // Start is called before the first frame update
    void Start()
    {
        _shooting = GameObject.Find("Hull").GetComponent<Shooting>();
        menuOn = false;
    }

    // Update is called once per frame
    void Update()
    {


        mainMenu.SetActive(menuOn);
        if (Input.GetKeyDown(KeyCode.Escape) && !menuOn)
        {
            PauseGame();

        }
        else
        if (Input.GetKeyDown(KeyCode.Escape) && menuOn)
        {
            ResumeGame();

        }
    }

    void PauseGame()
    {
        crossHair.enabled = false;
        _shooting.enabled = false;
        Time.timeScale = 0;
        menuOn = true;
        //Cursor.visible = true;
        Debug.Log("Escape key was pressed");
    }

    public void ResumeGame()
    {
        crossHair.enabled = true;
        _shooting.enabled = true;
        Time.timeScale = 1;
        //Cursor.visible = false;
        menuOn = false;
        Debug.Log("Escape key was pressed again");
    }
}
