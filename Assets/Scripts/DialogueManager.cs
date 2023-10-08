using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Animator an_halime;
    public Animator an_azize;
    public Animator an_sevki;
    public Animator biz;
    public Animator gifted;



    private Queue<string> sentences; //fifo collection
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (DialogueStarter.isTriggered == false)
        {
            an_halime.SetBool("IsOpen", false);
            an_azize.SetBool("IsOpen", false);
            an_sevki.SetBool("IsOpen", false);
            biz.SetBool("IsOpen", false);

        }



        if (DialogueStarter.isTriggered==true && PeaceCheck.WhoTalks ==0)
        {
            an_halime.SetBool("IsOpen", true);
        }



        if(DialogueStarter.isTriggered == true && PeaceCheck.WhoTalks == 1)
        {
            an_azize.SetBool("IsOpen", true);
        }

        if (DialogueStarter.isTriggered == true && PeaceCheck.WhoTalks == 2)
        {
            an_sevki.SetBool("IsOpen", true);
        }

        if (DialogueStarter.isTriggered == true && PeaceCheck.WhoTalks == 3)
        {
            biz.SetBool("IsOpen", true);
        }


    }

    public void StartDialogue (Dialogue dialogue)
    {
               
        Debug.Log("Starting Conversation With "+dialogue.name);
        
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach(string sentence in dialogue.sentences) 
        
        { 
            sentences.Enqueue(sentence);
            
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        
        Debug.Log("Konuþma Bitti");
        animator.SetBool("IsOpen", false);
        gifted.SetBool("IsGiven", true);
        DialogueStarter.isTriggered = false;

    }
}
