using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script that stops the globally playing song during intro

public class pauseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("introMusic") != null)
            backgroundMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
