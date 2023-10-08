using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueStarter : MonoBehaviour
{
    public Animator animator2;
    DialogueManager manager;
    public static bool isTriggered = false;
    public Animator gifted2;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;           
                       
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTriggered = false;
            gifted2.SetBool("IsGiven", false);
        }
    }


}
