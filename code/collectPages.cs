using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectPages : MonoBehaviour
{
    public Text text;
    public Text countText;
    int counta;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText("0");
        counta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int currcount = girlMove.count;
        string c = currcount.ToString();
       
        if (currcount != counta)
        {
            counta = currcount;
            SetCountText(c);
        }
    }

    //This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    void SetCountText(string count)
    {
        countText.text = count;
    }
}
