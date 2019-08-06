using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public dialogue dial;

    void Start()
    {
        FindObjectOfType<dialogueManager>().startDialogue(dial);
    }

}
