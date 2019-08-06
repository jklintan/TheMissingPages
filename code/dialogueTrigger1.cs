using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger1 : MonoBehaviour
{
    public dialogue dial;

    void Start()
    {
        FindObjectOfType<dialogueManager>().startDialogue(dial);
    }

    void display()
    {
        FindObjectOfType<dialogueManager>().startDialogue(dial);
    }
}
