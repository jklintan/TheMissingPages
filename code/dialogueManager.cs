using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    private Queue<string> sentence;

    public Text NameText;
    public Text dialogueText;


    // Start is called before the first frame update
    void Start()
    {
        sentence = new Queue<string>();
    }

    public void startDialogue(dialogue d)
    {
        NameText.text = d.name;
        Debug.Log(d.name);
        Debug.Log(d.sentence[0]);

        sentence.Clear();
        foreach(string sente in d.sentence)
        {
            sentence.Enqueue(sente);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        print("Button pressed");
        print(sentence.Count);
        if(sentence.Count == 0)
        {
            endDialogue();
            return;
        }

        string sent = sentence.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sent));
        //dialogueText.text = sent;
    }


    IEnumerator TypeSentence(string sent)
    {
        dialogueText.text = "";
        foreach(char letter in sent.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void endDialogue()
    {
        Debug.Log("End of conversation ");
    }

    void fixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && sentence != null)
        {
            displayNextSentence();
        }
    }
}
