using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundMusic : MonoBehaviour
{
    //Play song globally
    private static backgroundMusic instance = null;

    //Get id where song should stop playing
    int id;

    void Update()
    {
        //Get active scene ID
        id = SceneManager.GetActiveScene().buildIndex;

        if (id == 5)
            Destroy(this.gameObject);
    }

    public static backgroundMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
            return;
        else
            instance = this;

        //Keep the song playing
        DontDestroyOnLoad(this.gameObject);

    }
}
