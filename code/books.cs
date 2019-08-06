using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class books : MonoBehaviour
{
    public GameObject thisBook;

    // Start is called before the first frame update
    void Start()
    {
        thisBook = GameObject.Find("narnia");
    }

    // Update is called once per frame
    void Update()
    {
        if (thisBook != null)
        {
            if (girlMove.narniaDone)
                thisBook.SetActive(true);
            else
                thisBook.SetActive(false);
        }
    }
}
