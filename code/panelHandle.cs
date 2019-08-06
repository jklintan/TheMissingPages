using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class panelHandle : MonoBehaviour
{
    public static GameObject panel;
    public static int countUserInteract = 0;
    public static bool firstInfoDisplayed;
    public Canvas CanvasObject; // Assign in inspector

    public bool menu;
    public static bool convoOpen;
    public bool convo;
    public static bool menuOpen;
    public bool start;
    public static bool notOpen;
    public bool not;


    void Start()
    {
        CanvasObject = GetComponent<Canvas>();
        //firstInfoDisplayed = false;
        //countUserInteract = 0;
    }

    void Update()
    {

        //If in World of Books
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {

            if (countUserInteract < 1)
                Time.timeScale = 0;

            else if (countUserInteract != 0 && !menu && !convo)
            {
                Time.timeScale = 1;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (countUserInteract == 1)
                {
                    CanvasObject.enabled = false;
                    firstInfoDisplayed = true;
                }
            }

            if (firstInfoDisplayed && !menu && !convo)
            {
                CanvasObject.enabled = false;
                Time.timeScale = 1;
            }


            //Don't display menu at other times
            if (menu && !menuOpen)
            {
                CanvasObject.enabled = false;
                //Time.timeScale = 1;
            }

            //Display menu
            if (Input.GetKeyDown(KeyCode.Escape) && menu)
            {
                menuOpen = true;
                Time.timeScale = 0;
            }

            if (Input.GetKeyDown(KeyCode.X) && menu && menuOpen)
            {
                SceneManager.LoadScene(8);
            }


            if (menu && menuOpen)
            {
                if (firstInfoDisplayed && !convoOpen)
                    CanvasObject.enabled = true;
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Space) && menu && menuOpen)
                    menuOpen = false;
            }

            //Don't display convo at other times
            if (convo && !convoOpen)
            {
                CanvasObject.enabled = false;
                Time.timeScale = 1;
            }

            if (!convoOpen && girlMove.talkToTumnus && convo)
            {
                convoOpen = true;
                Time.timeScale = 0;
            }

            if (convoOpen || menuOpen || start || notOpen)
                Time.timeScale = 0;

            if (convo && convoOpen)
            {
                if (firstInfoDisplayed && convoOpen)
                    CanvasObject.enabled = true;
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.X) && convo && convoOpen)
                {
                    convoOpen = false;
                    girlMove.talkToTumnus = false;
                }

            }

            //Don't display convo at other times
            if (not && !notOpen)
            {
                CanvasObject.enabled = false;
                Time.timeScale = 1;
            }

            if (!notOpen && girlMove.atDoorNotOpen && not)
            {
                notOpen = true;
                Time.timeScale = 0;
            }

            if (not && notOpen)
            {
                if (firstInfoDisplayed && notOpen)
                    CanvasObject.enabled = true;
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.X) && not && notOpen)
                {
                    notOpen = false;
                    girlMove.atDoorNotOpen = false;
                }

            }
        }else if(SceneManager.GetActiveScene().buildIndex == 6) //If in Narnia
        {

            //Display menu
            if (Input.GetKeyDown(KeyCode.Escape) && menu)
            {
                menuOpen = true;
                Time.timeScale = 0;
            }

            if(Input.GetKeyDown(KeyCode.X) && menu && menuOpen)
            {
                menuOpen = false;
                SceneManager.LoadScene(5);
            }

            if (menu && menuOpen)
            {
                CanvasObject.enabled = true;
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Space) && menu && menuOpen)
                    menuOpen = false;
            }

            //Don't display menu at other times
            if (menu && !menuOpen)
            {
                CanvasObject.enabled = false;
                Time.timeScale = 1;
            }
        }
    }



}
